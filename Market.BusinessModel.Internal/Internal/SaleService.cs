using Market.BusinessModel.Enums;
using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.DataAccess.Interfaces;


namespace Market.BusinessLogic.Services
{
    public class SaleService : BaseService<SaleModel, SaleQuery, SaleSortBy>, ISaleService
    {
        public SaleService(IRepository<SaleModel> repo) : base(repo) { }

        public List<SaleModel> GetSales(SaleQuery query) => Get(query);
        public SaleModel GetSalesById(string id) => GetById(id);
        public void CreateSale(SaleModel sale) => Create(sale);
        public void UpdateSale(SaleModel sale) => Update(sale);
        public void DeleteSale(SaleModel sale) => Delete(sale);
        public bool Exists(string id) => base.Exists(id);
        public void Save(SaleModel sale) => Save(sale);
    }
}