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
            this.groupBoxMQTT = new System.Windows.Forms.GroupBox();
            this.btMQTTConfirm = new System.Windows.Forms.Button();
            this.txtMQTTPassword = new System.Windows.Forms.TextBox();
            this.txtMQTTUser = new System.Windows.Forms.TextBox();
            this.numMQTTPort = new System.Windows.Forms.NumericUpDown();
            this.txtMQTTServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelLog = new System.Windows.Forms.Panel();
            this.labVersion = new System.Windows.Forms.Label();
            this.LabelLog = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeviceListAdd = new System.Windows.Forms.Button();
            this.btnDeviceListDel = new System.Windows.Forms.Button();
            this.btnDeviceMQTTSend = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtLogAll = new System.Windows.Forms.TextBox();
            this.panelDeviceControl = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.内容CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.CboIP = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxMQTT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMQTTPort)).BeginInit();
            this.panelLog.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxMQTT
            // 
            this.groupBoxMQTT.Controls.Add(this.btMQTTConfirm);
            this.groupBoxMQTT.Controls.Add(this.txtMQTTPassword);
            this.groupBoxMQTT.Controls.Add(this.txtMQTTUser);
            this.groupBoxMQTT.Controls.Add(this.numMQTTPort);
            this.groupBoxMQTT.Controls.Add(this.txtMQTTServer);
            this.groupBoxMQTT.Controls.Add(this.label4);
            this.groupBoxMQTT.Controls.Add(this.label3);
            this.groupBoxMQTT.Controls.Add(this.label2);
            this.groupBoxMQTT.Controls.Add(this.label1);
            this.groupBoxMQTT.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxMQTT.Location = new System.Drawing.Point(0, 25);
            this.groupBoxMQTT.Name = "groupBoxMQTT";
            this.groupBoxMQTT.Size = new System.Drawing.Size(580, 43);
            this.groupBoxMQTT.TabIndex = 3;
            this.groupBoxMQTT.TabStop = false;
            this.groupBoxMQTT.Text = "MQTT服务器配置";
            // 
            // btMQTTConfirm
            // 
            this.btMQTTConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMQTTConfirm.Image = global::ZControl.Properties.Resources.close;
            this.btMQTTConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMQTTConfirm.Location = new System.Drawing.Point(520, 9);
            this.btMQTTConfirm.Name = "btMQTTConfirm";
            this.btMQTTConfirm.Size = new System.Drawing.Size(54, 31);
            this.btMQTTConfirm.TabIndex = 8;
            this.btMQTTConfirm.Text = "连接";
            this.btMQTTConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btMQTTConfirm.UseVisualStyleBackColor = true;
            this.btMQTTConfirm.Click += new System.EventHandler(this.BtMQTTConfirm_Click);
            // 
            // txtMQTTPassword
            // 
            this.txtMQTTPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMQTTPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ZControl.Properties.Settings.Default, "MQTTPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtMQTTPassword.Location = new System.Drawing.Point(420, 14);
            this.txtMQTTPassword.Name = "txtMQTTPassword";
            this.txtMQTTPassword.PasswordChar = '*';
            this.txtMQTTPassword.Size = new System.Drawing.Size(95, 21);
            this.txtMQTTPassword.TabIndex = 7;
            this.txtMQTTPassword.Text = global::ZControl.Properties.Settings.Default.MQTTPassword;
            // 
            // txtMQTTUser
            // 
            this.txtMQTTUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMQTTUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ZControl.Properties.Settings.Default, "MQTTUser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtMQTTUser.Location = new System.Drawing.Point(297, 14);
            this.txtMQTTUser.Name = "txtMQTTUser";
            this.txtMQTTUser.Size = new System.Drawing.Size(87, 21);
            this.txtMQTTUser.TabIndex = 6;
            this.txtMQTTUser.Text = global::ZControl.Properties.Settings.Default.MQTTUser;
            // 
            // numMQTTPort
            // 
            this.numMQTTPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numMQTTPort.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ZControl.Properties.Settings.Default, "MQTTPort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numMQTTPort.Location = new System.Drawing.Point(180, 14);
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
            this.txtMQTTServer.Location = new System.Drawing.Point(49, 14);
            this.txtMQTTServer.Name = "txtMQTTServer";
            this.txtMQTTServer.Size = new System.Drawing.Size(93, 21);
            this.txtMQTTServer.TabIndex = 4;
            this.txtMQTTServer.Text = global::ZControl.Properties.Settings.Default.MQTTServer;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(387, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "密码:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "登录名:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "端口:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器:";
            // 
            // panelLog
            // 
            this.panelLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLog.Controls.Add(this.labVersion);
            this.panelLog.Controls.Add(this.LabelLog);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLog.Location = new System.Drawing.Point(0, 426);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(580, 25);
            this.panelLog.TabIndex = 4;
            // 
            // labVersion
            // 
            this.labVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labVersion.AutoSize = true;
            this.labVersion.BackColor = System.Drawing.SystemColors.Control;
            this.labVersion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labVersion.Location = new System.Drawing.Point(472, 5);
            this.labVersion.Name = "labVersion";
            this.labVersion.Size = new System.Drawing.Size(101, 12);
            this.labVersion.TabIndex = 9;
            this.labVersion.Text = "软件版本v0.0.0.0";
            // 
            // LabelLog
            // 
            this.LabelLog.AutoSize = true;
            this.LabelLog.Location = new System.Drawing.Point(6, 5);
            this.LabelLog.Name = "LabelLog";
            this.LabelLog.Size = new System.Drawing.Size(101, 12);
            this.LabelLog.TabIndex = 0;
            this.LabelLog.Text = "MQTT服务器未连接";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDeviceListAdd);
            this.panel1.Controls.Add(this.btnDeviceListDel);
            this.panel1.Controls.Add(this.btnDeviceMQTTSend);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 358);
            this.panel1.TabIndex = 5;
            // 
            // btnDeviceListAdd
            // 
            this.btnDeviceListAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeviceListAdd.Location = new System.Drawing.Point(3, 314);
            this.btnDeviceListAdd.Name = "btnDeviceListAdd";
            this.btnDeviceListAdd.Size = new System.Drawing.Size(126, 23);
            this.btnDeviceListAdd.TabIndex = 1;
            this.btnDeviceListAdd.Text = "获取局域网设备";
            this.btnDeviceListAdd.UseVisualStyleBackColor = true;
            this.btnDeviceListAdd.Click += new System.EventHandler(this.BtnDeviceListAdd_Click);
            // 
            // btnDeviceListDel
            // 
            this.btnDeviceListDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeviceListDel.Location = new System.Drawing.Point(129, 314);
            this.btnDeviceListDel.Name = "btnDeviceListDel";
            this.btnDeviceListDel.Size = new System.Drawing.Size(126, 23);
            this.btnDeviceListDel.TabIndex = 1;
            this.btnDeviceListDel.Text = "删除此设备";
            this.btnDeviceListDel.UseVisualStyleBackColor = true;
            this.btnDeviceListDel.Click += new System.EventHandler(this.BtnDeviceListDel_Click);
            // 
            // btnDeviceMQTTSend
            // 
            this.btnDeviceMQTTSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeviceMQTTSend.Location = new System.Drawing.Point(3, 335);
            this.btnDeviceMQTTSend.Name = "btnDeviceMQTTSend";
            this.btnDeviceMQTTSend.Size = new System.Drawing.Size(126, 23);
            this.btnDeviceMQTTSend.TabIndex = 1;
            this.btnDeviceMQTTSend.Text = "同步MQTT服务器";
            this.btnDeviceMQTTSend.UseVisualStyleBackColor = true;
            this.btnDeviceMQTTSend.Click += new System.EventHandler(this.BtnDeviceMQTTSend_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(258, 314);
            this.listBox1.TabIndex = 0;
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox1_DrawItem);
            this.listBox1.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ListBox1_MeasureItem);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtLogAll);
            this.panel2.Controls.Add(this.panelDeviceControl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(258, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(322, 358);
            this.panel2.TabIndex = 6;
            // 
            // txtLogAll
            // 
            this.txtLogAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogAll.Location = new System.Drawing.Point(5, 357);
            this.txtLogAll.Multiline = true;
            this.txtLogAll.Name = "txtLogAll";
            this.txtLogAll.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogAll.Size = new System.Drawing.Size(312, 0);
            this.txtLogAll.TabIndex = 2;
            // 
            // panelDeviceControl
            // 
            this.panelDeviceControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDeviceControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDeviceControl.Location = new System.Drawing.Point(5, 3);
            this.panelDeviceControl.Name = "panelDeviceControl";
            this.panelDeviceControl.Size = new System.Drawing.Size(310, 350);
            this.panelDeviceControl.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.工具TToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(580, 25);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出XToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 退出XToolStripMenuItem
            // 
            this.退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            this.退出XToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.退出XToolStripMenuItem.Text = "退出(&X)";
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.工具TToolStripMenuItem.Text = "工具(&T)";
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.内容CToolStripMenuItem,
            this.toolStripSeparator5,
            this.关于AToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 内容CToolStripMenuItem
            // 
            this.内容CToolStripMenuItem.Name = "内容CToolStripMenuItem";
            this.内容CToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.内容CToolStripMenuItem.Text = "内容(&C)";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(122, 6);
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.关于AToolStripMenuItem.Text = "关于(&A)...";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.CboIP);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(351, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(222, 23);
            this.panel3.TabIndex = 10;
            // 
            // CboIP
            // 
            this.CboIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboIP.Location = new System.Drawing.Point(100, 2);
            this.CboIP.Name = "CboIP";
            this.CboIP.Size = new System.Drawing.Size(121, 20);
            this.CboIP.TabIndex = 1;
            this.CboIP.Text = global::ZControl.Properties.Settings.Default.IP;
            this.CboIP.SelectedIndexChanged += new System.EventHandler(this.CboIP_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "局域网网卡选择:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 451);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelLog);
            this.Controls.Add(this.groupBoxMQTT);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ZContron PC端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBoxMQTT.ResumeLayout(false);
            this.groupBoxMQTT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMQTTPort)).EndInit();
            this.panelLog.ResumeLayout(false);
            this.panelLog.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxMQTT;
        private System.Windows.Forms.TextBox txtMQTTPassword;
        private System.Windows.Forms.TextBox txtMQTTUser;
        private System.Windows.Forms.NumericUpDown numMQTTPort;
        private System.Windows.Forms.TextBox txtMQTTServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.Label LabelLog;
        private System.Windows.Forms.Button btMQTTConfirm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnDeviceListDel;
        private System.Windows.Forms.Button btnDeviceListAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDeviceMQTTSend;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 内容CToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.Panel panelDeviceControl;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox CboIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labVersion;
        private System.Windows.Forms.TextBox txtLogAll;
    }
}

