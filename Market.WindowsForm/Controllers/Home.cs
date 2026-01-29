using Market.WindowsForm.Utils;
using System.Data;


namespace Market.WindowsForm.Controls
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object? sender, EventArgs e)
        {
            LoadTopProducts();
            LoadEarnings();
        }

        private void LoadEarnings()
        {
            try
            {
                decimal earnings = ChartDataProvider.GetCurrentMonthEarnings();
                string text = $"Earnings: {earnings:C}";
                
                profitLabel.Text = text;

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"LoadEarnings failed: {ex}");
            }
        }

        private void LoadTopProducts()
        {
            try
            {
                var top = ChartDataProvider.GetTopProducts(3);

                var dt = new DataTable();
                dt.Columns.Add("Product", typeof(string));
                dt.Columns.Add("Quantity", typeof(int));

                foreach (var kv in top)
                {
                    var row = dt.NewRow();
                    row["Product"] = kv.Key;
                    row["Quantity"] = kv.Value;
                    dt.Rows.Add(row);
                }

                topProductsGridView.AutoGenerateColumns = true;
                topProductsGridView.DataSource = dt;
                topProductsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                topProductsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load top products: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
