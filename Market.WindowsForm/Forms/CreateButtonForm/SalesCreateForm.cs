using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Internal;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;

namespace Market.WindowsForm.Forms.CreateButtonForm
{
    public partial class SalesCreateForm : Form
    {
        private readonly ServiceFactory _serviceFactory;
        private readonly IReceiptService _receiptService;
        private readonly IProductService _productService;
        private readonly ISaleService _saleService;

        public SalesCreateForm()
        {
            InitializeComponent();

            _serviceFactory = new ServiceFactory();
            _receiptService = _serviceFactory.CreateReceiptService();
            _productService = _serviceFactory.CreateProductService();
            _saleService = _serviceFactory.CreateSaleService();

            LoadReceipts();
            LoadProducts();
        }

        private void LoadReceipts()
        {
            try
            {
                var query = new ReceiptQuery();
                var receipts = _receiptService.GetReceipts(query);

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

        private void saveButton_Click(object sender, EventArgs e)
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

            if (string.IsNullOrWhiteSpace(quantityTextBox.Text))
            {
                MessageBox.Show("Please enter a quantity.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                quantityTextBox.Focus();
                return;
            }

            if (!int.TryParse(quantityTextBox.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity (positive number).", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                quantityTextBox.Focus();
                return;
            }

            try
            {
                string receiptId = receiptComboBox.SelectedValue.ToString();
                string productId = productComboBox.SelectedValue.ToString();

                var sale = new SaleModel
                {
                    ReceiptId = receiptId,
                    ProductId = productId,
                    Quantity = quantity
                };

                _saleService.CreateSale(sale);

                MessageBox.Show("Sale created successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create sale: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
