using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.BusinessModel.Enums;
using System.Collections.ObjectModel;
using System.Windows;


namespace Market.WPF.ViewModel
{
    public class ReceiptViewModel : ViewModelBase
    {
        private readonly IReceiptService _service;
        public ObservableCollection<ReceiptModel> Items { get; } = new();
        private ReceiptModel? _selected;
        public ReceiptModel? Selected { get => _selected; set => Set(ref _selected, value); }

        public int? FilterClientIdIndex { get; set; }
        public ReceiptSortBy? SortBy { get; set; }
        public Market.BusinessModel.Enums.SortDirection SortDirection { get; set; } = Market.BusinessModel.Enums.SortDirection.Asc;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;

        public RelayCommand LoadCommand { get; }
        public RelayCommand CreateCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand SaveCommand { get; }

        public ReceiptViewModel(IReceiptService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            LoadCommand = new RelayCommand(_ => Load());
            CreateCommand = new RelayCommand(_ => Create());
            DeleteCommand = new RelayCommand(_ => Delete(), _ => Selected != null);
            SaveCommand = new RelayCommand(_ => Save(), _ => Selected != null);
        }

        public void Load()
        {
            var q = new ReceiptQuery
            {
                SortBy = SortBy,
                SortDirection = SortDirection,
                Page = Page,
                PageSize = PageSize
            };
            Items.Clear();
            var list = _service.GetReceipts(q);
            foreach (var i in list) Items.Add(i);
        }

        public void Create()
        {
            var m = new ReceiptModel { ClientId = 0 };
            _service.CreateReceipt(m);
            Load();
        }

        public void Delete()
        {
            if (Selected == null) return;
            var ok = MessageBox.Show($"Delete receipt {Selected.Id}?", "Confirm", MessageBoxButton.YesNo);
            if (ok != MessageBoxResult.Yes) return;
            _service.DeleteReceipt(Selected);
            Load();
        }

        public void Save()
        {
            if (Selected == null) return;
            _service.UpdateReceipt(Selected);
            Load();
        }
    }
}