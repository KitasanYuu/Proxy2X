using System;
using System.Windows.Forms;

namespace _2x
{
    public partial class ProxySettingsDialog : Form
    {
        public string ProxyAddress { get; private set; }
        public string ProxyPort { get; private set; }

        public ProxySettingsDialog(string currentAddress, string currentPort)
        {
            InitializeComponent();
            ProxyAddress = currentAddress;
            ProxyPort = currentPort;
            addressTextBox.Text = currentAddress;
            portTextBox.Text = currentPort;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            ProxyAddress = addressTextBox.Text;
            ProxyPort = portTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
