using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.BusinessModel.Enums;
using System.Collections.ObjectModel;
using System.Windows;


namespace Market.WPF.ViewModel
{
    public class RecordViewModel : ViewModelBase
    {
        private readonly IRecordService _service;
        public ObservableCollection<RecordModel> Items { get; } = new();
        private RecordModel? _selected;
        public RecordModel? Selected { get => _selected; set => Set(ref _selected, value); }

        public string? FilterCategoryId { get; set; }
        public string? FilterFactoryId { get; set; }
        public RecordSortBy? SortBy { get; set; }
        public Market.BusinessModel.Enums.SortDirection SortDirection { get; set; } = Market.BusinessModel.Enums.SortDirection.Asc;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;

        public RelayCommand LoadCommand { get; }
        public RelayCommand CreateCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand SaveCommand { get; }

        public RecordViewModel(IRecordService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            LoadCommand = new RelayCommand(_ => Load());
            CreateCommand = new RelayCommand(_ => Create());
            DeleteCommand = new RelayCommand(_ => Delete(), _ => Selected != null);
            SaveCommand = new RelayCommand(_ => Save(), _ => Selected != null);
        }

        public void Load()
        {
            var q = new RecordQuery
            {
                CategoryId = FilterCategoryId,
                FactoryId = FilterFactoryId,
                SortBy = SortBy,
                SortDirection = SortDirection,
                Page = Page,
                PageSize = PageSize
            };
            Items.Clear();
            var list = _service.GetRecords(q);
            foreach (var i in list) Items.Add(i);
        }

        public void Create()
        {
            var m = new RecordModel { Stock = 0, Price = 0m };
            _service.CreateRecord(m);
            Load();
        }

        public void Delete()
        {
            if (Selected == null) return;
            var ok = MessageBox.Show($"Delete record {Selected.Id}?", "Confirm", MessageBoxButton.YesNo);
            if (ok != MessageBoxResult.Yes) return;
            _service.DeleteRecord(Selected);
            Load();
        }

        public void Save()
        {
            if (Selected == null) return;
            _service.UpdateRecord(Selected);
            Load();
        }
    }
}