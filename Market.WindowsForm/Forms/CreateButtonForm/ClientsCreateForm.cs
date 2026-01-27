using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Internal;
using Market.BusinessModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void saveButton_Click(object sender, EventArgs e)
        {
            var name = nameTextBox.Text;
            var phone = phoneTextBox.Text;
            var email = emailTextBox.Text;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(phone) && !string.IsNullOrEmpty(email))
            {
                _clientService.CreateClient(new ClientModel
                {
                    Name = name,
                    PhoneNumber = phone,
                    Email = email
                });
                this.Close();
            }
            else
            {
                return;
            }
        }
    }
}
