using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Internal;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using System.Data;


namespace Market.WindowsForm.Forms.UpdateButtonForm
{
    public partial class SalesUpdateForm : Form
    {
        private readonly ServiceFactory _serviceFactory;
        private readonly ISaleService _saleService;
        private readonly IReceiptService _receiptService;
        private readonly IProductService _productService;
        private readonly string _saleId;

        public SalesUpdateForm(string saleID)
        {
            InitializeComponent();

            _serviceFactory = new ServiceFactory();
            _saleService = _serviceFactory.CreateSaleService();
            _receiptService = _serviceFactory.CreateReceiptService();
            _productService = _serviceFactory.CreateProductService();

            _saleId = saleID;
            idTextBox.Text = saleID;

            this.Load += SalesUpdateForm_Load;
        }

        private void SalesUpdateForm_Load(object? sender, EventArgs e)
        {
            LoadReceipts();
            LoadProducts();

            try
            {
                var sale = _saleService.GetSalesById(_saleId);
                if (sale != null)
                {
                    if (!string.IsNullOrEmpty(sale.ReceiptId))
                    {
                        var list = receiptComboBox.DataSource as System.Collections.IList;
                        if (list != null)
                        {
                            var match = list.Cast<object>()
                                            .FirstOrDefault(item => (item.GetType().GetProperty("Id")?.GetValue(item)?.ToString()) == sale.ReceiptId);
                            if (match != null)
                                receiptComboBox.SelectedItem = match;
                        }
                    }

                    if (!string.IsNullOrEmpty(sale.ProductId))
                    {
                        var list = productComboBox.DataSource as System.Collections.IList;
                        if (list != null)
                        {
                            var match = list.Cast<object>()
                                            .FirstOrDefault(item => (item.GetType().GetProperty("Id")?.GetValue(item)?.ToString()) == sale.ProductId);
                            if (match != null)
                                productComboBox.SelectedItem = match;
                        }
                    }

                    quantityTextBox.Text = sale.Quantity.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load sale: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReceipts()
        {
            try
            {
                var q = new ReceiptQuery();
                var receipts = _receiptService.GetReceipts(q);

                receiptComboBox.DisplayMember = "Id";
                receiptComboBox.ValueMember = "Id";
                receiptComboBox.DataSource = receipts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load receipts: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            try
            {
                var q = new ProductQuery();
                var products = _product_service_get(q);

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

        private System.Collections.Generic.List<ProductModel> _product_service_get(ProductQuery q)
        {
            return _productService.GetProducts(q);
        }

        private void updateButton_Click(object? sender, EventArgs e)
        {
            if (receiptComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a receipt.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (productComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a product.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(quantityTextBox.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity (positive integer).", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                quantityTextBox.Focus();
                return;
            }

            try
            {
                var receiptId = receiptComboBox.SelectedValue.ToString();
                var productId = productComboBox.SelectedValue.ToString();

                var updated = new SaleModel
                {
                    Id = _saleId,
                    ReceiptId = receiptId,
                    ProductId = productId,
                    Quantity = quantity
                };

                _saleService.UpdateSale(updated);

                MessageBox.Show("Sale updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update sale: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
