using Market.BusinessModel.Models;
using Market.DataAccess.Helpers;
using Market.DataAccess.Interfaces;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Market.DataAccess
{
    public class SQLReportingRepository : IReportingRepository
    {
        private readonly string _connectionString;

        public SQLReportingRepository()
        {
            try
            {
                _connectionString = ConfigurationManager
                    .ConnectionStrings["MarketDb"]
                    .ConnectionString;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to read MarketDb connection string.", ex);
            }
        }

        public List<SalesByDateDto> GetSalesByDateRange(DateTime from, DateTime to)
        {
            var results = new List<SalesByDateDto>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("dbo.GetSalesByDateRange", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@FromDate", from.Date);
            cmd.Parameters.AddWithValue("@ToDate", to.Date);

            conn.Open();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                results.Add(RepositoryHelpers.MapEntity<SalesByDateDto>(reader));
            }

            return results;
        }

        public List<TopProductDto> GetTopProducts(int topN = 10)
        {
            var results = new List<TopProductDto>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("dbo.GetTopProducts", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@TopN", topN);

            conn.Open();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                results.Add(RepositoryHelpers.MapEntity<TopProductDto>(reader));
            }

            return results;
        }

        public List<StockByProductDto> GetStockByProduct()
        {
            var results = new List<StockByProductDto>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("dbo.GetStockByProduct", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Open();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                results.Add(RepositoryHelpers.MapEntity<StockByProductDto>(reader));
            }

            return results;
        }
        public List<EarningsByDateDto> GetEarningsByDateRange(DateTime from, DateTime to)
        {
            var results = new List<EarningsByDateDto>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("dbo.GetEarningsByDateRange", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@FromDate", from.Date);
            cmd.Parameters.AddWithValue("@ToDate", to.Date);

            conn.Open();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                results.Add(RepositoryHelpers.MapEntity<EarningsByDateDto>(reader));
            }

            return results;
        }
    }
}