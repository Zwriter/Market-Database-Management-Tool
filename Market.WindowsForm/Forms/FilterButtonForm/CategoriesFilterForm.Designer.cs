namespace Market.WindowsForm.Forms
{
    partial class CategoriesFilter
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
            panel2 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel10 = new Panel();
            filterButton = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel5 = new Panel();
            label3 = new Label();
            panel6 = new Panel();
            comboBox1 = new ComboBox();
            panel3 = new Panel();
            groupBox1 = new GroupBox();
            idRadioButton = new RadioButton();
            createdAtRadioButton = new RadioButton();
            categoryRadioButton = new RadioButton();
            panel2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel10.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(384, 62);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel2);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 368);
            panel2.Name = "panel2";
            panel2.Size = new Size(384, 82);
            panel2.TabIndex = 2;
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
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel10
            // 
            panel10.Controls.Add(filterButton);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(191, 3);
            panel10.Name = "panel10";
            panel10.Size = new Size(170, 35);
            panel10.TabIndex = 0;
            // 
            // filterButton
            // 
            filterButton.BackColor = Color.FromArgb(39, 43, 47);
            filterButton.Dock = DockStyle.Fill;
            filterButton.FlatAppearance.BorderSize = 0;
            filterButton.FlatStyle = FlatStyle.Flat;
            filterButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            filterButton.ForeColor = Color.FromArgb(219, 219, 219);
            filterButton.Location = new Point(0, 0);
            filterButton.Name = "filterButton";
            filterButton.Size = new Size(170, 35);
            filterButton.TabIndex = 1;
            filterButton.Text = "Filter";
            filterButton.UseVisualStyleBackColor = false;
            filterButton.Click += FilterButton_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 88.8888855F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 174F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(panel5, 1, 1);
            tableLayoutPanel1.Controls.Add(panel6, 2, 1);
            tableLayoutPanel1.Controls.Add(panel3, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 62);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 46.72131F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 53.27869F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 147F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 57F));
            tableLayoutPanel1.Size = new Size(384, 306);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // panel5
            // 
            panel5.Controls.Add(label3);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(24, 50);
            panel5.Name = "panel5";
            panel5.Size = new Size(162, 48);
            panel5.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(219, 219, 219);
            label3.Location = new Point(0, 0);
            label3.MinimumSize = new Size(167, 43);
            label3.Name = "label3";
            label3.Size = new Size(167, 43);
            label3.TabIndex = 3;
            label3.Text = "Sort";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            panel6.Controls.Add(comboBox1);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(192, 50);
            panel6.Name = "panel6";
            panel6.Size = new Size(168, 48);
            panel6.TabIndex = 9;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.FromArgb(39, 43, 47);
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            comboBox1.ForeColor = Color.FromArgb(219, 219, 219);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(0, 0);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(168, 28);
            comboBox1.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(groupBox1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(24, 104);
            panel3.Name = "panel3";
            panel3.Size = new Size(162, 141);
            panel3.TabIndex = 10;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(idRadioButton);
            groupBox1.Controls.Add(createdAtRadioButton);
            groupBox1.Controls.Add(categoryRadioButton);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(219, 219, 219);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(162, 141);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sort By";
            // 
            // idRadioButton
            // 
            idRadioButton.AutoSize = true;
            idRadioButton.Dock = DockStyle.Top;
            idRadioButton.Location = new Point(3, 80);
            idRadioButton.Name = "idRadioButton";
            idRadioButton.Size = new Size(156, 27);
            idRadioButton.TabIndex = 2;
            idRadioButton.TabStop = true;
            idRadioButton.Text = "Id";
            idRadioButton.UseVisualStyleBackColor = true;
            // 
            // createdAtRadioButton
            // 
            createdAtRadioButton.AutoSize = true;
            createdAtRadioButton.Dock = DockStyle.Top;
            createdAtRadioButton.Location = new Point(3, 53);
            createdAtRadioButton.Name = "createdAtRadioButton";
            createdAtRadioButton.Size = new Size(156, 27);
            createdAtRadioButton.TabIndex = 1;
            createdAtRadioButton.TabStop = true;
            createdAtRadioButton.Text = "Created At";
            createdAtRadioButton.UseVisualStyleBackColor = true;
            // 
            // categoryRadioButton
            // 
            categoryRadioButton.AutoSize = true;
            categoryRadioButton.Dock = DockStyle.Top;
            categoryRadioButton.Location = new Point(3, 26);
            categoryRadioButton.Name = "categoryRadioButton";
            categoryRadioButton.Size = new Size(156, 27);
            categoryRadioButton.TabIndex = 0;
            categoryRadioButton.TabStop = true;
            categoryRadioButton.Text = "Category";
            categoryRadioButton.UseVisualStyleBackColor = true;
            // 
            // CategoriesFilter
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 37, 41);
            ClientSize = new Size(384, 450);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "CategoriesFilter";
            Text = "Filter Categories";
            panel2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel10.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel10;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel5;
        private Label label3;
        private Panel panel6;
        private ComboBox comboBox1;
        private Panel panel3;
        private GroupBox groupBox1;
        private RadioButton idRadioButton;
        private RadioButton createdAtRadioButton;
        private RadioButton categoryRadioButton;
        private Button filterButton;
    }
}