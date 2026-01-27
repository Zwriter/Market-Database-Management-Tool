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
    public partial class Receipts : UserControl
    {
        private readonly ServiceFactory _serviceFactory;
        private readonly IReceiptService _receiptService;

        public Receipts()
        {
            InitializeComponent();

            _serviceFactory = new ServiceFactory();
            _receiptService = _serviceFactory.CreateReceiptService();

            this.Load += Receipts_Load;
        }

        private void Receipts_Load(object? sender, EventArgs e)
        {
            LoadReceipts();
        }

        private void LoadReceipts()
        {
            try
            {
                var query = new ReceiptQuery();
                List<ReceiptModel> receipts = _receiptService.GetReceipts(query);

                var bs = new BindingSource
                {
                    DataSource = new BindingList<ReceiptModel>(receipts)
                };

                ReceiptsGridView.AutoGenerateColumns = true;
                ReceiptsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ReceiptsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                ReceiptsGridView.DataSource = bs;
                ReceiptsGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load receipts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            var createForm = new ReceiptsCreateForm();
            createForm.FormClosed += (s, e) => LoadReceipts();
            createForm.ShowDialog();
        }

        private void deleteButton_Click(object? sender, EventArgs e)
        {
            DataGridViewRow? row = null;
            if (ReceiptsGridView.SelectedRows.Count > 0)
                row = ReceiptsGridView.SelectedRows[0];
            else
                row = ReceiptsGridView.CurrentRow;

            if (row == null)
            {
                MessageBox.Show("No receipt selected.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (row.DataBoundItem is not ReceiptModel receipt)
            {
                MessageBox.Show("Selected item is not a valid receipt.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to delete the receipt '{receipt.ClientId}'?",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes)
                return;

            try
            {
                _receiptService.DeleteReceipt(receipt);
                LoadReceipts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete receipt: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow? row = null;
            if (ReceiptsGridView.SelectedRows.Count > 0)
                row = ReceiptsGridView.SelectedRows[0];
            else
                row = ReceiptsGridView.CurrentRow;

            if (row == null)
            {
                MessageBox.Show("No receipt selected.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (row.DataBoundItem is not ReceiptModel receipt)
            {
                MessageBox.Show("Selected item is not a valid receipt.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var updateForm = new ReceiptsUpdateForm(receipt.Id);
                updateForm.FormClosed += (s, e) => LoadReceipts();
                updateForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update receipt: {ex.Message}", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterButton_click(object sender, EventArgs e)
        {
            var filterForm = new ReceiptsFilterForm();
            filterForm.FormClosed += (s, e) => LoadReceipts();
            filterForm.ShowDialog();
        }
    }
}
