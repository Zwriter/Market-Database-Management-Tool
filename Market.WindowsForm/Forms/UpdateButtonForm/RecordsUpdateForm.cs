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
    public partial class RecordsUpdateForm : Form
    {
        private readonly ServiceFactory _serviceFactory;
        private readonly IFactoryService _factoryService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IRecordService _recordService;
        private readonly string _recordId;

        public RecordsUpdateForm(string recordID)
        {
            InitializeComponent();

            _serviceFactory = new ServiceFactory();
            _factoryService = _serviceFactory.CreateFactoryService();
            _categoryService = _serviceFactory.CreateCategoryService();
            _productService = _serviceFactory.CreateProductService();
            _recordService = _serviceFactory.CreateRecordService();

            _recordId = recordID;
            idTextBox.Text = recordID;

            this.Load += RecordsUpdateForm_Load;
        }

        private void RecordsUpdateForm_Load(object? sender, EventArgs e)
        {
            LoadFactories();
            LoadCategories();
            LoadProducts();

            try
            {
                var record = _recordService.GetRecordsById(_recordId);
                if (record == null)
                    return;

                if (!string.IsNullOrEmpty(record.FactoryId) && factoryComboBox.DataSource is System.Collections.IList fList)
                {
                    var match = fList.Cast<object>()
                                     .FirstOrDefault(item => (item.GetType().GetProperty("Id")?.GetValue(item)?.ToString()) == record.FactoryId);
                    if (match != null) factoryComboBox.SelectedItem = match;
                }

                if (!string.IsNullOrEmpty(record.CategoryId) && categoryComboBox.DataSource is System.Collections.IList cList)
                {
                    var match = cList.Cast<object>()
                                     .FirstOrDefault(item => (item.GetType().GetProperty("Id")?.GetValue(item)?.ToString()) == record.CategoryId);
                    if (match != null) categoryComboBox.SelectedItem = match;
                }

                if (!string.IsNullOrEmpty(record.ProductId) && productComboBox.DataSource is System.Collections.IList pList)
                {
                    var match = pList.Cast<object>()
                                     .FirstOrDefault(item => (item.GetType().GetProperty("Id")?.GetValue(item)?.ToString()) == record.ProductId);
                    if (match != null) productComboBox.SelectedItem = match;
                }

                stockTextBox.Text = record.Stock.ToString();
                priceTextBox.Text = record.Price.ToString();
                dateTimePicker1.Value = record.ExpirationDate != default ? record.ExpirationDate : DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load record: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFactories()
        {
            try
            {
                var q = new FactoryQuery();
                var list = _factoryService.GetFactories(q);

                factoryComboBox.DisplayMember = "FactoryName";
                factoryComboBox.ValueMember = "Id";
                factoryComboBox.DataSource = list;
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
                var q = new CategoryQuery();
                var list = _category_service_get(q);

                categoryComboBox.DisplayMember = "CategoryName";
                categoryComboBox.ValueMember = "Id";
                categoryComboBox.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load categories: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private System.Collections.Generic.List<CategoryModel> _category_service_get(CategoryQuery q)
        {
            return _categoryService.GetCategories(q);
        }

        private void LoadProducts()
        {
            try
            {
                var q = new ProductQuery();
                var list = _productService.GetProducts(q);

                productComboBox.DisplayMember = "ProductName";
                productComboBox.ValueMember = "Id";
                productComboBox.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load products: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateButton_Click(object? sender, EventArgs e)
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

            if (!int.TryParse(stockTextBox.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Please enter a valid non-negative stock number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                stockTextBox.Focus();
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
                var factoryId = factoryComboBox.SelectedValue.ToString();
                var categoryId = categoryComboBox.SelectedValue.ToString();
                var productId = productComboBox.SelectedValue.ToString();
                var expiration = dateTimePicker1.Value;

                var updated = new RecordModel
                {
                    Id = _recordId,
                    FactoryId = factoryId,
                    CategoryId = categoryId,
                    ProductId = productId,
                    Stock = stock,
                    Price = price,
                    ExpirationDate = expiration
                };

                _recordService.UpdateRecord(updated);

                MessageBox.Show("Record updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update record: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
