namespace _2x
{
    public partial class ProxySettingsDialog : Form
    {
        private Dictionary<string, Tuple<string, string>> proxySettingsDict;
        public string SelectedProxyName { get; private set; }

        public ProxySettingsDialog(Dictionary<string, Tuple<string, string>> proxySettings)
        {
            InitializeComponent();
            proxySettingsDict = proxySettings;
            PopulateProxyList();
        }

        private void PopulateProxyList()
        {
            proxyListBox.Items.Clear();
            foreach (var entry in proxySettingsDict)
            {
                proxyListBox.Items.Add(entry.Key);
            }
        }

        private void proxyListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (proxyListBox.SelectedItem != null)
            {
                SelectedProxyName = proxyListBox.SelectedItem.ToString();
                var settings = proxySettingsDict[SelectedProxyName];
                nameTextBox.Text = SelectedProxyName;
                addressTextBox.Text = settings.Item1;
                portTextBox.Text = settings.Item2;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string address = addressTextBox.Text;
            string port = portTextBox.Text;

            if (!string.IsNullOrEmpty(name) && !proxySettingsDict.ContainsKey(name))
            {
                proxySettingsDict[name] = Tuple.Create(address, port);
                PopulateProxyList();
                // Optionally select the new item
                proxyListBox.SelectedItem = name;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (proxyListBox.SelectedItem != null)
            {
                string name = proxyListBox.SelectedItem.ToString();
                proxySettingsDict.Remove(name);
                PopulateProxyList();
                // Optionally clear text boxes if the deleted item was selected
                if (SelectedProxyName == name)
                {
                    nameTextBox.Clear();
                    addressTextBox.Clear();
                    portTextBox.Clear();
                    SelectedProxyName = null;
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (SelectedProxyName != null)
            {
                proxySettingsDict[SelectedProxyName] = Tuple.Create(addressTextBox.Text, portTextBox.Text);
                PopulateProxyList();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            // Save changes if necessary
            // Update SelectedProxyName if needed
            if (SelectedProxyName != null)
            {
                proxySettingsDict[SelectedProxyName] = Tuple.Create(addressTextBox.Text, portTextBox.Text);
            }
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
