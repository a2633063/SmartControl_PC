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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBoxMQTT = new System.Windows.Forms.GroupBox();
            this.btMQTTConfirm = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelLog = new System.Windows.Forms.Panel();
            this.LabelLog = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeviceListDel = new System.Windows.Forms.Button();
            this.btnDeviceMQTTSend = new System.Windows.Forms.Button();
            this.btnDeviceListAdd = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.内容CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.索引IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.搜索SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zDC1工具toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zDC1热点配网toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtMQTTPassword = new System.Windows.Forms.TextBox();
            this.txtMQTTUser = new System.Windows.Forms.TextBox();
            this.numMQTTPort = new System.Windows.Forms.NumericUpDown();
            this.txtMQTTServer = new System.Windows.Forms.TextBox();
            this.labVersion = new System.Windows.Forms.Label();
            this.deviceControl1 = new ZControl.DeviceControl();
            this.groupBoxMQTT.SuspendLayout();
            this.panelLog.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMQTTPort)).BeginInit();
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
            this.groupBoxMQTT.Size = new System.Drawing.Size(589, 43);
            this.groupBoxMQTT.TabIndex = 3;
            this.groupBoxMQTT.TabStop = false;
            this.groupBoxMQTT.Text = "MQTT服务器配置";
            // 
            // btMQTTConfirm
            // 
            this.btMQTTConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMQTTConfirm.Image = global::ZControl.Properties.Resources.close;
            this.btMQTTConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMQTTConfirm.Location = new System.Drawing.Point(529, 9);
            this.btMQTTConfirm.Name = "btMQTTConfirm";
            this.btMQTTConfirm.Size = new System.Drawing.Size(54, 31);
            this.btMQTTConfirm.TabIndex = 8;
            this.btMQTTConfirm.Text = "连接";
            this.btMQTTConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btMQTTConfirm.UseVisualStyleBackColor = true;
            this.btMQTTConfirm.Click += new System.EventHandler(this.BtMQTTConfirm_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(396, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "密码:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "登录名:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 18);
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
            this.panelLog.Controls.Add(this.LabelLog);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLog.Location = new System.Drawing.Point(0, 425);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(589, 25);
            this.panelLog.TabIndex = 4;
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
            this.panel1.Controls.Add(this.btnDeviceListDel);
            this.panel1.Controls.Add(this.btnDeviceMQTTSend);
            this.panel1.Controls.Add(this.btnDeviceListAdd);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 357);
            this.panel1.TabIndex = 5;
            // 
            // btnDeviceListDel
            // 
            this.btnDeviceListDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeviceListDel.Location = new System.Drawing.Point(129, 313);
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
            this.btnDeviceMQTTSend.Location = new System.Drawing.Point(3, 334);
            this.btnDeviceMQTTSend.Name = "btnDeviceMQTTSend";
            this.btnDeviceMQTTSend.Size = new System.Drawing.Size(126, 23);
            this.btnDeviceMQTTSend.TabIndex = 1;
            this.btnDeviceMQTTSend.Text = "同步MQTT服务器";
            this.btnDeviceMQTTSend.UseVisualStyleBackColor = true;
            this.btnDeviceMQTTSend.Click += new System.EventHandler(this.BtnDeviceMQTTSend_Click);
            // 
            // btnDeviceListAdd
            // 
            this.btnDeviceListAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeviceListAdd.Location = new System.Drawing.Point(3, 313);
            this.btnDeviceListAdd.Name = "btnDeviceListAdd";
            this.btnDeviceListAdd.Size = new System.Drawing.Size(126, 23);
            this.btnDeviceListAdd.TabIndex = 1;
            this.btnDeviceListAdd.Text = "获取局域网设备";
            this.btnDeviceListAdd.UseVisualStyleBackColor = true;
            this.btnDeviceListAdd.Click += new System.EventHandler(this.BtnDeviceListAdd_Click);
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
            this.listBox1.Size = new System.Drawing.Size(258, 313);
            this.listBox1.TabIndex = 0;
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox1_DrawItem);
            this.listBox1.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ListBox1_MeasureItem);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.deviceControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(258, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(331, 357);
            this.panel2.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.工具TToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(589, 25);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建NToolStripMenuItem,
            this.打开OToolStripMenuItem,
            this.toolStripSeparator,
            this.保存SToolStripMenuItem,
            this.另存为AToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出XToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 新建NToolStripMenuItem
            // 
            this.新建NToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("新建NToolStripMenuItem.Image")));
            this.新建NToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.新建NToolStripMenuItem.Name = "新建NToolStripMenuItem";
            this.新建NToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.新建NToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.新建NToolStripMenuItem.Text = "新建(&N)";
            // 
            // 打开OToolStripMenuItem
            // 
            this.打开OToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("打开OToolStripMenuItem.Image")));
            this.打开OToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打开OToolStripMenuItem.Name = "打开OToolStripMenuItem";
            this.打开OToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.打开OToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.打开OToolStripMenuItem.Text = "打开(&O)";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(162, 6);
            // 
            // 保存SToolStripMenuItem
            // 
            this.保存SToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("保存SToolStripMenuItem.Image")));
            this.保存SToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.保存SToolStripMenuItem.Name = "保存SToolStripMenuItem";
            this.保存SToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.保存SToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.保存SToolStripMenuItem.Text = "保存(&S)";
            // 
            // 另存为AToolStripMenuItem
            // 
            this.另存为AToolStripMenuItem.Name = "另存为AToolStripMenuItem";
            this.另存为AToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.另存为AToolStripMenuItem.Text = "另存为(&A)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // 退出XToolStripMenuItem
            // 
            this.退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            this.退出XToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.退出XToolStripMenuItem.Text = "退出(&X)";
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zDC1工具toolStripMenuItem});
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.工具TToolStripMenuItem.Text = "工具(&T)";
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.内容CToolStripMenuItem,
            this.索引IToolStripMenuItem,
            this.搜索SToolStripMenuItem,
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
            // 索引IToolStripMenuItem
            // 
            this.索引IToolStripMenuItem.Name = "索引IToolStripMenuItem";
            this.索引IToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.索引IToolStripMenuItem.Text = "索引(&I)";
            // 
            // 搜索SToolStripMenuItem
            // 
            this.搜索SToolStripMenuItem.Name = "搜索SToolStripMenuItem";
            this.搜索SToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.搜索SToolStripMenuItem.Text = "搜索(&S)";
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
            // zDC1工具toolStripMenuItem
            // 
            this.zDC1工具toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zDC1热点配网toolStripMenuItem});
            this.zDC1工具toolStripMenuItem.Name = "zDC1工具toolStripMenuItem";
            this.zDC1工具toolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.zDC1工具toolStripMenuItem.Text = "zDC1工具";
            // 
            // zDC1热点配网toolStripMenuItem
            // 
            this.zDC1热点配网toolStripMenuItem.CheckOnClick = true;
            this.zDC1热点配网toolStripMenuItem.Name = "zDC1热点配网toolStripMenuItem";
            this.zDC1热点配网toolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.zDC1热点配网toolStripMenuItem.Text = "zDC1热点配网模式";
            this.zDC1热点配网toolStripMenuItem.Click += new System.EventHandler(this.ZDC1热点配网toolStripMenuItem_Click);
            // 
            // txtMQTTPassword
            // 
            this.txtMQTTPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMQTTPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ZControl.Properties.Settings.Default, "MQTTPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtMQTTPassword.Location = new System.Drawing.Point(429, 14);
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
            this.txtMQTTUser.Location = new System.Drawing.Point(306, 14);
            this.txtMQTTUser.Name = "txtMQTTUser";
            this.txtMQTTUser.Size = new System.Drawing.Size(87, 21);
            this.txtMQTTUser.TabIndex = 6;
            this.txtMQTTUser.Text = global::ZControl.Properties.Settings.Default.MQTTUser;
            // 
            // numMQTTPort
            // 
            this.numMQTTPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numMQTTPort.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ZControl.Properties.Settings.Default, "MQTTPort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numMQTTPort.Location = new System.Drawing.Point(189, 14);
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
            this.txtMQTTServer.Size = new System.Drawing.Size(102, 21);
            this.txtMQTTServer.TabIndex = 4;
            this.txtMQTTServer.Text = global::ZControl.Properties.Settings.Default.MQTTServer;
            // 
            // labVersion
            // 
            this.labVersion.AutoSize = true;
            this.labVersion.BackColor = System.Drawing.Color.White;
            this.labVersion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labVersion.Location = new System.Drawing.Point(488, 10);
            this.labVersion.Name = "labVersion";
            this.labVersion.Size = new System.Drawing.Size(101, 12);
            this.labVersion.TabIndex = 8;
            this.labVersion.Text = "软件版本v0.0.0.0";
            // 
            // deviceControl1
            // 
            this.deviceControl1.AutoCheck = false;
            this.deviceControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deviceControl1.Device = null;
            this.deviceControl1.Location = new System.Drawing.Point(9, 7);
            this.deviceControl1.MaximumSize = new System.Drawing.Size(312, 355);
            this.deviceControl1.MinimumSize = new System.Drawing.Size(312, 355);
            this.deviceControl1.Name = "deviceControl1";
            this.deviceControl1.Size = new System.Drawing.Size(312, 355);
            this.deviceControl1.TabIndex = 0;
            this.deviceControl1.ZDC1WifiShow = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 450);
            this.Controls.Add(this.labVersion);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelLog);
            this.Controls.Add(this.groupBoxMQTT);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ZContron PC端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBoxMQTT.ResumeLayout(false);
            this.groupBoxMQTT.PerformLayout();
            this.panelLog.ResumeLayout(false);
            this.panelLog.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMQTTPort)).EndInit();
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
        private DeviceControl deviceControl1;
        private System.Windows.Forms.Button btnDeviceMQTTSend;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开OToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem 保存SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为AToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 退出XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 内容CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 索引IToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 搜索SToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zDC1工具toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zDC1热点配网toolStripMenuItem;
        private System.Windows.Forms.Label labVersion;
    }
}

