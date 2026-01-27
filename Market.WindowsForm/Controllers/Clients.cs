using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Internal;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.WindowsForm.Forms;
using Market.WindowsForm.Forms.UpdateButtonForm;
using System.ComponentModel;


namespace Market.WindowsForm.Controls
{
    public partial class Clients : UserControl
    {
        private readonly ServiceFactory _serviceFactory;
        private readonly IClientService _clientService;

        public Clients()
        {
            InitializeComponent();

            _serviceFactory = new ServiceFactory();
            _clientService = _serviceFactory.CreateClientService();

            this.Load += Clients_Load;
        }

        private void Clients_Load(object? sender, EventArgs e)
        {
            LoadClients();
        }

        private void LoadClients()
        {
            try
            {
                var query = new ClientQuery();
                List<ClientModel> clients = _clientService.GetClients(query);

                var bs = new BindingSource
                {
                    DataSource = new BindingList<ClientModel>(clients)
                };

                ClientsGridView.AutoGenerateColumns = true;
                ClientsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ClientsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                ClientsGridView.DataSource = bs;
                ClientsGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load clients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            var createForm = new ClientsCreateForm();
            createForm.FormClosed += (s, e) => LoadClients();
            createForm.ShowDialog();
        }

        private void deleteButton_Click(object? sender, EventArgs e)
        {
            DataGridViewRow? row = null;
            if (ClientsGridView.SelectedRows.Count > 0)
                row = ClientsGridView.SelectedRows[0];
            else
                row = ClientsGridView.CurrentRow;

            if (row == null)
            {
                MessageBox.Show("No client selected.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (row.DataBoundItem is not ClientModel client)
            {
                MessageBox.Show("Selected item is not a valid client.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to delete the client '{client.Name}'?",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes)
                return;

            try
            {
                _clientService.DeleteClient(client);
                LoadClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterButton_click(object sender, EventArgs e)
        {
            var filterForm = new ClientsFilterForm();
            filterForm.FormClosed += (s, e) => LoadClients();
            filterForm.ShowDialog();
        }

        private void ClientsGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow? row = null;
            if (ClientsGridView.SelectedRows.Count > 0)
                row = ClientsGridView.SelectedRows[0];
            else
                row = ClientsGridView.CurrentRow;

            if (row == null)
            {
                MessageBox.Show("No client selected.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (row.DataBoundItem is not ClientModel client)
            {
                MessageBox.Show("Selected item is not a valid client.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var updateForm = new ClientsUpdateForm(client.Id);
                updateForm.FormClosed += (s, e) => LoadClients();
                updateForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update client: {ex.Message}", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {

        }
    }
}
