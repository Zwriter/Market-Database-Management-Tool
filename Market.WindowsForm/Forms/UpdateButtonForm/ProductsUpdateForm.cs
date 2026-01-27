using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Internal;
using Market.BusinessModel.Models;
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
    public partial class ProductsUpdateForm : Form
    {
        private readonly ServiceFactory _serviceFactory;
        private readonly IProductService _productService;
        private readonly string _productId;

        public ProductsUpdateForm(string productId)
        {
            InitializeComponent();

            _serviceFactory = new ServiceFactory();
            _productService = _serviceFactory.CreateProductService();

            _productId = productId;
            idTextBox.Text = productId;

            this.Load += ProductsUpdateForm_Load;
        }

        private void ProductsUpdateForm_Load(object? sender, EventArgs e)
        {
            try
            {
                var product = _productService.GetProductsById(_productId);
                if (product != null)
                {
                    textBox1.Text = product.ProductName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load product: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateButton_Click(object? sender, EventArgs e)
        {
            var name = textBox1.Text;
            if (!string.IsNullOrEmpty(name))
            {
                try
                {
                    _productService.UpdateProduct(new ProductModel
                    {
                        Id = _productId,
                        ProductName = name
                    });
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update product: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Product name cannot be empty.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
