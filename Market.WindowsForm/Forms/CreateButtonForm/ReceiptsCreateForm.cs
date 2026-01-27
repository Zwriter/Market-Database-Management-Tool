using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Internal;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;

namespace Market.WindowsForm.Forms.CreateButtonForm
{
    public partial class ReceiptsCreateForm : Form
    {
        private readonly ServiceFactory _serviceFactory;
        private readonly IClientService _clientService;
        private readonly IReceiptService _receiptService;

        public ReceiptsCreateForm()
        {
            InitializeComponent();
            _serviceFactory = new ServiceFactory();
            _clientService = _serviceFactory.CreateClientService();
            _receiptService = _serviceFactory.CreateReceiptService();

            LoadClients();
        }

        private void LoadClients()
        {
            try
            {
                var query = new ClientQuery();
                var clients = _clientService.GetClients(query);

                clientComboBox.DisplayMember = "Name";
                clientComboBox.ValueMember = "Id";
                clientComboBox.DataSource = clients;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load clients: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (clientComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a client.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clientComboBox.Focus();
                return;
            }

            try
            {
                string clientId = clientComboBox.SelectedValue.ToString()!;

                var receipt = new ReceiptModel
                {
                    ClientId = clientId,
                    CreatedAt = DateTime.Now
                };

                _receiptService.CreateReceipt(receipt);

                MessageBox.Show("Receipt created successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create receipt: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}