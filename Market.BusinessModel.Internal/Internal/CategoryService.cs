using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.BusinessModel.Enums;
using Market.DataAccess.Interfaces;


namespace Market.BusinessLogic.Services
{
    public class CategoryService : BaseService<CategoryModel, CategoryQuery, CategorySortBy>, ICategoryService
    {
        public CategoryService(IRepository<CategoryModel> repo) : base(repo) { }

        public List<CategoryModel> GetCategories(CategoryQuery query) => Get(query);
        public CategoryModel GetCategoriesById(string id) => GetById(id);
        public void CreateCategory(CategoryModel category) => Create(category);
        public void UpdateCategory(CategoryModel category) => Update(category);
        public void DeleteCategory(CategoryModel category) => Delete(category);
        public bool Exists(string id) => base.Exists(id);
        public void Save(CategoryModel category) => Save(category);
    }
}
