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

namespace Market.WindowsForm.Forms
{
    public partial class CategoriesCreateForm : Form
    {
        private readonly ServiceFactory _serviceFactory;
        private readonly ICategoryService _categoryService;

        public CategoriesCreateForm()
        {
            InitializeComponent();
            _serviceFactory = new ServiceFactory();
            _categoryService = _serviceFactory.CreateCategoryService();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;
            if (!string.IsNullOrEmpty(text))
            {
                _categoryService.CreateCategory(new CategoryModel
                {
                    CategoryName = text
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
