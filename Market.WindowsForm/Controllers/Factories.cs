using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Internal;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.WindowsForm.Forms;
using Market.WindowsForm.Forms.UpdateButtonForm;
using System.ComponentModel;


namespace Market.WindowsForm.Controls
{
    public partial class Factories : UserControl
    {
        private readonly ServiceFactory _serviceFactory;
        private readonly IFactoryService _factoryService;

        public Factories()
        {
            InitializeComponent();

            _serviceFactory = new ServiceFactory();
            _factoryService = _serviceFactory.CreateFactoryService();

            this.Load += Factories_Load;
        }

        private void Factories_Load(object? sender, EventArgs e)
        {
            LoadFactories();
        }

        private void LoadFactories()
        {
            try
            {
                var query = new FactoryQuery();
                List<FactoryModel> factories = _factoryService.GetFactories(query);

                var bs = new BindingSource
                {
                    DataSource = new BindingList<FactoryModel>(factories)
                };

                FactoriesGridView.AutoGenerateColumns = true;
                FactoriesGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                FactoriesGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                FactoriesGridView.DataSource = bs;
                FactoriesGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load factories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            var createForm = new FactoriesCreateForm();
            createForm.FormClosed += (s, e) => LoadFactories();
            createForm.ShowDialog();
        }

        private void deleteButton_Click(object? sender, EventArgs e)
        {
            DataGridViewRow? row = null;
            if (FactoriesGridView.SelectedRows.Count > 0)
                row = FactoriesGridView.SelectedRows[0];
            else
                row = FactoriesGridView.CurrentRow;

            if (row == null)
            {
                MessageBox.Show("No factory selected.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (row.DataBoundItem is not FactoryModel factory)
            {
                MessageBox.Show("Selected item is not a valid factory.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to delete the factory '{factory.FactoryName}'?",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes)
                return;

            try
            {
                _factoryService.DeleteFactory(factory);
                LoadFactories();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete factory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow? row = null;
            if (FactoriesGridView.SelectedRows.Count > 0)
                row = FactoriesGridView.SelectedRows[0];
            else
                row = FactoriesGridView.CurrentRow;

            if (row == null)
            {
                MessageBox.Show("No factory selected.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (row.DataBoundItem is not FactoryModel factory)
            {
                MessageBox.Show("Selected item is not a valid factory.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var updateForm = new FactoriesUpdateForm(factory.Id);
                updateForm.FormClosed += (s, e) => LoadFactories();
                updateForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update factory: {ex.Message}", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterButton_click(object sender, EventArgs e)
        {
            var filterForm = new FactoriesFilterForn();
            filterForm.FormClosed += (s, e) => LoadFactories();
            filterForm.ShowDialog();
        }
    }
}
