using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.BusinessModel.Enums;
using System.Collections.ObjectModel;
using System.Windows;

namespace Market.WPF.ViewModel
{
    public class CategoryViewModel : ViewModelBase
    {
        private readonly ICategoryService _service;
        public ObservableCollection<CategoryModel> Items { get; } = new();
        private CategoryModel? _selected;
        public CategoryModel? Selected { get => _selected; set => Set(ref _selected, value); }

        public string FilterName { get; set; } = string.Empty;
        public CategorySortBy? SortBy { get; set; }
        public Market.BusinessModel.Enums.SortDirection SortDirection { get; set; } = Market.BusinessModel.Enums.SortDirection.Asc;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;

        public RelayCommand LoadCommand { get; }
        public RelayCommand CreateCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand SaveCommand { get; }

        public CategoryViewModel(ICategoryService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            LoadCommand = new RelayCommand(_ => Load());
            CreateCommand = new RelayCommand(_ => Create());
            DeleteCommand = new RelayCommand(_ => Delete(), _ => Selected != null);
            SaveCommand = new RelayCommand(_ => Save(), _ => Selected != null);
        }

        public void Load()
        {
            var q = new CategoryQuery
            {
                SortBy = SortBy,
                SortDirection = SortDirection,
                Page = Page,
                PageSize = PageSize,
                CategoryName = string.IsNullOrWhiteSpace(FilterName) ? null : FilterName
            };

            Items.Clear();
            var list = _service.GetCategories(q);
            foreach (var i in list) Items.Add(i);
        }

        public void Create()
        {
            var m = new CategoryModel { CategoryName = "New category" };
            _service.CreateCategory(m);
            Load();
        }

        public void Delete()
        {
            if (Selected == null) return;
            var ok = MessageBox.Show($"Delete category {Selected.CategoryName}?", "Confirm", MessageBoxButton.YesNo);
            if (ok != MessageBoxResult.Yes) return;
            _service.DeleteCategory(Selected);
            Load();
        }

        public void Save()
        {
            if (Selected == null) return;
            _service.UpdateCategory(Selected);
            Load();
        }
    }
}