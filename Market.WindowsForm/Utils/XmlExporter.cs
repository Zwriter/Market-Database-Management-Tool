using System.Data;
using System.Xml;

namespace Market.WindowsForm.Utils
{
    internal static class XmlExporter
    {
        public static bool ExportDataGridViewToXml(DataGridView dgv, string rootElementName)
        {
            if (dgv == null) throw new ArgumentNullException(nameof(dgv));
            if (string.IsNullOrWhiteSpace(rootElementName)) rootElementName = "Export";

            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("There is no data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
                FileName = $"{rootElementName}_{DateTime.Now:yyyyMMdd_HHmmss}.xml",
                Title = $"Export {rootElementName} to XML"
            };

            if (sfd.ShowDialog() != DialogResult.OK || string.IsNullOrWhiteSpace(sfd.FileName))
                return false;

            try
            {
                var dt = new DataTable(rootElementName);

                var columns = dgv.Columns
                    .Cast<DataGridViewColumn>()
                    .Where(c => c.Visible)
                    .ToArray();

                if (columns.Length == 0)
                    return false;

                foreach (var col in columns)
                {
                    var colName = string.IsNullOrWhiteSpace(col.HeaderText) ? col.Name : col.HeaderText;
                    colName = XmlConvert.EncodeName(colName);
                    if (!dt.Columns.Contains(colName))
                        dt.Columns.Add(colName, typeof(string));
                }

                foreach (DataGridViewRow gridRow in dgv.Rows)
                {
                    if (gridRow.IsNewRow) continue;

                    var newRow = dt.NewRow();
                    for (int i = 0; i < columns.Length; i++)
                    {
                        var cell = gridRow.Cells[columns[i].Index];
                        var val = cell.FormattedValue?.ToString() ?? string.Empty;
                        var colName = XmlConvert.EncodeName(string.IsNullOrWhiteSpace(columns[i].HeaderText) ? columns[i].Name : columns[i].HeaderText);
                        newRow[colName] = val;
                    }
                    dt.Rows.Add(newRow);
                }

                var ds = new DataSet(rootElementName + "Data");
                ds.Tables.Add(dt);
                ds.WriteXml(sfd.FileName, XmlWriteMode.WriteSchema);

                MessageBox.Show($"Exported to {sfd.FileName}", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to export XML: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
