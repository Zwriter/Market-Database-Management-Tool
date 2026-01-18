using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.DataAccess.Helpers;
using Market.DataAccess.Interfaces;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Reflection;

namespace Market.DataAccess
{
    public class SQLRepository<T> : IRepository<T> where T : BaseModel
    {
        protected readonly string _connectionString;
        protected readonly string _tableName;
        protected readonly List<PropertyInfo> _properties;

        public SQLRepository()
        {
            try
            {
                _connectionString =
                ConfigurationManager
                    .ConnectionStrings["MarketDb"]
                    .ConnectionString;
            }
            catch
            {
                throw new NotImplementedException();
            }

            _tableName = ResolveTableName();
            _properties = typeof(T).GetProperties().ToList();
        }

        public virtual IEnumerable<T> GetAll()
        {
            var result = new List<T>();

            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            using var cmd = new SqlCommand($"SELECT * FROM {_tableName}", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
                result.Add(Map(reader));

            return result;
        }

        public virtual T? GetById(string id)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            using var cmd = new SqlCommand(
                $"SELECT * FROM {_tableName} WHERE Id = @Id", conn);

            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            return reader.Read() ? Map(reader) : null;
        }

        public virtual IEnumerable<T> Query<TSort>(QueryRequest<TSort> request)
            where TSort : struct, Enum
        {
            var sql = $"SELECT * FROM {_tableName} WHERE 1=1";
            var parameters = new List<SqlParameter>();

            if (request.Ids != null && request.Ids.Any())
            {
                var names = request.Ids.Select((id, i) =>
                {
                    var param = $"@Id{i}";
                    parameters.Add(new SqlParameter(param, id));
                    return param;
                });
                sql += $" AND Id IN ({string.Join(", ", names)})";
            }

            var excluded = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                nameof(QueryRequest<TSort>.Ids),
                nameof(QueryRequest<TSort>.SortBy),
                nameof(QueryRequest<TSort>.SortDirection),
                nameof(QueryRequest<TSort>.Page),
                nameof(QueryRequest<TSort>.PageSize)
            };

            var qType = request.GetType();
            var qProps = qType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                              .Where(p => !excluded.Contains(p.Name));

            foreach (var p in qProps)
            {
                var value = p.GetValue(request);
                if (value == null) continue;

                var column = _properties
                    .FirstOrDefault(x => string.Equals(x.Name, p.Name, StringComparison.OrdinalIgnoreCase))?.Name
                    ?? p.Name;

                if (p.Name.StartsWith("Min", StringComparison.OrdinalIgnoreCase) ||
                    p.Name.StartsWith("Max", StringComparison.OrdinalIgnoreCase))
                {
                    var isMin = p.Name.StartsWith("Min", StringComparison.OrdinalIgnoreCase);
                    var target = p.Name.Substring(3);
                    var targetColumn = _properties
                        .FirstOrDefault(x => string.Equals(x.Name, target, StringComparison.OrdinalIgnoreCase))?.Name
                        ?? target;
                    var op = isMin ? ">=" : "<=";
                    var paramName = $"@{p.Name}";
                    parameters.Add(new SqlParameter(paramName, value));
                    sql += $" AND [{targetColumn}] {op} {paramName}";
                    continue;
                }

                if (p.Name.EndsWith("After", StringComparison.OrdinalIgnoreCase) ||
                    p.Name.EndsWith("Before", StringComparison.OrdinalIgnoreCase))
                {
                    var isAfter = p.Name.EndsWith("After", StringComparison.OrdinalIgnoreCase);
                    var baseName = p.Name.Substring(0, p.Name.Length - (isAfter ? 5 : 6)); // After=5, Before=6
                    var targetColumn = _properties
                        .FirstOrDefault(x => string.Equals(x.Name, baseName, StringComparison.OrdinalIgnoreCase))?.Name
                        ?? baseName;
                    var op = isAfter ? ">=" : "<=";
                    var paramName = $"@{p.Name}";
                    parameters.Add(new SqlParameter(paramName, value));
                    sql += $" AND [{targetColumn}] {op} {paramName}";
                    continue;
                }


                var param = $"@{p.Name}";
                if (p.PropertyType == typeof(string))
                {
                    parameters.Add(new SqlParameter(param, $"%{value}%"));
                    sql += $" AND [{column}] LIKE {param}";
                }
                else
                {
                    parameters.Add(new SqlParameter(param, value));
                    sql += $" AND [{column}] = {param}";
                }
            }

