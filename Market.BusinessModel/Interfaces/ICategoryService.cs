using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryModel> GetCategories(CategoryQuery query);
        void CreateCategory(CategoryModel category);
        void UpdateCategory(CategoryModel category);
        void DeleteCategory(CategoryModel category);
        bool Exists(string id);
        void Save(CategoryModel category);
    }
}
