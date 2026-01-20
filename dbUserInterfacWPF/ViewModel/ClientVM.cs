using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.BusinessModel.Enums;
using System.Collections.ObjectModel;
using System.Windows;

namespace Market.WPF.ViewModel
{
    public class ClientViewModel : ViewModelBase
    {
        private readonly IClientService _service;

        public ObservableCollection<ClientModel> Items { get; } = new();
        private ClientModel? _selected;
        public ClientModel? Selected { get => _selected; set => Set(ref _selected, value); }

        public string FilterName { get; set; } = string.Empty;
        public string FilterEmail { get; set; } = string.Empty;

        public ClientSortBy? SortBy { get; set; }
        public Market.BusinessModel.Enums.SortDirection SortDirection { get; set; } = Market.BusinessModel.Enums.SortDirection.Asc;

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;

        public RelayCommand LoadCommand { get; }
        public RelayCommand ApplyFilterCommand { get; }
        public RelayCommand CreateCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand SaveCommand { get; }
        public RelayCommand NextPageCommand { get; }
        public RelayCommand PrevPageCommand { get; }

        public ClientViewModel(IClientService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            LoadCommand = new RelayCommand(_ => Load());
            ApplyFilterCommand = new RelayCommand(_ => { Page = 1; Load(); });
            CreateCommand = new RelayCommand(_ => Create());
            DeleteCommand = new RelayCommand(_ => Delete(), _ => Selected != null);
            SaveCommand = new RelayCommand(_ => Save(), _ => Selected != null);
            NextPageCommand = new RelayCommand(_ => { Page++; Load(); });
            PrevPageCommand = new RelayCommand(_ => { if (Page > 1) Page--; Load(); });
        }

        public void Load()
        {
            var q = new ClientQuery
            {
                Name = string.IsNullOrWhiteSpace(FilterName) ? null : FilterName,
                Email = string.IsNullOrWhiteSpace(FilterEmail) ? null : FilterEmail,
                SortBy = SortBy,
                SortDirection = SortDirection,
                Page = Page,
                PageSize = PageSize
            };

            Items.Clear();
            var list = _service.GetClients(q);
            foreach (var item in list) Items.Add(item);
        }

        public void Create()
        {
            var newItem = new ClientModel
            {
                Name = "New client",
                Email = string.Empty,
                PhoneNumber = string.Empty
            };
            _service.CreateClient(newItem);
            Load();
        }

        public void Delete()
        {
            if (Selected == null) return;
            var ok = MessageBox.Show($"Delete client {Selected.Name}?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (ok != MessageBoxResult.Yes) return;
            _service.DeleteClient(Selected);
            Load();
        }

        public void Save()
        {
            if (Selected == null) return;
            _service.UpdateClient(Selected);
            Load();
        }
    }
}