            var order = RepositoryHelpers.ApplySorting(request, _properties);
            if (string.IsNullOrWhiteSpace(order))
                order = " ORDER BY [Id]";
            sql += order;

            if (request.PageSize.HasValue)
            {
                var page = Math.Max(1, request.Page ?? 1);
                var pageSize = Math.Max(1, request.PageSize.Value);
                var offset = (page - 1) * pageSize;

                parameters.Add(new SqlParameter("@Offset", offset));
                parameters.Add(new SqlParameter("@PageSize", pageSize));

                sql += " OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
            }

            return ExecuteQuery(sql, parameters);
        }

        public void Add(T entity)
        {
            var insertableProps = _properties
                .Where(p => p.Name != nameof(BaseModel.Id) &&
                            !string.Equals(p.Name, "CreatedAt", StringComparison.OrdinalIgnoreCase) &&
                            !string.Equals(p.Name, "UpdatedAt", StringComparison.OrdinalIgnoreCase))
                .ToList();

            var columns = insertableProps.Select(p => p.Name);
            var parameters = insertableProps.Select(p => "@" + p.Name);

            string sql = $"""
                INSERT INTO {_tableName}
                ({string.Join(", ", columns)})
                OUTPUT INSERTED.Id
                VALUES ({string.Join(", ", parameters)})
            """;

            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            using var cmd = new SqlCommand(sql, conn);

            foreach (var prop in insertableProps)
            {
                var raw = prop.GetValue(entity);
                object value = raw ?? DBNull.Value;

                if (prop.PropertyType == typeof(DateTime) && raw is DateTime dt && dt == default)
                    value = DBNull.Value;

                cmd.Parameters.AddWithValue("@" + prop.Name, value);
            }

            entity.Id = (string)cmd.ExecuteScalar()!;
        }

        public void Update(T entity)
        {
            var updatableProps = _properties
                .Where(p =>
                    p.Name != nameof(BaseModel.Id) &&
                    !string.Equals(p.Name, "CreatedAt", StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(p.Name, "UpdatedAt", StringComparison.OrdinalIgnoreCase))
                .ToList();

            var sets = updatableProps
                .Select(p => $"{p.Name} = @{p.Name}");

            string sql = $"""
                UPDATE {_tableName}
                SET {string.Join(", ", sets)}
                WHERE Id = @Id
            """;

            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            using var cmd = new SqlCommand(sql, conn);

            foreach (var prop in updatableProps)
            {
                var raw = prop.GetValue(entity);
                object value = raw ?? DBNull.Value;

                if (prop.PropertyType == typeof(DateTime) && raw is DateTime dt && dt == default)
                    value = DBNull.Value;

                cmd.Parameters.AddWithValue("@" + prop.Name, value);
            }

            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.ExecuteNonQuery();
        }

        public virtual void Delete(T entity)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            using var cmd = new SqlCommand($"DELETE FROM {_tableName} WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.ExecuteNonQuery();
        }


        public bool Exists(string id)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            using var cmd = new SqlCommand(
                $"SELECT 1 FROM {_tableName} WHERE Id = @Id", conn);

            cmd.Parameters.AddWithValue("@Id", id);

            return cmd.ExecuteScalar() != null;
        }

        private static string ResolveTableName()
        {
            var attr = typeof(T).GetCustomAttribute<TableAttribute>();
            if (attr == null)
                throw new InvalidOperationException(
                    $"{typeof(T).Name} is missing [Table] attribute");

            return attr.Name;
        }
        protected List<T> ExecuteQuery(string sql, IEnumerable<SqlParameter> parameters)
        {
            var results = new List<T>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(parameters.ToArray());

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                results.Add(Map(reader));
            }

            return results;
        }
        protected virtual T Map(SqlDataReader reader)
        {
            return RepositoryHelpers.MapEntity<T>(reader);
        }
    }
}