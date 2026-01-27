using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Internal;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using System;
using System.Windows.Forms;

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
                return;
            }

            try
            {
                string clientId = clientComboBox.SelectedValue.ToString();

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

        // This is optional - remove if you don't need it
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clientComboBox.SelectedItem is ClientModel client)
            {
                string selectedId = client.Id;
                string selectedName = client.Name;
                // You can display this info somewhere or just remove this method
                // MessageBox.Show($"Selected: {selectedName} (ID: {selectedId})");
            }
        }
    }
}