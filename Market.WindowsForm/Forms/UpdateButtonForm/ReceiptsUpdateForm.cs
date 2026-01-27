using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Internal;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market.WindowsForm.Forms.UpdateButtonForm
{
    public partial class ReceiptsUpdateForm : Form
    {
        private readonly ServiceFactory _serviceFactory;
        private readonly IReceiptService _receiptService;
        private readonly IClientService _clientService;
        private readonly string _receiptId;

        public ReceiptsUpdateForm(string receiptID)
        {
            InitializeComponent();

            _serviceFactory = new ServiceFactory();
            _receiptService = _serviceFactory.CreateReceiptService();
            _clientService = _serviceFactory.CreateClientService();

            _receiptId = receiptID;
            idTextBox.Text = receiptID;

            this.Load += ReceiptsUpdateForm_Load;
        }

        private void ReceiptsUpdateForm_Load(object? sender, EventArgs e)
        {
            LoadClients();

            try
            {
                var receipt = _receipt_service_get();
                if (receipt != null)
                {
                    if (!string.IsNullOrEmpty(receipt.ClientId))
                    {
                        var list = clientComboBox.DataSource as System.Collections.IList;
                        if (list != null)
                        {
                            var match = list.Cast<object>()
                                            .FirstOrDefault(item => (item.GetType().GetProperty("Id")?.GetValue(item)?.ToString()) == receipt.ClientId);
                            if (match != null)
                                clientComboBox.SelectedItem = match;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load receipt: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ReceiptModel _receipt_service_get()
        {
            try
            {
                return _receiptService.GetReceiptsById(_receiptId);
            }
            catch
            {
                return null;
            }
        }

        private void LoadClients()
        {
            try
            {
                var q = new ClientQuery();
                var clients = _clientService.GetClients(q);

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

        private void updateButton_Click(object? sender, EventArgs e)
        {
            if (clientComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a client.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var clientId = clientComboBox.SelectedValue.ToString();

                var updated = new ReceiptModel
                {
                    Id = _receiptId,
                    ClientId = clientId
                };

                _receiptService.UpdateReceipt(updated);

                MessageBox.Show("Receipt updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update receipt: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
