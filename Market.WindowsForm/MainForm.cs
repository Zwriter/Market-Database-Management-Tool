using Market.WindowsForm.Controls;

namespace Market.WindowsForm
{
    public partial class MainForm : Form
    {
        private Home _homeController = new();
        private Categories _categoriesController = new();
        private Clients _clientsController = new();
        private Factories _factoriesController = new();
        private Products _productsController = new();
        private Sales _salesController = new();
        private Receipts _receiptsController = new();
        private Records _recordsController = new();

        public MainForm()
        {
            InitializeComponent();
            panel2.Controls.Add(_homeController);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(_homeController);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(_clientsController);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(_categoriesController);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(_factoriesController);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(_productsController);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(_receiptsController);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(_recordsController);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(_salesController);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
