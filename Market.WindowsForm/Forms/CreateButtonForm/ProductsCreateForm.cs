using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Internal;
using Market.BusinessModel.Models;


namespace Market.WindowsForm.Forms
{
    public partial class ProductsCreateForm : Form
    {
        private readonly ServiceFactory _serviceProduct;
        private readonly IProductService _categoryService;

        public ProductsCreateForm()
        {
            InitializeComponent();
            _serviceProduct = new ServiceFactory();
            _categoryService = _serviceProduct.CreateProductService();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;
            if (!string.IsNullOrEmpty(text))
            {
                _categoryService.CreateProduct(new ProductModel
                {
                    ProductName = text
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
