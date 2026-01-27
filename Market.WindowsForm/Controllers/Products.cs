using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Internal;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.WindowsForm.Forms;
using Market.WindowsForm.Forms.UpdateButtonForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market.WindowsForm.Controls
{
    public partial class Products : UserControl
    {
        private readonly ServiceFactory _serviceFactory;
        private readonly IProductService _productService;

        public Products()
        {
            InitializeComponent();

            _serviceFactory = new ServiceFactory();
            _productService = _serviceFactory.CreateProductService();

            this.Load += Products_Load;
        }

        private void Products_Load(object? sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                var query = new ProductQuery();
                List<ProductModel> products = _productService.GetProducts(query);

                var bs = new BindingSource
                {
                    DataSource = new BindingList<ProductModel>(products)
                };

                ProductsGridView.AutoGenerateColumns = true;
                ProductsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ProductsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                ProductsGridView.DataSource = bs;
                ProductsGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            var createForm = new ProductsCreateForm();
            createForm.FormClosed += (s, e) => LoadProducts();
            createForm.ShowDialog();
        }

        private void deleteButton_Click(object? sender, EventArgs e)
        {
            DataGridViewRow? row = null;
            if (ProductsGridView.SelectedRows.Count > 0)
                row = ProductsGridView.SelectedRows[0];
            else
                row = ProductsGridView.CurrentRow;

            if (row == null)
            {
                MessageBox.Show("No product selected.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (row.DataBoundItem is not ProductModel product)
            {
                MessageBox.Show("Selected item is not a valid product.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to delete the product '{product.ProductName}'?",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes)
                return;

            try
            {
                _productService.DeleteProduct(product);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow? row = null;
            if (ProductsGridView.SelectedRows.Count > 0)
                row = ProductsGridView.SelectedRows[0];
            else
                row = ProductsGridView.CurrentRow;

            if (row == null)
            {
                MessageBox.Show("No product selected.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (row.DataBoundItem is not ProductModel product)
            {
                MessageBox.Show("Selected item is not a valid product.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var updateForm = new ProductsUpdateForm(product.Id);
                updateForm.FormClosed += (s, e) => LoadProducts();
                updateForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update product: {ex.Message}", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterButton_click(object sender, EventArgs e)
        {
            var filterForm = new ProductsFilterForm();
            filterForm.FormClosed += (s, e) => LoadProducts();
            filterForm.ShowDialog();
        }
    }
}
