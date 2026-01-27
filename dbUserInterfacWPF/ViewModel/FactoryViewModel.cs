using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.BusinessModel.Enums;
using System.Collections.ObjectModel;
using System.Windows;

namespace Market.WPF.ViewModel
{
    public class FactoryViewModel : ViewModelBase
    {
        private readonly IFactoryService _service;
        public ObservableCollection<FactoryModel> Items { get; } = new();
        private FactoryModel? _selected;
        public FactoryModel? Selected { get => _selected; set => Set(ref _selected, value); }

        public string FilterName { get; set; } = string.Empty;
        public FactorySortBy? SortBy { get; set; }
        public Market.BusinessModel.Enums.SortDirection SortDirection { get; set; } = Market.BusinessModel.Enums.SortDirection.Asc;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;

        public RelayCommand LoadCommand { get; }
        public RelayCommand CreateCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand SaveCommand { get; }

        public FactoryViewModel(IFactoryService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            LoadCommand = new RelayCommand(_ => Load());
            CreateCommand = new RelayCommand(_ => Create());
            DeleteCommand = new RelayCommand(_ => Delete(), _ => Selected != null);
            SaveCommand = new RelayCommand(_ => Save(), _ => Selected != null);
        }

        public void Load()
        {
            var q = new FactoryQuery
            {
                SortBy = SortBy,
                SortDirection = SortDirection,
                Page = Page,
                PageSize = PageSize,
                FactoryName = string.IsNullOrWhiteSpace(FilterName) ? null : FilterName
            };

            Items.Clear();
            var list = _service.GetFactories(q);
            foreach (var i in list) Items.Add(i);
        }

        public void Create()
        {
            var m = new FactoryModel { FactoryName = "New factory" };
            _service.CreateFactory(m);
            Load();
        }

        public void Delete()
        {
            if (Selected == null) return;
            var ok = MessageBox.Show($"Delete factory {Selected.FactoryName}?", "Confirm", MessageBoxButton.YesNo);
            if (ok != MessageBoxResult.Yes) return;
            _service.DeleteFactory(Selected);
            Load();
        }

        public void Save()
        {
            if (Selected == null) return;
            _service.UpdateFactory(Selected);
            Load();
        }
    }
}