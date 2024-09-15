namespace _2x
{
    partial class ProxySettingsDialog
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox addressTextBox;
        private TextBox portTextBox;
        private Button okButton;
        private Button cancelButton;
        private Label addressLabel;
        private Label portLabel;

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
            this.addressTextBox = new TextBox();
            this.portTextBox = new TextBox();
            this.okButton = new Button();
            this.cancelButton = new Button();
            this.addressLabel = new Label();
            this.portLabel = new Label();
            this.SuspendLayout();

            // addressTextBox
            this.addressTextBox.Location = new System.Drawing.Point(100, 20);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(150, 20);
            this.addressTextBox.TabIndex = 0;

            // portTextBox
            this.portTextBox.Location = new System.Drawing.Point(100, 50);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(150, 20);
            this.portTextBox.TabIndex = 1;

            // okButton
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(40, 80);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);

            // cancelButton
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(175, 80);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);

            // addressLabel
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(20, 23);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(74, 13);
            this.addressLabel.TabIndex = 4;
            this.addressLabel.Text = "代理地址：";

            // portLabel
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(20, 53);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(74, 13);
            this.portLabel.TabIndex = 5;
            this.portLabel.Text = "代理端口：";

            // ProxySettingsDialog
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 121);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.addressTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProxySettingsDialog";
            this.Text = "编辑代理设置";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
