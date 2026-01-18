using Market.BusinessModel.Enums;
using Market.BusinessModel.Requests;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Market.DataAccess.Helpers
{
    public static class RepositoryHelpers
    {
        public static T MapEntity<T>(SqlDataReader reader)
        {
            var entity = (T)Activator.CreateInstance(typeof(T))!;
            var type = typeof(T);

            foreach (var prop in type.GetProperties())
            {
                if (!reader.HasColumn(prop.Name) || reader[prop.Name] is DBNull)
                    continue;

                var raw = reader[prop.Name];
                var propType = prop.PropertyType;
                var targetType = Nullable.GetUnderlyingType(propType) ?? propType;

                object? valueToSet;

                if (raw != null && targetType.IsAssignableFrom(raw.GetType()))
                {
                    valueToSet = raw;
                }
                else if (targetType.IsEnum)
                {
                    valueToSet = raw is string s ? Enum.Parse(targetType, s) : Enum.ToObject(targetType, raw);
                }
                else if (targetType == typeof(Guid))
                {
                    valueToSet = raw is Guid g ? g : Guid.Parse(raw.ToString()!);
                }
                else
                {
                    valueToSet = Convert.ChangeType(raw, targetType);
                }

                prop.SetValue(entity, valueToSet);
            }

            return entity;
        }

        public static string ApplySorting<TSort>(QueryRequest<TSort> query, IEnumerable<PropertyInfo> modelProperties)
            where TSort : struct, Enum
        {
            if (query == null) return string.Empty;
            if (!query.SortBy.HasValue) return string.Empty;

            var candidate = query.SortBy.Value.ToString();

            var match = modelProperties
                .FirstOrDefault(p => string.Equals(p.Name, candidate, StringComparison.OrdinalIgnoreCase));

            if (match == null)
            {
                return string.Empty;
            }

            var direction = MapDirection(query.SortDirection);
            return $" ORDER BY [{match.Name}] {direction}";
        }

        private static string MapDirection(SortDirection dir) =>
            dir == SortDirection.Desc ? "DESC" : "ASC";
    }
}
