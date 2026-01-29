using Market.WindowsForm.Forms;
using Market.BusinessModel.Internal;
using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Requests;
using Market.BusinessModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Market.WindowsForm.Forms.UpdateButtonForm;
using Market.WindowsForm.Forms.FilterButtonForm;
using Market.WindowsForm.Utils;

namespace Market.WindowsForm.Controls
{
    public partial class Categories : UserControl
    {
        private readonly ServiceFactory _serviceFactory;
        private readonly ICategoryService _categoryService;

        public Categories()
        {
            InitializeComponent();

            _serviceFactory = new ServiceFactory();
            _categoryService = _serviceFactory.CreateCategoryService();

            this.Load += Categories_Load;
        }

        private void Categories_Load(object? sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            try
            {
                var query = new CategoryQuery();
                List<CategoryModel> categories = _categoryService.GetCategories(query);

                var bs = new BindingSource
                {
                    DataSource = new BindingList<CategoryModel>(categories)
                };

                CategoriesGridView.AutoGenerateColumns = true;
                CategoriesGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                CategoriesGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                CategoriesGridView.DataSource = bs;
                CategoriesGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var createForm = new CategoriesCreateForm();
            createForm.FormClosed += (s, e) => LoadCategories();
            createForm.ShowDialog();
        }

        private void CategoriesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
        }

        private void button3_Click(object? sender, EventArgs e)
        {
            DataGridViewRow? row = null;
            if (CategoriesGridView.SelectedRows.Count > 0)
                row = CategoriesGridView.SelectedRows[0];
            else
                row = CategoriesGridView.CurrentRow;

            if (row == null)
            {
                MessageBox.Show("No category selected.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (row.DataBoundItem is not CategoryModel category)
            {
                MessageBox.Show("Selected item is not a valid category.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to delete the category '{category.CategoryName}'?",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes)
                return;

            try
            {
                _categoryService.DeleteCategory(category);
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            try
            {
                var success = XmlExporter.ExportDataGridViewToXml(CategoriesGridView, "Categories");
                if (success)
                {
                    MessageBox.Show("Export completed successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            try
            {
                using var filterForm = new CategoriesFilter();
                if (filterForm.ShowDialog() != DialogResult.OK || filterForm.Query == null)
                    return;

                var query = filterForm.Query;
                List<CategoryModel> categories = _categoryService.GetCategories(query);

                var bs = new BindingSource
                {
                    DataSource = new BindingList<CategoryModel>(categories)
                };

                CategoriesGridView.AutoGenerateColumns = true;
                CategoriesGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                CategoriesGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                CategoriesGridView.DataSource = bs;
                CategoriesGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to apply filter: {ex.Message}", "Filter Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CategoriesGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = CategoriesGridView.Rows[e.RowIndex];
            if (row == null)
                return;

            if (row.DataBoundItem is not CategoryModel category)
            {
                MessageBox.Show("Selected item is not a valid category.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var updateForm = new CategoriesUpdateForm(category.Id);
                updateForm.FormClosed += (s, ev) => LoadCategories();
                updateForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open update form: {ex.Message}", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}