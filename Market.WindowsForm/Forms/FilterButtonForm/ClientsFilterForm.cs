using Market.BusinessModel.Enums;
using Market.BusinessModel.Requests;


namespace Market.WindowsForm.Forms
{
    public partial class ClientsFilterForm : Form
    {
        public ClientQuery Query { get; private set; }

        public ClientsFilterForm()
        {
            InitializeComponent();

            nameRadioButton.Checked = true;
            comboBox1.Items.AddRange(new[] { "Asc", "Desc" });
            comboBox1.SelectedIndex = 0;
        }

        private void FilterButton_Click(object? sender, EventArgs e)
        {
            var q = new ClientQuery();

            if (nameRadioButton.Checked)
                q.SortBy = ClientSortBy.Name;
            else if (phoneRadioButton.Checked)
                q.SortBy = ClientSortBy.PhoneNumber;
            else if (emailRadioButton.Checked)
                q.SortBy = ClientSortBy.Email;
            else
                q.SortBy = ClientSortBy.Name;

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
