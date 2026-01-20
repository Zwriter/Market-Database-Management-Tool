using System.Collections.ObjectModel;

namespace Market.WPF.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        public ObservableCollection<KeyValuePair<string, decimal>> SalesByCategory { get; } = new();
        public ObservableCollection<KeyValuePair<string, int>> StockByFactory { get; } = new();

        public RelayCommand LoadCommand { get; }

        public HomeViewModel()
        {
            LoadCommand = new RelayCommand(_ => Load());
        }

        private void Load()
        {
            SalesByCategory.Clear();
            SalesByCategory.Add(new KeyValuePair<string, decimal>("Electronics", 12000));
            SalesByCategory.Add(new KeyValuePair<string, decimal>("Home Appliances", 8000));

            StockByFactory.Clear();
            StockByFactory.Add(new KeyValuePair<string, int>("Samsung", 120));
            StockByFactory.Add(new KeyValuePair<string, int>("Dell", 40));
        }
    }
}