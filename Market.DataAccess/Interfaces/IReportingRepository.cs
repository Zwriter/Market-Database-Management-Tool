using Market.BusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DataAccess.Interfaces
{
    public interface IReportingRepository
    {
        List<SalesByDateDto> GetSalesByDateRange(DateTime from, DateTime to);
        List<TopProductDto> GetTopProducts(int topN = 10);
        List<StockByProductDto> GetStockByProduct();
    }
}
