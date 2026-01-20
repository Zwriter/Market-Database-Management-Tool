using System.Windows.Input;

namespace Market.WPF.ViewModel
{
    public class NavigationVM : ViewModelBase
    {
        private ViewModelBase? _current;
        public ViewModelBase? Current
        {
            get => _current;
            set => Set(ref _current, value);
        }

        public ICommand ShowHomeCommand { get; }
        public ICommand ShowClientsCommand { get; }
        public ICommand ShowProductsCommand { get; }
        public ICommand ShowCategoriesCommand { get; }
        public ICommand ShowReceiptsCommand { get; }
        public ICommand ShowRecordsCommand { get; }
        public ICommand ShowSalesCommand { get; }
        public ICommand ShowFactoriesCommand { get; }

        public NavigationVM(
            HomeViewModel home,
            ClientViewModel clients,
            ProductViewModel products,
            CategoryViewModel categories,
            ReceiptViewModel receipts,
            RecordViewModel records,
            SaleViewModel sales,
            FactoryViewModel factories)
        {
            ShowHomeCommand = new RelayCommand(_ => Current = home);
            ShowClientsCommand = new RelayCommand(_ => Current = clients);
            ShowProductsCommand = new RelayCommand(_ => Current = products);
            ShowCategoriesCommand = new RelayCommand(_ => Current = categories);
            ShowReceiptsCommand = new RelayCommand(_ => Current = receipts);
            ShowRecordsCommand = new RelayCommand(_ => Current = records);
            ShowSalesCommand = new RelayCommand(_ => Current = sales);
            ShowFactoriesCommand = new RelayCommand(_ => Current = factories);

            Current = home;
        }
    }
}