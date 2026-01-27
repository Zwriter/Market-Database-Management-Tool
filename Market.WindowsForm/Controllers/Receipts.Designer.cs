namespace Market.WindowsForm.Controls
{
    partial class Receipts
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

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            ReceiptsGridView = new DataGridView();
            panel2 = new Panel();
            deleteButton = new Button();
            updateButton = new Button();
            createButton = new Button();
            filterButton = new Button();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ReceiptsGridView).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(637, 71);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(219, 219, 219);
            label1.Location = new Point(0, 0);
            label1.MinimumSize = new Size(637, 71);
            label1.Name = "label1";
            label1.Size = new Size(637, 71);
            label1.TabIndex = 2;
            label1.Text = "Recipts";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.UseMnemonic = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.73155F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.268446F));
            tableLayoutPanel1.Controls.Add(ReceiptsGridView, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 71);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(637, 379);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // ReceiptsGridView
            // 
            ReceiptsGridView.AllowUserToAddRows = false;
            ReceiptsGridView.AllowUserToDeleteRows = false;
            ReceiptsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ReceiptsGridView.Dock = DockStyle.Fill;
            ReceiptsGridView.Location = new Point(3, 3);
            ReceiptsGridView.Name = "ReceiptsGridView";
            ReceiptsGridView.ReadOnly = true;
            ReceiptsGridView.RowHeadersWidth = 51;
            ReceiptsGridView.Size = new Size(521, 373);
            ReceiptsGridView.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(deleteButton);
            panel2.Controls.Add(updateButton);
            panel2.Controls.Add(createButton);
            panel2.Controls.Add(filterButton);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(530, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(104, 373);
            panel2.TabIndex = 0;
            // 
            // deleteButton
            // 
            deleteButton.Dock = DockStyle.Top;
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.ForeColor = Color.FromArgb(219, 219, 219);
            deleteButton.Location = new Point(0, 87);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(104, 29);
            deleteButton.TabIndex = 14;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // updateButton
            // 
            updateButton.Dock = DockStyle.Top;
            updateButton.FlatAppearance.BorderSize = 0;
            updateButton.FlatStyle = FlatStyle.Flat;
            updateButton.ForeColor = Color.FromArgb(219, 219, 219);
            updateButton.Location = new Point(0, 58);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(104, 29);
            updateButton.TabIndex = 13;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // createButton
            // 
            createButton.Dock = DockStyle.Top;
            createButton.FlatAppearance.BorderSize = 0;
            createButton.FlatStyle = FlatStyle.Flat;
            createButton.ForeColor = Color.FromArgb(219, 219, 219);
            createButton.Location = new Point(0, 29);
            createButton.Name = "createButton";
            createButton.Size = new Size(104, 29);
            createButton.TabIndex = 12;
            createButton.Text = "Create";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
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
            filterButton.TabIndex = 11;
            filterButton.Text = "Filter";
            filterButton.UseVisualStyleBackColor = true;
            filterButton.Click += FilterButton_click;
            // 
            // Receipts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 37, 41);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Name = "Receipts";
            Size = new Size(637, 450);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ReceiptsGridView).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private DataGridView ReceiptsGridView;
        private Button deleteButton;
        private Button updateButton;
        private Button createButton;
        private Button filterButton;
        private Label label1;
    }
}
