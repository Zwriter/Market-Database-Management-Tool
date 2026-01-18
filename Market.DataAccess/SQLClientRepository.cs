using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.DataAccess.Helpers;
using Market.DataAccess.Interfaces;
using Microsoft.Data.SqlClient;


namespace Market.DataAccess
{
    public class ClientRepository : SQLRepository<ClientModel>, IClientRepository
    {
        public List<ClientModel> Get(ClientQuery query)
        {
            var sql = "SELECT * FROM tClient WHERE 1=1";
            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(query.Name))
            {
                sql += " AND Name LIKE @Name";
                parameters.Add(new SqlParameter("@Name", $"%{query.Name}%"));
            }

            if (!string.IsNullOrEmpty(query.Email))
            {
                sql += " AND Email = @Email";
                parameters.Add(new SqlParameter("@Email", query.Email));
            }

            if (query.CreatedAfter.HasValue)
            {
                sql += " AND CreatedAt >= @CreatedAfter";
                parameters.Add(new SqlParameter("@CreatedAfter", query.CreatedAfter));
            }

            sql += RepositoryHelpers.ApplySorting(query, _properties);

            return Query(query).ToList();
        }
    }
}
