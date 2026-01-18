using Market.BusinessModel.Enums;
using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.DataAccess.Interfaces;

namespace Market.BusinessLogic.Services
{
    public class FactoryService : BaseService<FactoryModel, FactoryQuery, FactorySortBy>, IFactoryService
    {
        public FactoryService(IRepository<FactoryModel> repo) : base(repo) { }

        public List<FactoryModel> GetFactories(FactoryQuery query) => Get(query);
        public void CreateFactory(FactoryModel factory) => Create(factory);
        public void UpdateFactory(FactoryModel factory) => Update(factory);
        public void DeleteFactory(FactoryModel factory) => Delete(factory);
        public bool Exists(string id) => base.Exists(id);
        public void Save(FactoryModel factory) => Save(factory);
    }
}