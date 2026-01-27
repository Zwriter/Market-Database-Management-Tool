using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Internal;
using Market.BusinessModel.Models;


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
            var text = textBox1.Text?.Trim();

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Category name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            try
            {
                _categoryService.CreateCategory(new CategoryModel
                {
                    CategoryName = text
                });

                MessageBox.Show("Category created successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create category: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
