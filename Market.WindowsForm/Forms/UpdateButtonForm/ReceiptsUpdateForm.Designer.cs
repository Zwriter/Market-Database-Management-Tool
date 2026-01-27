namespace Market.WindowsForm.Forms.UpdateButtonForm
{
    partial class ReceiptsUpdateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel10 = new Panel();
            updateButton = new Button();
            panel2 = new Panel();
            idTextBox = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel4 = new Panel();
            label1 = new Label();
            panel5 = new Panel();
            clientComboBox = new ComboBox();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel10.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 368);
            panel1.Name = "panel1";
            panel1.Size = new Size(384, 82);
            panel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 176F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(panel10, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(384, 82);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // panel10
            // 
            panel10.Controls.Add(updateButton);
            panel10.Location = new Point(191, 3);
            panel10.Name = "panel10";
            panel10.Size = new Size(170, 30);
            panel10.TabIndex = 0;
            // 
            // updateButton
            // 
            updateButton.BackColor = Color.FromArgb(39, 43, 47);
            updateButton.Dock = DockStyle.Fill;
            updateButton.FlatAppearance.BorderSize = 0;
            updateButton.FlatStyle = FlatStyle.Flat;
            updateButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            updateButton.ForeColor = Color.FromArgb(219, 219, 219);
            updateButton.Location = new Point(0, 0);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(170, 30);
            updateButton.TabIndex = 0;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = false;
            updateButton.Click += updateButton_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(idTextBox);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(384, 56);
            panel2.TabIndex = 7;
            // 
            // idTextBox
            // 
            idTextBox.BackColor = Color.FromArgb(39, 43, 47);
            idTextBox.BorderStyle = BorderStyle.None;
            idTextBox.Dock = DockStyle.Fill;
            idTextBox.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            idTextBox.ForeColor = Color.FromArgb(219, 219, 219);
            idTextBox.Location = new Point(0, 0);
            idTextBox.Multiline = true;
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(384, 56);
            idTextBox.TabIndex = 3;
            idTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.900523F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 91.09948F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 172F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(panel4, 1, 1);
            tableLayoutPanel1.Controls.Add(panel5, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 56);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 69.72973F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30.27027F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 126F));
            tableLayoutPanel1.Size = new Size(384, 312);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // panel4
            // 
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(20, 132);
            panel4.Name = "panel4";
            panel4.Size = new Size(168, 50);
            panel4.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(219, 219, 219);
            label1.Location = new Point(0, 0);
            label1.MinimumSize = new Size(166, 50);
            label1.Name = "label1";
            label1.Size = new Size(166, 50);
            label1.TabIndex = 1;
            label1.Text = "Change Client";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            panel5.Controls.Add(clientComboBox);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(194, 132);
            panel5.Name = "panel5";
            panel5.Size = new Size(166, 50);
            panel5.TabIndex = 1;
            // 
            // clientComboBox
            // 
            clientComboBox.BackColor = Color.FromArgb(39, 43, 47);
            clientComboBox.Dock = DockStyle.Fill;
            clientComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            clientComboBox.FlatStyle = FlatStyle.Flat;
            clientComboBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            clientComboBox.ForeColor = Color.FromArgb(219, 219, 219);
            clientComboBox.FormattingEnabled = true;
            clientComboBox.Location = new Point(0, 0);
            clientComboBox.Name = "clientComboBox";
            clientComboBox.Size = new Size(166, 28);
            clientComboBox.TabIndex = 1;
            // 
            // ReceiptsUpdateForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 37, 41);
            ClientSize = new Size(384, 450);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ReceiptsUpdateForm";
            Text = "Update Receipt";
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel10;
        private Button updateButton;
        private Panel panel2;
        private TextBox idTextBox;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel4;
        private Label label1;
        private Panel panel5;
        private ComboBox clientComboBox;
    }
}