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
                var factories = _factory_service_get(query);

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

        private System.Collections.Generic.List<FactoryModel> _factory_service_get(FactoryQuery q)
        {
            return _factoryService.GetFactories(q);
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
                factoryComboBox.Focus();
                return;
            }

            if (categoryComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a category.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                categoryComboBox.Focus();
                return;
            }

            if (productComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a product.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                productComboBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(stockTextBox.Text))
            {
                MessageBox.Show("Please enter stock.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                stockTextBox.Focus();
                return;
            }

            if (!int.TryParse(stockTextBox.Text.Trim(), out int stock) || stock < 0)
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

            if (!decimal.TryParse(priceTextBox.Text.Trim(), out decimal price) || price < 0m)
            {
                MessageBox.Show("Please enter a valid non-negative price.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                priceTextBox.Focus();
                return;
            }

            var expiration = dateTimePicker1.Value.Date;
            if (expiration < DateTime.Today)
            {
                var ask = MessageBox.Show("Expiration date is in the past. Continue?", "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (ask != DialogResult.Yes)
                {
                    dateTimePicker1.Focus();
                    return;
                }
            }

            try
            {
                var factoryId = factoryComboBox.SelectedValue.ToString()!;
                var categoryId = categoryComboBox.SelectedValue.ToString()!;
                var productId = productComboBox.SelectedValue.ToString()!;

                var record = new RecordModel
                {
                    FactoryId = factoryId,
                    CategoryId = categoryId,
                    ProductId = productId,
                    Stock = stock,
                    Price = price,
                    ExpirationDate = dateTimePicker1.Value
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
