namespace _2x
{
    partial class ProxySettingsDialog
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox addressTextBox;
        private TextBox portTextBox;
        private TextBox nameTextBox;
        private ListBox proxyListBox;
        private Button okButton;
        private Button cancelButton;
        private Button addButton;
        private Button deleteButton;
        private Button saveButton;
        private Label addressLabel;
        private Label portLabel;
        private Label nameLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.proxyListBox = new ListBox();
            this.addressTextBox = new TextBox();
            this.portTextBox = new TextBox();
            this.nameTextBox = new TextBox();
            this.okButton = new Button();
            this.cancelButton = new Button();
            this.addButton = new Button();
            this.deleteButton = new Button();
            this.saveButton = new Button();
            this.addressLabel = new Label();
            this.portLabel = new Label();
            this.nameLabel = new Label();
            this.SuspendLayout();

            // proxyListBox
            this.proxyListBox.FormattingEnabled = true;
            this.proxyListBox.Location = new System.Drawing.Point(12, 12);
            this.proxyListBox.Name = "proxyListBox";
            this.proxyListBox.Size = new System.Drawing.Size(160, 147);
            this.proxyListBox.TabIndex = 0;
            this.proxyListBox.SelectedIndexChanged += new System.EventHandler(this.proxyListBox_SelectedIndexChanged);

            // nameTextBox
            this.nameTextBox.Location = new System.Drawing.Point(278, 12);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(150, 20);
            this.nameTextBox.TabIndex = 1;

            // addressTextBox
            this.addressTextBox.Location = new System.Drawing.Point(278, 42);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(150, 20);
            this.addressTextBox.TabIndex = 2;

            // portTextBox
            this.portTextBox.Location = new System.Drawing.Point(278, 72);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(150, 20);
            this.portTextBox.TabIndex = 3;

            // nameLabel
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(200, 15);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(72, 13);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "代理名称：";

            // addressLabel
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(200, 45);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(72, 13);
            this.addressLabel.TabIndex = 5;
            this.addressLabel.Text = "代理地址：";

            // portLabel
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(200, 75);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(72, 13);
            this.portLabel.TabIndex = 6;
            this.portLabel.Text = "代理端口：";

            // okButton
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(353, 135);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);

            // cancelButton
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(278, 135);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);

            // addButton
            this.addButton.Location = new System.Drawing.Point(12, 170);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(50, 23);
            this.addButton.TabIndex = 9;
            this.addButton.Text = "添加";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);

            // deleteButton
            this.deleteButton.Location = new System.Drawing.Point(68, 170);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(50, 23);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.Text = "删除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);

            // saveButton
            this.saveButton.Location = new System.Drawing.Point(124, 170);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(50, 23);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);

            // ProxySettingsDialog
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 210);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.proxyListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProxySettingsDialog";
            this.Text = "代理设置";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
