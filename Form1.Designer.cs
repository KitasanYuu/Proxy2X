namespace _2x
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem proxySettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableProxyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableProxyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editProxyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleStartupMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleClickMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.proxySettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableProxyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableProxyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editProxyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleStartupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleClickMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayMenu;
            this.trayIcon.Text = "代理切换器";
            this.trayIcon.Visible = true;
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proxySettingsMenuItem,
            this.toggleClickMenuItem,
            this.toggleStartupMenuItem,
            this.exitMenuItem});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(181, 158);
            // 
            // proxySettingsMenuItem
            // 
            this.proxySettingsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableProxyMenuItem,
            this.disableProxyMenuItem,
            this.editProxyMenuItem});
            this.proxySettingsMenuItem.Name = "proxySettingsMenuItem";
            this.proxySettingsMenuItem.Size = new System.Drawing.Size(180, 22);
            this.proxySettingsMenuItem.Text = "手动切换";
            // 
            // enableProxyMenuItem
            // 
            this.enableProxyMenuItem.Name = "enableProxyMenuItem";
            this.enableProxyMenuItem.Size = new System.Drawing.Size(180, 22);
            this.enableProxyMenuItem.Text = "启用代理";
            // 
            // disableProxyMenuItem
            // 
            this.disableProxyMenuItem.Name = "disableProxyMenuItem";
            this.disableProxyMenuItem.Size = new System.Drawing.Size(180, 22);
            this.disableProxyMenuItem.Text = "禁用代理";
            // 
            // editProxyMenuItem
            // 
            this.editProxyMenuItem.Name = "editProxyMenuItem";
            this.editProxyMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editProxyMenuItem.Text = "编辑代理设置";
            // 
            // toggleStartupMenuItem
            // 
            this.toggleStartupMenuItem.CheckOnClick = true; // Set this to true to enable checkbox behavior
            this.toggleStartupMenuItem.Name = "toggleStartupMenuItem";
            this.toggleStartupMenuItem.Size = new System.Drawing.Size(180, 22);
            this.toggleStartupMenuItem.Text = "开机自启动";
            // 
            // toggleClickMenuItem
            // 
            this.toggleClickMenuItem.CheckOnClick = true; // Enable checkbox behavior
            this.toggleClickMenuItem.Name = "toggleClickMenuItem";
            this.toggleClickMenuItem.Size = new System.Drawing.Size(180, 22);
            this.toggleClickMenuItem.Text = "双击切换"; // Default to "双击切换"
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitMenuItem.Text = "退出";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.trayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}