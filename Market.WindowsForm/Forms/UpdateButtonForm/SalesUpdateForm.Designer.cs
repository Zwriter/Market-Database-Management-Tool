namespace Market.WindowsForm.Forms.UpdateButtonForm
{
    partial class SalesUpdateForm
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
            productComboBox = new ComboBox();
            panel6 = new Panel();
            label2 = new Label();
            panel7 = new Panel();
            receiptComboBox = new ComboBox();
            panel8 = new Panel();
            label3 = new Label();
            panel9 = new Panel();
            quantityTextBox = new TextBox();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel10.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
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
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51.9230766F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48.0769234F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(panel4, 0, 1);
            tableLayoutPanel1.Controls.Add(panel5, 1, 1);
            tableLayoutPanel1.Controls.Add(panel6, 0, 0);
            tableLayoutPanel1.Controls.Add(panel7, 1, 0);
            tableLayoutPanel1.Controls.Add(panel8, 0, 2);
            tableLayoutPanel1.Controls.Add(panel9, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 56);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 43.2258072F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 56.7741928F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 59F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 93F));
            tableLayoutPanel1.Size = new Size(384, 312);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // panel4
            // 
            panel4.Controls.Add(label1);
            panel4.Location = new Point(3, 72);
            panel4.Name = "panel4";
            panel4.Size = new Size(177, 33);
            panel4.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(219, 219, 219);
            label1.Location = new Point(0, 0);
            label1.MinimumSize = new Size(177, 33);
            label1.Name = "label1";
            label1.Size = new Size(177, 33);
            label1.TabIndex = 0;
            label1.Text = "Update Product";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            panel5.Controls.Add(productComboBox);
            panel5.Location = new Point(192, 72);
            panel5.Name = "panel5";
            panel5.Size = new Size(169, 33);
            panel5.TabIndex = 1;
            // 
            // productComboBox
            // 
            productComboBox.BackColor = Color.FromArgb(39, 43, 47);
            productComboBox.Dock = DockStyle.Fill;
            productComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            productComboBox.FlatStyle = FlatStyle.Flat;
            productComboBox.ForeColor = Color.FromArgb(219, 219, 219);
            productComboBox.FormattingEnabled = true;
            productComboBox.Location = new Point(0, 0);
            productComboBox.Name = "productComboBox";
            productComboBox.Size = new Size(169, 28);
            productComboBox.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(label2);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(3, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(183, 63);
            panel6.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(219, 219, 219);
            label2.Location = new Point(0, 0);
            label2.MinimumSize = new Size(177, 33);
            label2.Name = "label2";
            label2.Size = new Size(177, 33);
            label2.TabIndex = 1;
            label2.Text = "Update Receipt";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            panel7.Controls.Add(receiptComboBox);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(192, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(169, 63);
            panel7.TabIndex = 3;
            // 
            // receiptComboBox
            // 
            receiptComboBox.BackColor = Color.FromArgb(39, 43, 47);
            receiptComboBox.Dock = DockStyle.Fill;
            receiptComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            receiptComboBox.FlatStyle = FlatStyle.Flat;
            receiptComboBox.ForeColor = Color.FromArgb(219, 219, 219);
            receiptComboBox.FormattingEnabled = true;
            receiptComboBox.Location = new Point(0, 0);
            receiptComboBox.Name = "receiptComboBox";
            receiptComboBox.Size = new Size(169, 28);
            receiptComboBox.TabIndex = 1;
            // 
            // panel8
            // 
            panel8.Controls.Add(label3);
            panel8.Location = new Point(3, 162);
            panel8.Name = "panel8";
            panel8.Size = new Size(177, 53);
            panel8.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(219, 219, 219);
            label3.Location = new Point(0, 0);
            label3.MinimumSize = new Size(177, 53);
            label3.Name = "label3";
            label3.Size = new Size(177, 53);
            label3.TabIndex = 1;
            label3.Text = "Update Quantity";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel9
            // 
            panel9.Controls.Add(quantityTextBox);
            panel9.Location = new Point(192, 162);
            panel9.Name = "panel9";
            panel9.Size = new Size(169, 53);
            panel9.TabIndex = 5;
            // 
            // quantityTextBox
            // 
            quantityTextBox.BackColor = Color.FromArgb(39, 43, 47);
            quantityTextBox.BorderStyle = BorderStyle.None;
            quantityTextBox.Dock = DockStyle.Fill;
            quantityTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            quantityTextBox.ForeColor = Color.FromArgb(219, 219, 219);
            quantityTextBox.Location = new Point(0, 0);
            quantityTextBox.Multiline = true;
            quantityTextBox.Name = "quantityTextBox";
            quantityTextBox.Size = new Size(169, 53);
            quantityTextBox.TabIndex = 1;
            quantityTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // SalesUpdateForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 37, 41);
            ClientSize = new Size(384, 450);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "SalesUpdateForm";
            Text = "Update Sale";
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
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
        private ComboBox productComboBox;
        private Panel panel6;
        private Label label2;
        private Panel panel7;
        private ComboBox receiptComboBox;
        private Panel panel8;
        private Label label3;
        private Panel panel9;
        private TextBox quantityTextBox;
    }
}