using Market.BusinessModel.Enums;
using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.DataAccess.Interfaces;

namespace Market.BusinessLogic.Services
{
    public class ProductService : BaseService<ProductModel, ProductQuery, ProductSortBy>, IProductService
    {
        public ProductService(IRepository<ProductModel> repo) : base(repo) { }

        public List<ProductModel> GetProducts(ProductQuery query) => Get(query);
        public void CreateProduct(ProductModel product) => Create(product);
        public void UpdateProduct(ProductModel product) => Update(product);
        public void DeleteProduct(ProductModel product) => Delete(product);
        public bool Exists(string id) => base.Exists(id);
        public void Save(ProductModel product) => Save(product);
    }
}
