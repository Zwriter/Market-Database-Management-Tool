using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Internal;
using Market.BusinessModel.Models;


namespace Market.WindowsForm.Forms
{
    public partial class FactoriesCreateForm : Form
    {
        private readonly ServiceFactory _serviceFactory;
        private readonly IFactoryService _factoryService;

        public FactoriesCreateForm()
        {
            InitializeComponent();
            _serviceFactory = new ServiceFactory();
            _factoryService = _serviceFactory.CreateFactoryService();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text?.Trim();

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Factory name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            try
            {
                _factoryService.CreateFactory(new FactoryModel
                {
                    FactoryName = text
                });

                MessageBox.Show("Factory created successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create factory: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
