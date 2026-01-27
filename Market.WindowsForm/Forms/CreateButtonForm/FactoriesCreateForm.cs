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
    public partial class FactoriesCreateForm : Form
    {
        private readonly ServiceFactory _serviceFactory;
        private readonly IFactoryService _categoryService;

        public FactoriesCreateForm()
        {
            InitializeComponent();
            _serviceFactory = new ServiceFactory();
            _categoryService = _serviceFactory.CreateFactoryService();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;
            if (!string.IsNullOrEmpty(text))
            {
                _categoryService.CreateFactory(new FactoryModel
                {
                    FactoryName = text
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
