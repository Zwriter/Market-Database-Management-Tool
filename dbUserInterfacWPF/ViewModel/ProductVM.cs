using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.BusinessModel.Enums;
using System.Collections.ObjectModel;
using System.Windows;


namespace Market.WPF.ViewModel
{
    public class ProductViewModel : ViewModelBase
    {
        private readonly IProductService _service;
        public ObservableCollection<ProductModel> Items { get; } = new();
        private ProductModel? _selected;
        public ProductModel? Selected { get => _selected; set => Set(ref _selected, value); }

        public string FilterName { get; set; } = string.Empty;
        public ProductSortBy? SortBy { get; set; }
        public Market.BusinessModel.Enums.SortDirection SortDirection { get; set; } = Market.BusinessModel.Enums.SortDirection.Asc;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;

        public RelayCommand LoadCommand { get; }
        public RelayCommand CreateCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand SaveCommand { get; }

        public ProductViewModel(IProductService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            LoadCommand = new RelayCommand(_ => Load());
            CreateCommand = new RelayCommand(_ => Create());
            DeleteCommand = new RelayCommand(_ => Delete(), _ => Selected != null);
            SaveCommand = new RelayCommand(_ => Save(), _ => Selected != null);
        }

        public void Load()
        {
            var q = new ProductQuery
            {
                SortBy = SortBy,
                SortDirection = SortDirection,
                Page = Page,
                PageSize = PageSize,
                ProductName = string.IsNullOrWhiteSpace(FilterName) ? null : FilterName
            };

            Items.Clear();
            var list = _service.GetProducts(q);
            foreach (var i in list) Items.Add(i);
        }

        public void Create()
        {
            var m = new ProductModel { ProductName = "New product" };
            _service.CreateProduct(m);
            Load();
        }

        public void Delete()
        {
            if (Selected == null) return;
            var ok = MessageBox.Show($"Delete product {Selected.ProductName}?", "Confirm", MessageBoxButton.YesNo);
            if (ok != MessageBoxResult.Yes) return;
            _service.DeleteProduct(Selected);
            Load();
        }

        public void Save()
        {
            if (Selected == null) return;
            _service.UpdateProduct(Selected);
            Load();
        }
    }
}