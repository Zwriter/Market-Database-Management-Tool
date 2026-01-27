using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Internal;
using Market.BusinessModel.Models;


namespace Market.WindowsForm.Forms
{
    public partial class ProductsCreateForm : Form
    {
        private readonly ServiceFactory _serviceProduct;
        private readonly IProductService _productService;

        public ProductsCreateForm()
        {
            InitializeComponent();
            _serviceProduct = new ServiceFactory();
            _productService = _serviceProduct.CreateProductService();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text?.Trim();

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Product name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            try
            {
                _productService.CreateProduct(new ProductModel
                {
                    ProductName = text
                });

                MessageBox.Show("Product created successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create product: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
