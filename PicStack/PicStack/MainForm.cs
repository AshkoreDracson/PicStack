using System;
using System.Windows.Forms;

namespace PicStack
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.icon;
        }
    }
}
