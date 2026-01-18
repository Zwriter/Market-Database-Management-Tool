using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Models;
using Market.DataAccess;
using Market.DataAccess.Factories;
using Market.DataAccess.Interfaces;
using Market.BusinessLogic.Services;

namespace Market.BusinessModel.Internal
{
    public class ServiceFactory
    {
        private readonly RepositoryFactory _repoFactory;

        public ServiceFactory()
        {
            _repoFactory = new RepositoryFactory();
        }

        public IClientService CreateClientService()
        {
            IRepository<ClientModel> repo = _repoFactory.Create<ClientModel>();
            var clientRepo = new ClientRepository();
            return new ClientService(repo, clientRepo);
        }

        public IProductService CreateProductService()
        {
            IRepository<ProductModel> repo = _repoFactory.Create<ProductModel>();
            return new ProductService(repo);
        }

        public ICategoryService CreateCategoryService()
        {
            IRepository<CategoryModel> repo = _repoFactory.Create<CategoryModel>();
            return new CategoryService(repo);
        }

        public IReceiptService CreateReceiptService()
        {
            IRepository<ReceiptModel> repo = _repoFactory.Create<ReceiptModel>();
            return new ReceiptService(repo);
        }

        public IRecordService CreateRecordService()
        {
            IRepository<RecordModel> repo = _repoFactory.Create<RecordModel>();
            return new RecordService(repo);
        }

        public ISaleService CreateSaleService()
        {
            IRepository<SaleModel> repo = _repoFactory.Create<SaleModel>();
            return new SaleService(repo);
        }

        public IFactoryService CreateFactoryService()
        {
            IRepository<FactoryModel> repo = _repoFactory.Create<FactoryModel>();
            return new FactoryService(repo);
        }
    }
}
