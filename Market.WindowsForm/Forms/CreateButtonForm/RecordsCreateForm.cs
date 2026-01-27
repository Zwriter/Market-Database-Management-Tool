using Market.BusinessModel.Internal;
using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;

namespace Market.WindowsForm.Forms.CreateButtonForm
{
    public partial class RecordsCreateForm : Form
    {
        private readonly ServiceFactory _serviceFactory;
        private readonly IFactoryService _factoryService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IRecordService _recordService;

        public RecordsCreateForm()
        {
            InitializeComponent();

            _serviceFactory = new ServiceFactory();
            _factoryService = _serviceFactory.CreateFactoryService();
            _categoryService = _serviceFactory.CreateCategoryService();
            _productService = _serviceFactory.CreateProductService();
            _recordService = _serviceFactory.CreateRecordService();

            LoadFactories();
            LoadCategories();
            LoadProducts();
        }

        private void LoadFactories()
        {
            try
            {
                var query = new FactoryQuery();
                var factories = _factoryService.GetFactories(query);

                factoryComboBox.DisplayMember = "FactoryName";
                factoryComboBox.ValueMember = "Id";
                factoryComboBox.DataSource = factories;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load factories: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            try
            {
                var query = new CategoryQuery();
                var categories = _categoryService.GetCategories(query);

                categoryComboBox.DisplayMember = "CategoryName";
                categoryComboBox.ValueMember = "Id";
                categoryComboBox.DataSource = categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load categories: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            try
            {
                var query = new ProductQuery();
                var products = _productService.GetProducts(query);

                productComboBox.DisplayMember = "ProductName";
                productComboBox.ValueMember = "Id";
                productComboBox.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load products: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveButton_Click(object? sender, EventArgs e)
        {
            if (factoryComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a factory.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (categoryComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a category.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (productComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a product.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(stockTextBox.Text))
            {
                MessageBox.Show("Please enter stock.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                stockTextBox.Focus();
                return;
            }

            if (!int.TryParse(stockTextBox.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Please enter a valid non-negative stock number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                stockTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(priceTextBox.Text))
            {
                MessageBox.Show("Please enter a price.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                priceTextBox.Focus();
                return;
            }

            if (!decimal.TryParse(priceTextBox.Text, out decimal price) || price < 0m)
            {
                MessageBox.Show("Please enter a valid non-negative price.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                priceTextBox.Focus();
                return;
            }

            try
            {
                var factoryId = factoryComboBox.SelectedValue.ToString()!;
                var categoryId = categoryComboBox.SelectedValue.ToString()!;
                var productId = productComboBox.SelectedValue.ToString()!;
                var expiration = dateTimePicker1.Value;

                var record = new RecordModel
                {
                    FactoryId = factoryId,
                    CategoryId = categoryId,
                    ProductId = productId,
                    Stock = stock,
                    Price = price,
                    ExpirationDate = expiration
                };

                _recordService.CreateRecord(record);

                MessageBox.Show("Record created successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create record: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
