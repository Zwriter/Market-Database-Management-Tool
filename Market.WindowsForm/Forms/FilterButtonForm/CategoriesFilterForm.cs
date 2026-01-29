using Market.BusinessModel.Enums;
using Market.BusinessModel.Requests;
using System;
using System.Windows.Forms;

namespace Market.WindowsForm.Forms
{
    public partial class CategoriesFilter : Form
    {
        public CategoryQuery Query { get; private set; }

        public CategoriesFilter()
        {
            InitializeComponent();

            categoryRadioButton.Checked = true;

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new[] { "Asc", "Desc" });
            comboBox1.SelectedIndex = 0;

        }

        private void FilterButton_Click(object? sender, EventArgs e)
        {
            var q = new CategoryQuery();

            if (categoryRadioButton.Checked)
                q.SortBy = CategorySortBy.CategoryName;
            else if (createdAtRadioButton.Checked)
                q.SortBy = CategorySortBy.CreatedAt;
            else if (idRadioButton.Checked)
            {
                if (Enum.TryParse<CategorySortBy>("Id", true, out var idSort))
                    q.SortBy = idSort;
                else
                    q.SortBy = CategorySortBy.CategoryName;
            }
            else
                q.SortBy = CategorySortBy.CategoryName;

            var dirText = comboBox1.SelectedItem?.ToString() ?? "Asc";
            if (Enum.TryParse<SortDirection>(dirText, true, out var dir))
                q.SortDirection = dir;
            else
                q.SortDirection = SortDirection.Asc;

            Query = q;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}