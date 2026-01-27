using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Interfaces
{
    public interface IProductService
    {
        List<ProductModel> GetProducts(ProductQuery query);
        ProductModel GetProductsById(string id);
        void CreateProduct(ProductModel product);
        void UpdateProduct(ProductModel product);
        void DeleteProduct(ProductModel product);
        bool Exists(string id);
        void Save(ProductModel product);
    }
}
