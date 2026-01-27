using Market.BusinessLogic.Services;
using Market.BusinessModel.Interfaces;
namespace Market.WindowsForm.Controls
{
    partial class Categories
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

        #region Component Designer generated code
        private void InitializeComponent()
        {
            panel1 = new Panel();
            Clients = new Label();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            CategoriesGridView = new DataGridView();
            panel3 = new Panel();
            button3 = new Button();
            exportButton = new Button();
            button2 = new Button();
            filterButton = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CategoriesGridView).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(Clients);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(637, 71);
            panel1.TabIndex = 1;
            // 
            // Clients
            // 
            Clients.AutoSize = true;
            Clients.Dock = DockStyle.Fill;
            Clients.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            Clients.ForeColor = Color.FromArgb(219, 219, 219);
            Clients.Location = new Point(0, 0);
            Clients.MinimumSize = new Size(637, 71);
            Clients.Name = "Clients";
            Clients.Size = new Size(637, 71);
            Clients.TabIndex = 0;
            Clients.Text = "Categories";
            Clients.TextAlign = ContentAlignment.MiddleCenter;
            Clients.UseMnemonic = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 71);
            panel2.Name = "panel2";
            panel2.Size = new Size(637, 379);
            panel2.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.73155F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.268446F));
            tableLayoutPanel1.Controls.Add(CategoriesGridView, 0, 0);
            tableLayoutPanel1.Controls.Add(panel3, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(637, 379);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // CategoriesGridView
            // 
            CategoriesGridView.AllowUserToAddRows = false;
            CategoriesGridView.AllowUserToDeleteRows = false;
            CategoriesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CategoriesGridView.Dock = DockStyle.Fill;
            CategoriesGridView.Location = new Point(3, 3);
            CategoriesGridView.Name = "CategoriesGridView";
            CategoriesGridView.ReadOnly = true;
            CategoriesGridView.RowHeadersWidth = 51;
            CategoriesGridView.Size = new Size(521, 373);
            CategoriesGridView.TabIndex = 0;
            CategoriesGridView.CellContentClick += CategoriesGridView_CellContentClick;
            CategoriesGridView.CellDoubleClick += CategoriesGridView_CellDoubleClick;
            // 
            // panel3
            // 
            panel3.Controls.Add(button3);
            panel3.Controls.Add(exportButton);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(filterButton);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(530, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(104, 373);
            panel3.TabIndex = 1;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Top;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.FromArgb(219, 219, 219);
            button3.Location = new Point(0, 87);
            button3.Name = "button3";
            button3.Size = new Size(104, 29);
            button3.TabIndex = 6;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // exportButton
            // 
            exportButton.Dock = DockStyle.Top;
            exportButton.FlatAppearance.BorderSize = 0;
            exportButton.FlatStyle = FlatStyle.Flat;
            exportButton.ForeColor = Color.FromArgb(219, 219, 219);
            exportButton.Location = new Point(0, 58);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(104, 29);
            exportButton.TabIndex = 5;
            exportButton.Text = "Export";
            exportButton.UseVisualStyleBackColor = true;
            exportButton.Click += exportButton_Click;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Top;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.FromArgb(219, 219, 219);
            button2.Location = new Point(0, 29);
            button2.Name = "button2";
            button2.Size = new Size(104, 29);
            button2.TabIndex = 3;
            button2.Text = "Create";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // filterButton
            // 
            filterButton.Dock = DockStyle.Top;
            filterButton.FlatAppearance.BorderSize = 0;
            filterButton.FlatStyle = FlatStyle.Flat;
            filterButton.ForeColor = Color.FromArgb(219, 219, 219);
            filterButton.Location = new Point(0, 0);
            filterButton.Name = "filterButton";
            filterButton.Size = new Size(104, 29);
            filterButton.TabIndex = 2;
            filterButton.Text = "Filter";
            filterButton.UseVisualStyleBackColor = true;
            filterButton.Click += filterButton_Click;
            // 
            // Categories
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 37, 41);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Categories";
            Size = new Size(637, 450);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CategoriesGridView).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView CategoriesGridView;
        private Panel panel3;
        private Button button3;
        private Button exportButton;
        private Button button2;
        private Button filterButton;
        private Label Clients;
    }
}
