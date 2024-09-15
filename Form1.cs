using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace _2x
{
    public partial class Form1 : Form
    {
        private bool proxyEnabled = false;
        private string proxyAddress = "127.0.0.1";
        private string proxyPort = "8080";
        private System.Windows.Forms.Timer statusCheckTimer;

        private Dictionary<string, Tuple<string, string>> proxySettingsDict = new Dictionary<string, Tuple<string, string>>();

        private readonly Icon defaultStart = Properties.Resource.default_start;
        private readonly Icon enabledConnectedIcon = Properties.Resource.proxy_enabled_connected;
        private readonly Icon enabledDisconnectedIcon = Properties.Resource.proxy_enabled_disconnected;
        private readonly Icon disabledIcon = Properties.Resource.proxy_disabled;

        public Form1()
        {
            InitializeComponent();
            trayIcon.Icon = defaultStart;
            SetupTrayIcon();
            LoadCurrentProxySettings();

            proxySettingsDict["Default Proxy"] = Tuple.Create("127.0.0.1", "8080");

            // Set up timer
            statusCheckTimer = new System.Windows.Forms.Timer();
            statusCheckTimer.Interval = 1000; // Check every 1 second
            statusCheckTimer.Tick += StatusCheckTimer_Tick;
            statusCheckTimer.Start();

            // Set the initial state of the toggleStartupMenuItem
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            if (key != null)
            {
                toggleStartupMenuItem.Checked = key.GetValue("ProxySwitcher") != null;
                key.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void SetupTrayIcon()
        {
            trayIcon.Icon = SystemIcons.Application;
            trayIcon.Text = "代理切换器";

            trayMenu.Items.Add(proxySettingsMenuItem);
            trayMenu.Items.Add(editProxyMenuItem);
            trayMenu.Items.Add(toggleClickMenuItem);
            trayMenu.Items.Add(toggleStartupMenuItem);
            trayMenu.Items.Add(exitMenuItem);

            proxySettingsMenuItem.DropDownItems.Add(enableProxyMenuItem);
            proxySettingsMenuItem.DropDownItems.Add(disableProxyMenuItem);

            enableProxyMenuItem.Text = "启用代理";
            disableProxyMenuItem.Text = "禁用代理";
            editProxyMenuItem.Text = "编辑代理设置";
            toggleStartupMenuItem.Text = "开机自启动";
            toggleClickMenuItem.Text = "双击切换"; // 固定显示为“双击切换”
            toggleClickMenuItem.CheckOnClick = true; // 允许选中和取消选中

            // Add event handlers
            enableProxyMenuItem.Click += EnableProxyMenuItem_Click;
            disableProxyMenuItem.Click += DisableProxyMenuItem_Click;
            editProxyMenuItem.Click += EditProxyMenuItem_Click;
            toggleClickMenuItem.Click += ToggleClickMenuItem_Click;
            toggleStartupMenuItem.Click += ToggleStartupMenuItem_Click;
            exitMenuItem.Click += ExitMenuItem_Click;  // Ensure this line is present

            trayIcon.MouseClick += TrayIcon_MouseClick;
            trayIcon.MouseDoubleClick += TrayIcon_MouseDoubleClick;

            // Populate proxy settings menu items
            UpdateProxySettingsMenuItems();
        }

        private void UpdateProxySettingsMenuItems()
        {
            proxySettingsMenuItem.DropDownItems.Clear();
            proxySettingsMenuItem.DropDownItems.Add(enableProxyMenuItem);
            proxySettingsMenuItem.DropDownItems.Add(disableProxyMenuItem);
            foreach (var proxy in proxySettingsDict)
            {
                var menuItem = new ToolStripMenuItem(proxy.Key);
                menuItem.Click += ProxySettingsMenuItem_Click;
                proxySettingsMenuItem.DropDownItems.Add(menuItem);
            }
        }

        private void ProxySettingsMenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            if (menuItem != null)
            {
                string selectedProxyName = menuItem.Text;
                if (proxySettingsDict.ContainsKey(selectedProxyName))
                {
                    (proxyAddress, proxyPort) = proxySettingsDict[selectedProxyName];
                    SetProxy(true, proxyAddress, proxyPort);
                    proxyEnabled = true;
                    UpdateTrayIconText();
                }
            }
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !toggleClickMenuItem.Checked)
            {
                // 如果未勾选双击切换，则左键单击时切换代理状态
                ToggleProxyStatus();
            }
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && toggleClickMenuItem.Checked)
            {
                // 如果勾选了双击切换，则双击时切换代理状态
                ToggleProxyStatus();
            }
        }

        private void ToggleClickMenuItem_Click(object sender, EventArgs e)
        {
            // 点击复选框时，不需要更改文字，文字始终显示为“双击切换”
            // 复选框选中的状态会自动由框架处理
        }

        private void ToggleStartupMenuItem_Click(object sender, EventArgs e)
        {
            if (toggleStartupMenuItem.Checked)
            {
                AddToStartup();
            }
            else
            {
                RemoveFromStartup();
            }
        }

        private void EnableProxyMenuItem_Click(object sender, EventArgs e)
        {
            SetProxy(true, proxyAddress, proxyPort);
            proxyEnabled = true;
            UpdateTrayIconText();
        }

        private void DisableProxyMenuItem_Click(object sender, EventArgs e)
        {
            SetProxy(false, proxyAddress, proxyPort); // Keep address and port
            proxyEnabled = false;
            UpdateTrayIconText();
        }

        private void EditProxyMenuItem_Click(object sender, EventArgs e)
        {
            using (ProxySettingsDialog dialog = new ProxySettingsDialog(proxySettingsDict))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedProxyName = dialog.SelectedProxyName;
                    if (selectedProxyName != null && proxySettingsDict.ContainsKey(selectedProxyName))
                    {
                        (proxyAddress, proxyPort) = proxySettingsDict[selectedProxyName];

                        if (proxyEnabled)
                        {
                            SetProxy(true, proxyAddress, proxyPort);
                        }
                        UpdateTrayIconText();
                        UpdateProxySettingsMenuItems(); // Refresh the menu items
                    }
                }
            }
        }

        private void ToggleProxyStatus()
        {
            if (proxyEnabled)
            {
                SetProxy(false, proxyAddress, proxyPort); // Disable proxy but keep address and port
            }
            else
            {
                SetProxy(true, proxyAddress, proxyPort); // Enable proxy with saved address and port
            }

            proxyEnabled = !proxyEnabled;
            UpdateTrayIconText();
        }

        private void SetProxy(bool enable, string address, string port)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);

            if (key != null)
            {
                key.SetValue("ProxyEnable", enable ? 1 : 0);

                if (enable)
                {
                    key.SetValue("ProxyServer", $"{address}:{port}");
                }
                else
                {
                    key.SetValue("ProxyServer", $"{address}:{port}"); // Disable but keep address and port
                }

                key.Close();
            }
        }

        private void LoadCurrentProxySettings()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings");

            if (key != null)
            {
                object proxyEnableValue = key.GetValue("ProxyEnable");
                proxyEnabled = proxyEnableValue != null && (int)proxyEnableValue == 1;

                object proxyServerValue = key.GetValue("ProxyServer");
                if (proxyServerValue != null)
                {
                    string proxyServer = (string)proxyServerValue;
                    var addressPort = proxyServer.Split(':');
                    if (addressPort.Length == 2)
                    {
                        proxyAddress = addressPort[0];
                        proxyPort = addressPort[1];
                    }
                }

                key.Close();
            }

            UpdateTrayIconText();
        }

        private void StatusCheckTimer_Tick(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings");

            if (key != null)
            {
                object proxyEnableValue = key.GetValue("ProxyEnable");
                bool currentProxyEnabled = proxyEnableValue != null && (int)proxyEnableValue == 1;

                object proxyServerValue = key.GetValue("ProxyServer");
                string currentProxyAddress = "";
                string currentProxyPort = "";
                if (proxyServerValue != null)
                {
                    string proxyServer = (string)proxyServerValue;
                    var addressPort = proxyServer.Split(':');
                    if (addressPort.Length == 2)
                    {
                        currentProxyAddress = addressPort[0];
                        currentProxyPort = addressPort[1];
                    }
                }

                if (proxyEnabled != currentProxyEnabled || proxyAddress != currentProxyAddress || proxyPort != currentProxyPort)
                {
                    proxyEnabled = currentProxyEnabled;
                    proxyAddress = currentProxyAddress;
                    proxyPort = currentProxyPort;
                    UpdateTrayIconText();
                }

                key.Close();
            }
        }

        private async Task<string> CheckProxyConnectivity()
        {
            try
            {
                using (HttpClientHandler handler = new HttpClientHandler())
                {
                    if (proxyEnabled)
                    {
                        handler.Proxy = new WebProxy($"{proxyAddress}:{proxyPort}");
                        handler.UseProxy = true;
                    }

                    using (HttpClient client = new HttpClient(handler))
                    {
                        client.Timeout = TimeSpan.FromSeconds(5);
                        HttpResponseMessage response = await client.GetAsync("https://www.google.com");

                        if (response.IsSuccessStatusCode)
                        {
                            return "代理状态: 连通";
                        }
                        else
                        {
                            return "代理状态: 不连通";
                        }
                    }
                }
            }
            catch
            {
                return "代理状态: 无法连接";
            }
        }

        private async void UpdateTrayIconText()
        {
            string connectivityStatus = proxyEnabled ? await CheckProxyConnectivity() : "代理状态: 已禁用";

            if (proxyEnabled)
            {
                trayIcon.Icon = connectivityStatus.Contains("连通") ? enabledConnectedIcon : enabledDisconnectedIcon;
            }
            else
            {
                trayIcon.Icon = disabledIcon;
            }

            trayIcon.Text = proxyEnabled
                ? $"代理状态: 启用\n地址: {proxyAddress}\n端口: {proxyPort}\n{connectivityStatus}"
                : "代理状态: 已禁用";
        }

        private void AddToStartup()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            if (key.GetValue("ProxySwitcher") == null)
            {
                key.SetValue("ProxySwitcher", Application.ExecutablePath);
            }
        }

        private void RemoveFromStartup()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            if (key.GetValue("ProxySwitcher") != null)
            {
                key.DeleteValue("ProxySwitcher");
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            // Stop any running timers if needed
            if (statusCheckTimer != null)
            {
                statusCheckTimer.Stop();
            }

            // Close the application
            Application.Exit();
        }
    }
}
