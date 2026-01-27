using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Internal;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.WindowsForm.Forms.CreateButtonForm;
using Market.WindowsForm.Forms.FilterButtonForm;
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
    public partial class Records : UserControl
    {
        private readonly ServiceFactory _serviceFactory;
        private readonly IRecordService _recordService;

        public Records()
        {
            InitializeComponent();

            _serviceFactory = new ServiceFactory();
            _recordService = _serviceFactory.CreateRecordService();

            this.Load += Records_Load;
        }

        private void Records_Load(object? sender, EventArgs e)
        {
            LoadRecords();
        }

        private void LoadRecords()
        {
            try
            {
                var query = new RecordQuery();
                List<RecordModel> records = _recordService.GetRecords(query);

                var bs = new BindingSource
                {
                    DataSource = new BindingList<RecordModel>(records)
                };

                RecordsGridView.AutoGenerateColumns = true;
                RecordsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                RecordsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                RecordsGridView.DataSource = bs;
                RecordsGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load records: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            var createForm = new RecordsCreateForm();
            createForm.FormClosed += (s, e) => LoadRecords();
            createForm.ShowDialog();
        }

        private void deleteButton_Click(object? sender, EventArgs e)
        {
            DataGridViewRow? row = null;
            if (RecordsGridView.SelectedRows.Count > 0)
                row = RecordsGridView.SelectedRows[0];
            else
                row = RecordsGridView.CurrentRow;

            if (row == null)
            {
                MessageBox.Show("No record selected.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (row.DataBoundItem is not RecordModel record)
            {
                MessageBox.Show("Selected item is not a valid record.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to delete the record '{record.CategoryId}'?",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes)
                return;

            try
            {
                _recordService.DeleteRecord(record);
                LoadRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow? row = null;
            if (RecordsGridView.SelectedRows.Count > 0)
                row = RecordsGridView.SelectedRows[0];
            else
                row = RecordsGridView.CurrentRow;

            if (row == null)
            {
                MessageBox.Show("No record selected.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (row.DataBoundItem is not RecordModel record)
            {
                MessageBox.Show("Selected item is not a valid record.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var updateForm = new RecordsUpdateForm(record.Id);
                updateForm.FormClosed += (s, e) => LoadRecords();
                updateForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update record: {ex.Message}", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterButton_click(object sender, EventArgs e)
        {
            var filterForm = new RecordsFilterForm();
            filterForm.FormClosed += (s, e) => LoadRecords();
            filterForm.ShowDialog();
        }
    }
}
