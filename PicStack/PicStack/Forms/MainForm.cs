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

        private void browseBTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "JPG Files|*.jpg|PNG Files|*.png", CheckFileExists = true, CheckPathExists = true, Multiselect = true };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileList.Items.Clear();
                if (ofd.FileNames != null) fileList.Items.AddRange(ofd.FileNames);
            }

            UpdateControlStates();
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            UpdateControlStates();
        }

        private void UpdateControlStates()
        {
            exportBTN.Enabled = fileList.Items.Count > 0;
            trackBar.Enabled = fileList.Items.Count > 0;
            trackBarLabel.Text = $"Divide photo blending in {trackBar.Value} parts ({fileList.Items.Count / trackBar.Value} photos per part (Avg blend), {trackBar.Value} exposure addition blending)";
        }
    }
}
