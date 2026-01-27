using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Internal;
using Market.BusinessModel.Models;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Market.WindowsForm.Forms
{
    public partial class ClientsCreateForm : Form
    {
        private readonly ServiceFactory _serviceFactory;
        private readonly IClientService _clientService;

        public ClientsCreateForm()
        {
            InitializeComponent();
            _serviceFactory = new ServiceFactory();
            _clientService = _serviceFactory.CreateClientService();
        }

        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            return Regex.IsMatch(phone.Trim(), @"^[\d\+\-\s\(\)]{5,20}$");
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try
            {
                var _ = new MailAddress(email.Trim());
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var name = nameTextBox.Text?.Trim();
            var phone = phoneTextBox.Text?.Trim();
            var email = emailTextBox.Text?.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Client name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nameTextBox.Focus();
                return;
            }

            if (!IsValidPhone(phone))
            {
                MessageBox.Show("Please enter a valid phone number (digits, +, -, spaces, parentheses).", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                phoneTextBox.Focus();
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                emailTextBox.Focus();
                return;
            }

            try
            {
                _clientService.CreateClient(new ClientModel
                {
                    Name = name,
                    PhoneNumber = phone,
                    Email = email
                });

                MessageBox.Show("Client created successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create client: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
