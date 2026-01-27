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
    public partial class CategoriesUpdateForm : Form
    {
        private readonly ServiceFactory _serviceFactory;
        private readonly ICategoryService _categoryService;
        private readonly string _categoryId;
        public CategoriesUpdateForm(string categoryID)
        {
            InitializeComponent();
            _serviceFactory = new ServiceFactory();
            _categoryService = _serviceFactory.CreateCategoryService();

            _categoryId = categoryID;

            idTextBox.Text = categoryID;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;
            if (!string.IsNullOrEmpty(text))
            {
                _categoryService.UpdateCategory(new CategoryModel
                {
                    Id = _categoryId,
                    CategoryName = text
                });
                this.Close();
            }
            else
            {
                MessageBox.Show($"Failed to load category:", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CategoriesUpdateForm_Load_1(object sender, EventArgs e)
        {
            try
            {
                var category = _categoryService.GetCategoriesById(_categoryId);
                if (category != null)
                {
                    textBox1.Text = category.CategoryName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load category: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
