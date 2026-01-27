using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Internal;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.WindowsForm.Forms.CreateButtonForm;
using Market.WindowsForm.Forms.FilterButtonForm;
using Market.WindowsForm.Forms.UpdateButtonForm;
using System.ComponentModel;


namespace Market.WindowsForm.Controls
{
    public partial class Sales : UserControl
    {
        private readonly ServiceFactory _serviceFactory;
        private readonly ISaleService _saleService;

        public Sales()
        {
            InitializeComponent();

            _serviceFactory = new ServiceFactory();
            _saleService = _serviceFactory.CreateSaleService();

            this.Load += Sales_Load;
        }

        private void Sales_Load(object? sender, EventArgs e)
        {
            LoadSales();
        }

        private void LoadSales()
        {
            try
            {
                var query = new SaleQuery();
                List<SaleModel> sales = _saleService.GetSales(query);

                var bs = new BindingSource
                {
                    DataSource = new BindingList<SaleModel>(sales)
                };

                SalesGridView.AutoGenerateColumns = true;
                SalesGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                SalesGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                SalesGridView.DataSource = bs;
                SalesGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load sales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            var createForm = new SalesCreateForm();
            createForm.FormClosed += (s, e) => LoadSales();
            createForm.ShowDialog();
        }

        private void deleteButton_Click(object? sender, EventArgs e)
        {
            DataGridViewRow? row = null;
            if (SalesGridView.SelectedRows.Count > 0)
                row = SalesGridView.SelectedRows[0];
            else
                row = SalesGridView.CurrentRow;

            if (row == null)
            {
                MessageBox.Show("No sale selected.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (row.DataBoundItem is not SaleModel sale)
            {
                MessageBox.Show("Selected item is not a valid sale.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to delete the sale '{sale.ReceiptId}'?",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes)
                return;

            try
            {
                _saleService.DeleteSale(sale);
                LoadSales();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete sale: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterButton_click(object sender, EventArgs e)
        {
            var filterForm = new SalesFilterForm();
            filterForm.FormClosed += (s, e) => LoadSales();
            filterForm.ShowDialog();
        }

        private void SalesGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow? row = null;
            if (SalesGridView.SelectedRows.Count > 0)
                row = SalesGridView.SelectedRows[0];
            else
                row = SalesGridView.CurrentRow;

            if (row == null)
            {
                MessageBox.Show("No sale selected.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (row.DataBoundItem is not SaleModel sale)
            {
                MessageBox.Show("Selected item is not a valid sale.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var updateForm = new SalesUpdateForm(sale.Id);
                updateForm.FormClosed += (s, e) => LoadSales();
                updateForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update sale: {ex.Message}", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void exportButton_Click(object sender, EventArgs e)
        {
            try
            {
                var success = Market.WindowsForm.Utils.XmlExporter.ExportDataGridViewToXml(SalesGridView, "Sales");
                if (success)
                    MessageBox.Show("Export completed successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
