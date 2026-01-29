using Market.BusinessModel.Models;
using Market.DataAccess.Factories;
using Market.DataAccess.Interfaces;
using System.Data;

namespace Market.WindowsForm.Utils
{
    public static class ChartDataProvider
    {
        private static readonly RepositoryFactory _repoFactory = new RepositoryFactory();

        public static List<KeyValuePair<DateTime, int>> GetSalesByDateRange(DateTime from, DateTime to)
        {
            try
            {
                IReportingRepository repo = _repoFactory.CreateReportingRepository();
                var dto = repo.GetSalesByDateRange(from.Date, to.Date);
                var list = dto
                    .OrderBy(d => d.SaleDate)
                    .Select(d => new KeyValuePair<DateTime, int>(d.SaleDate, d.TotalQuantity))
                    .ToList();
                return list;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<KeyValuePair<DateTime, int>>();
            }

        }

        public static List<KeyValuePair<string, int>> GetTopProducts(int topN = 10)
        {
            try
            {
                IReportingRepository repo = _repoFactory.CreateReportingRepository();
                var dto = repo.GetTopProducts(topN);
                var list = dto
                    .Select(d => new KeyValuePair<string, int>(d.ProductName, d.TotalQuantity))
                    .ToList();
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<KeyValuePair<string, int>>();
            }
        }

        public static List<StockByProductDto> GetStockByProduct()
        {
            try
            {
                IReportingRepository repo = _repoFactory.CreateReportingRepository();
                return repo.GetStockByProduct();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<StockByProductDto>();
            }
        }

        public static decimal GetCurrentMonthEarnings()
        {
            var now = DateTime.Today;
            var from = new DateTime(now.Year, now.Month, 1);
            var to = from.AddMonths(1).AddTicks(-1);

            try
            {
                var repo = _repoFactory.CreateReportingRepository();
                var earningsByDate = repo.GetEarningsByDateRange(from, to);
                return earningsByDate.Sum(x => x.TotalEarnings);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
    }
}