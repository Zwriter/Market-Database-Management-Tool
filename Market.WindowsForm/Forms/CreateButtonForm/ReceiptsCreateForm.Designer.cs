namespace Market.WindowsForm.Forms.CreateButtonForm
{
    partial class ReceiptsCreateForm
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
            saveButton = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel4 = new Panel();
            label1 = new Label();
            panel5 = new Panel();
            clientComboBox = new ComboBox();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel10.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 328);
            panel1.Name = "panel1";
            panel1.Size = new Size(366, 75);
            panel1.TabIndex = 1;
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
            tableLayoutPanel2.Size = new Size(366, 75);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // panel10
            // 
            panel10.Controls.Add(saveButton);
            panel10.Location = new Point(173, 3);
            panel10.Name = "panel10";
            panel10.Size = new Size(170, 31);
            panel10.TabIndex = 0;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.FromArgb(39, 43, 47);
            saveButton.Dock = DockStyle.Fill;
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            saveButton.ForeColor = Color.FromArgb(219, 219, 219);
            saveButton.Location = new Point(0, 0);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(170, 31);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(366, 56);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(tableLayoutPanel1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 56);
            panel3.Name = "panel3";
            panel3.Size = new Size(366, 272);
            panel3.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 47.826088F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52.173912F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(panel4, 0, 1);
            tableLayoutPanel1.Controls.Add(panel5, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 74.5098F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25.4901962F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 118F));
            tableLayoutPanel1.Size = new Size(366, 272);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(label1);
            panel4.Location = new Point(3, 117);
            panel4.Name = "panel4";
            panel4.Size = new Size(159, 33);
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
            label1.Text = "Client";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            panel5.Controls.Add(clientComboBox);
            panel5.Location = new Point(168, 117);
            panel5.Name = "panel5";
            panel5.Size = new Size(174, 33);
            panel5.TabIndex = 1;
            // 
            // clientComboBox
            // 
            clientComboBox.BackColor = Color.FromArgb(39, 43, 47);
            clientComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            clientComboBox.FlatStyle = FlatStyle.Flat;
            clientComboBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            clientComboBox.ForeColor = Color.FromArgb(219, 219, 219);
            clientComboBox.FormattingEnabled = true;
            clientComboBox.Location = new Point(6, 3);
            clientComboBox.Name = "clientComboBox";
            clientComboBox.Size = new Size(171, 28);
            clientComboBox.TabIndex = 0;
            // 
            // ReceiptsCreateForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 37, 41);
            ClientSize = new Size(366, 403);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ReceiptsCreateForm";
            Text = "Create Receipt";
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel3.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel10;
        private Button saveButton;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel4;
        private Panel panel5;
        private ComboBox clientComboBox;
        private Label label1;
    }
}