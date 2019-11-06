namespace ZControl
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMQTTPassword = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtMQTTUser = new System.Windows.Forms.TextBox();
            this.numMQTTPort = new System.Windows.Forms.NumericUpDown();
            this.txtMQTTServer = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMQTTPort)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(289, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(394, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.txtMQTTPassword);
            this.groupBox1.Controls.Add(this.txtMQTTUser);
            this.groupBox1.Controls.Add(this.numMQTTPort);
            this.groupBox1.Controls.Add(this.txtMQTTServer);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(943, 43);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MQTT服务器配置";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "端口:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(447, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "登录名:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(672, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "密码:";
            // 
            // txtMQTTPassword
            // 
            this.txtMQTTPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMQTTPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ZControl.Properties.Settings.Default, "MQTTPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtMQTTPassword.Location = new System.Drawing.Point(713, 13);
            this.txtMQTTPassword.Name = "txtMQTTPassword";
            this.txtMQTTPassword.PasswordChar = '*';
            this.txtMQTTPassword.Size = new System.Drawing.Size(166, 21);
            this.txtMQTTPassword.TabIndex = 7;
            this.txtMQTTPassword.Text = global::ZControl.Properties.Settings.Default.MQTTPassword;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(885, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(52, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "确认";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // txtMQTTUser
            // 
            this.txtMQTTUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMQTTUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ZControl.Properties.Settings.Default, "MQTTUser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtMQTTUser.Location = new System.Drawing.Point(500, 13);
            this.txtMQTTUser.Name = "txtMQTTUser";
            this.txtMQTTUser.Size = new System.Drawing.Size(166, 21);
            this.txtMQTTUser.TabIndex = 6;
            this.txtMQTTUser.Text = global::ZControl.Properties.Settings.Default.MQTTUser;
            // 
            // numMQTTPort
            // 
            this.numMQTTPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numMQTTPort.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ZControl.Properties.Settings.Default, "MQTTPort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numMQTTPort.Location = new System.Drawing.Point(375, 13);
            this.numMQTTPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numMQTTPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMQTTPort.Name = "numMQTTPort";
            this.numMQTTPort.Size = new System.Drawing.Size(66, 21);
            this.numMQTTPort.TabIndex = 5;
            this.numMQTTPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMQTTPort.Value = global::ZControl.Properties.Settings.Default.MQTTPort;
            // 
            // txtMQTTServer
            // 
            this.txtMQTTServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMQTTServer.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ZControl.Properties.Settings.Default, "MQTTServer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtMQTTServer.Location = new System.Drawing.Point(59, 14);
            this.txtMQTTServer.Name = "txtMQTTServer";
            this.txtMQTTServer.Size = new System.Drawing.Size(267, 21);
            this.txtMQTTServer.TabIndex = 4;
            this.txtMQTTServer.Text = global::ZControl.Properties.Settings.Default.MQTTServer;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMQTTPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMQTTPassword;
        private System.Windows.Forms.TextBox txtMQTTUser;
        private System.Windows.Forms.NumericUpDown numMQTTPort;
        private System.Windows.Forms.TextBox txtMQTTServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
    }
}

