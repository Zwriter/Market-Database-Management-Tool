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
    public partial class FactoriesUpdateForm : Form
    {
        private readonly ServiceFactory _serviceFactory;
        private readonly IFactoryService _factoryService;
        private readonly string _factoryId;

        public FactoriesUpdateForm(string factoryId)
        {
            InitializeComponent();

            _serviceFactory = new ServiceFactory();
            _factoryService = _serviceFactory.CreateFactoryService();

            _factoryId = factoryId;
            idTextBox.Text = factoryId;

            this.Load += FactoriesUpdateForm_Load;
        }

        private void FactoriesUpdateForm_Load(object? sender, EventArgs e)
        {
            try
            {
                var factory = _factoryService.GetFactoryById(_factoryId);
                if (factory != null)
                {
                    textBox1.Text = factory.FactoryName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load factory: {ex.Message}", "Error",
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
                    _factoryService.UpdateFactory(new FactoryModel
                    {
                        Id = _factoryId,
                        FactoryName = name
                    });
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update factory: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Factory name cannot be empty.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
