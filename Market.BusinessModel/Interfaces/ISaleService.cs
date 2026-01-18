using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Interfaces
{
    public interface ISaleService
    {
        List<SaleModel> GetSales(SaleQuery query);
        void CreateSale(SaleModel sale);
        void UpdateSale(SaleModel sale);
        void DeleteSale(SaleModel sale);
        bool Exists(string id);
        void Save(SaleModel sale);
    }
}
