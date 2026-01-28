using Market.BusinessModel.Internal;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.DataAccess.Factories;
using Market.DataAccess.Interfaces;
using System.Data;

namespace Market.WindowsForm.Utils
{
    public static class ChartDataProvider
    {
        private static readonly ServiceFactory _factory = new ServiceFactory();
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
            catch
            {
                var saleService = _factory.CreateSaleService();

                var q = new SaleQuery
                {
                    Page = null,
                    PageSize = null
                };

                var raw = saleService.GetSales(q);
                var receiptService = _factory.CreateReceiptService();
                var receiptMap = new Dictionary<string, DateTime>();

                foreach (var r in receiptService.GetReceipts(new ReceiptQuery()))
                {
                    if (!string.IsNullOrEmpty(r.Id)) receiptMap[r.Id] = r.CreatedAt.Date;
                }

                var buckets = new SortedDictionary<DateTime, int>();
                foreach (var s in raw)
                {
                    if (s == null) continue;
                    var date = receiptMap.TryGetValue(s.ReceiptId, out var d) ? d : DateTime.Today;
                    if (date < from || date > to) continue;
                    if (!buckets.ContainsKey(date)) buckets[date] = 0;
                    buckets[date] += s.Quantity;
                }

                var list = new List<KeyValuePair<DateTime, int>>();
                foreach (var kv in buckets) list.Add(kv);
                return list;
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
            catch
            {
                var saleService = _factory.CreateSaleService();
                var productService = _factory.CreateProductService();

                var sales = saleService.GetSales(new SaleQuery());
                var totals = new Dictionary<string, int>();
                foreach (var s in sales)
                {
                    if (s == null) continue;
                    if (!totals.ContainsKey(s.ProductId)) totals[s.ProductId] = 0;
                    totals[s.ProductId] += s.Quantity;
                }

                var list = new List<KeyValuePair<string, int>>();
                foreach (var kv in totals)
                {
                    var name = productService.GetProducts(new ProductQuery { Ids = new List<string> { kv.Key } })
                                             .FirstOrDefault()?.ProductName ?? kv.Key;
                    list.Add(new KeyValuePair<string, int>(name, kv.Value));
                }

                list.Sort((a, b) => b.Value.CompareTo(a.Value));
                if (list.Count > topN) list = list.GetRange(0, topN);
                return list;
            }
        }

        public static List<StockByProductDto> GetStockByProduct()
        {
            try
            {
                IReportingRepository repo = _repoFactory.CreateReportingRepository();
                return repo.GetStockByProduct();
            }
            catch
            {
                var recordService = _factory.CreateRecordService();
                var productService = _factory.CreateProductService();

                var records = recordService.GetRecords(new RecordQuery());
                var totals = records
                    .GroupBy(r => r.ProductId)
                    .Select(g =>
                    {
                        var product = productService.GetProducts(new ProductQuery { Ids = new List<string> { g.Key } })
                                                    .FirstOrDefault();
                        return new StockByProductDto
                        {
                            ProductId = g.Key,
                            ProductName = product?.ProductName ?? g.Key,
                            TotalStock = g.Sum(x => x.Stock),
                            AvgPrice = g.Any() ? g.Average(x => x.Price) : 0m
                        };
                    })
                    .OrderBy(d => d.ProductName)
                    .ToList();

                return totals;
            }
        }

        public static DataTable ToDataTable<T>(IEnumerable<T> items)
        {
            var dt = new DataTable(typeof(T).Name);
            var props = typeof(T).GetProperties();
            foreach (var p in props)
                dt.Columns.Add(p.Name, Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType);

            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                    values[i] = props[i].GetValue(item) ?? DBNull.Value;
                dt.Rows.Add(values);
            }

            return dt;
        }
    }
}