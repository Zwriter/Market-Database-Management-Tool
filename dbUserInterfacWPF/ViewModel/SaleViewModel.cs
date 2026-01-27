using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.BusinessModel.Enums;
using System.Collections.ObjectModel;
using System.Windows;

namespace Market.WPF.ViewModel
{
    public class SaleViewModel : ViewModelBase
    {
        private readonly ISaleService _service;
        public ObservableCollection<SaleModel> Items { get; } = new();
        private SaleModel? _selected;
        public SaleModel? Selected { get => _selected; set => Set(ref _selected, value); }

        public SaleSortBy? SortBy { get; set; }
        public Market.BusinessModel.Enums.SortDirection SortDirection { get; set; } = Market.BusinessModel.Enums.SortDirection.Asc;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;

        public RelayCommand LoadCommand { get; }
        public RelayCommand CreateCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand SaveCommand { get; }

        public SaleViewModel(ISaleService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            LoadCommand = new RelayCommand(_ => Load());
            CreateCommand = new RelayCommand(_ => Create());
            DeleteCommand = new RelayCommand(_ => Delete(), _ => Selected != null);
            SaveCommand = new RelayCommand(_ => Save(), _ => Selected != null);
        }

        public void Load()
        {
            var q = new SaleQuery
            {
                SortBy = SortBy,
                SortDirection = SortDirection,
                Page = Page,
                PageSize = PageSize
            };
            Items.Clear();
            var list = _service.GetSales(q);
            foreach (var i in list) Items.Add(i);
        }

        public void Create()
        {
            var m = new SaleModel { ReceiptId = 0, ProductId = 0, Quantity = 1 };
            _service.CreateSale(m);
            Load();
        }

        public void Delete()
        {
            if (Selected == null) return;
            var ok = MessageBox.Show($"Delete sale {Selected.Id}?", "Confirm", MessageBoxButton.YesNo);
            if (ok != MessageBoxResult.Yes) return;
            _service.DeleteSale(Selected);
            Load();
        }

        public void Save()
        {
            if (Selected == null) return;
            _service.UpdateSale(Selected);
            Load();
        }
    }
}