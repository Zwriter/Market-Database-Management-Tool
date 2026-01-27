using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Internal;
using Market.BusinessModel.Models;

namespace Market.WindowsForm.Forms.UpdateButtonForm
{
    public partial class ClientsUpdateForm : Form
    {
        private readonly ServiceFactory _serviceFactory;
        private readonly IClientService _clientService;
        private readonly string _clientId;

        public ClientsUpdateForm(string clientID)
        {
            InitializeComponent();

            _serviceFactory = new ServiceFactory();
            _clientService = _serviceFactory.CreateClientService();

            _clientId = clientID;
            idTextBox.Text = clientID;

            this.Load += ClientsUpdateForm_Load;
        }

        private void ClientsUpdateForm_Load(object? sender, EventArgs e)
        {
            try
            {
                var client = _clientService.GetClientsById(_clientId);
                if (client != null)
                {
                    nameTextBox.Text = client.Name;
                    phoneTextBox.Text = client.PhoneNumber;
                    emailTextBox.Text = client.Email;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load client: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateButton_Click(object? sender, EventArgs e)
        {
            var name = nameTextBox.Text;
            var phone = phoneTextBox.Text;
            var email = emailTextBox.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name cannot be empty.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var updated = new ClientModel
                {
                    Id = _clientId,
                    Name = name,
                    PhoneNumber = phone,
                    Email = email
                };

                _clientService.UpdateClient(updated);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update client: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
