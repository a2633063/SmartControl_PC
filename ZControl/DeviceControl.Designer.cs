namespace ZControl
{
    partial class DeviceControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelMac = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.panelZTC1 = new System.Windows.Forms.Panel();
            this.labLock = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.labelZTC1TotalTime = new System.Windows.Forms.Label();
            this.picZTC1SwitchAll = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelZTC1Power = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picZTC1Switch5 = new System.Windows.Forms.PictureBox();
            this.picZTC1Switch0 = new System.Windows.Forms.PictureBox();
            this.picZTC1Switch1 = new System.Windows.Forms.PictureBox();
            this.picZTC1Switch4 = new System.Windows.Forms.PictureBox();
            this.picZTC1Switch2 = new System.Windows.Forms.PictureBox();
            this.picZTC1Switch3 = new System.Windows.Forms.PictureBox();
            this.labZTC1Switch5Name = new System.Windows.Forms.Label();
            this.labZTC1Switch4Name = new System.Windows.Forms.Label();
            this.labZTC1Switch3Name = new System.Windows.Forms.Label();
            this.labZTC1Switch2Name = new System.Windows.Forms.Label();
            this.labZTC1Switch1Name = new System.Windows.Forms.Label();
            this.labZTC1Switch0Name = new System.Windows.Forms.Label();
            this.panelZDC1 = new System.Windows.Forms.Panel();
            this.RegetZDC1 = new System.Windows.Forms.LinkLabel();
            this.labelZDC1TotalTime = new System.Windows.Forms.Label();
            this.labelZDC1Power = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.picZDC1Switch0 = new System.Windows.Forms.PictureBox();
            this.picZDC1Switch1 = new System.Windows.Forms.PictureBox();
            this.picZDC1Switch2 = new System.Windows.Forms.PictureBox();
            this.picZDC1Switch3 = new System.Windows.Forms.PictureBox();
            this.labZDC1Switch3Name = new System.Windows.Forms.Label();
            this.labZDC1Switch2Name = new System.Windows.Forms.Label();
            this.labZDC1Switch1Name = new System.Windows.Forms.Label();
            this.labZDC1Switch0Name = new System.Windows.Forms.Label();
            this.labelZDC1Voltage = new System.Windows.Forms.Label();
            this.labelZDC1Current = new System.Windows.Forms.Label();
            this.panelTitle.SuspendLayout();
            this.panelZTC1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picZTC1SwitchAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZTC1Switch5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZTC1Switch0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZTC1Switch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZTC1Switch4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZTC1Switch2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZTC1Switch3)).BeginInit();
            this.panelZDC1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picZDC1Switch0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZDC1Switch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZDC1Switch2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZDC1Switch3)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelTitle.Font = new System.Drawing.Font("宋体", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(306, 40);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "设备名称";
            // 
            // labelMac
            // 
            this.labelMac.AutoSize = true;
            this.labelMac.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelMac.Location = new System.Drawing.Point(0, 40);
            this.labelMac.Name = "labelMac";
            this.labelMac.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.labelMac.Size = new System.Drawing.Size(55, 12);
            this.labelMac.TabIndex = 1;
            this.labelMac.Text = "mac地址";
            this.labelMac.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.labelMac.DoubleClick += new System.EventHandler(this.LabelMac_DoubleClick);
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.Transparent;
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Controls.Add(this.labelMac);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(898, 55);
            this.panelTitle.TabIndex = 1;
            // 
            // panelZTC1
            // 
            this.panelZTC1.BackColor = System.Drawing.Color.Transparent;
            this.panelZTC1.Controls.Add(this.labLock);
            this.panelZTC1.Controls.Add(this.linkLabel1);
            this.panelZTC1.Controls.Add(this.labelZTC1TotalTime);
            this.panelZTC1.Controls.Add(this.picZTC1SwitchAll);
            this.panelZTC1.Controls.Add(this.label3);
            this.panelZTC1.Controls.Add(this.labelZTC1Power);
            this.panelZTC1.Controls.Add(this.label1);
            this.panelZTC1.Controls.Add(this.picZTC1Switch5);
            this.panelZTC1.Controls.Add(this.picZTC1Switch0);
            this.panelZTC1.Controls.Add(this.picZTC1Switch1);
            this.panelZTC1.Controls.Add(this.picZTC1Switch4);
            this.panelZTC1.Controls.Add(this.picZTC1Switch2);
            this.panelZTC1.Controls.Add(this.picZTC1Switch3);
            this.panelZTC1.Controls.Add(this.labZTC1Switch5Name);
            this.panelZTC1.Controls.Add(this.labZTC1Switch4Name);
            this.panelZTC1.Controls.Add(this.labZTC1Switch3Name);
            this.panelZTC1.Controls.Add(this.labZTC1Switch2Name);
            this.panelZTC1.Controls.Add(this.labZTC1Switch1Name);
            this.panelZTC1.Controls.Add(this.labZTC1Switch0Name);
            this.panelZTC1.Location = new System.Drawing.Point(0, 0);
            this.panelZTC1.Name = "panelZTC1";
            this.panelZTC1.Size = new System.Drawing.Size(330, 353);
            this.panelZTC1.TabIndex = 0;
            // 
            // labLock
            // 
            this.labLock.Location = new System.Drawing.Point(256, 58);
            this.labLock.Name = "labLock";
            this.labLock.Size = new System.Drawing.Size(54, 14);
            this.labLock.TabIndex = 25;
            this.labLock.TabStop = true;
            this.labLock.Text = "未激活";
            this.labLock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labLock.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(39, 299);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(77, 12);
            this.linkLabel1.TabIndex = 24;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "更新获取状态";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // labelZTC1TotalTime
            // 
            this.labelZTC1TotalTime.Location = new System.Drawing.Point(39, 281);
            this.labelZTC1TotalTime.Name = "labelZTC1TotalTime";
            this.labelZTC1TotalTime.Size = new System.Drawing.Size(238, 16);
            this.labelZTC1TotalTime.TabIndex = 23;
            this.labelZTC1TotalTime.Text = "当前时间";
            // 
            // picZTC1SwitchAll
            // 
            this.picZTC1SwitchAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picZTC1SwitchAll.ErrorImage = null;
            this.picZTC1SwitchAll.Image = global::ZControl.Properties.Resources.device_close;
            this.picZTC1SwitchAll.InitialImage = null;
            this.picZTC1SwitchAll.Location = new System.Drawing.Point(64, 63);
            this.picZTC1SwitchAll.Name = "picZTC1SwitchAll";
            this.picZTC1SwitchAll.Size = new System.Drawing.Size(65, 32);
            this.picZTC1SwitchAll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picZTC1SwitchAll.TabIndex = 22;
            this.picZTC1SwitchAll.TabStop = false;
            this.picZTC1SwitchAll.Tag = "";
            this.picZTC1SwitchAll.Click += new System.EventHandler(this.PicZTC1SwitchAll_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(60, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "总开关";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelZTC1Power
            // 
            this.labelZTC1Power.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelZTC1Power.Location = new System.Drawing.Point(145, 88);
            this.labelZTC1Power.Name = "labelZTC1Power";
            this.labelZTC1Power.Size = new System.Drawing.Size(124, 23);
            this.labelZTC1Power.TabIndex = 20;
            this.labelZTC1Power.Text = "----";
            this.labelZTC1Power.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "当前功率";
            // 
            // picZTC1Switch5
            // 
            this.picZTC1Switch5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picZTC1Switch5.ErrorImage = null;
            this.picZTC1Switch5.Image = global::ZControl.Properties.Resources.device_close;
            this.picZTC1Switch5.InitialImage = null;
            this.picZTC1Switch5.Location = new System.Drawing.Point(222, 208);
            this.picZTC1Switch5.Name = "picZTC1Switch5";
            this.picZTC1Switch5.Size = new System.Drawing.Size(55, 32);
            this.picZTC1Switch5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picZTC1Switch5.TabIndex = 18;
            this.picZTC1Switch5.TabStop = false;
            this.picZTC1Switch5.Tag = "";
            // 
            // picZTC1Switch0
            // 
            this.picZTC1Switch0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picZTC1Switch0.ErrorImage = null;
            this.picZTC1Switch0.Image = global::ZControl.Properties.Resources.device_close;
            this.picZTC1Switch0.InitialImage = null;
            this.picZTC1Switch0.Location = new System.Drawing.Point(40, 133);
            this.picZTC1Switch0.Name = "picZTC1Switch0";
            this.picZTC1Switch0.Size = new System.Drawing.Size(55, 32);
            this.picZTC1Switch0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picZTC1Switch0.TabIndex = 14;
            this.picZTC1Switch0.TabStop = false;
            this.picZTC1Switch0.Tag = "";
            // 
            // picZTC1Switch1
            // 
            this.picZTC1Switch1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picZTC1Switch1.ErrorImage = null;
            this.picZTC1Switch1.Image = global::ZControl.Properties.Resources.device_close;
            this.picZTC1Switch1.InitialImage = null;
            this.picZTC1Switch1.Location = new System.Drawing.Point(131, 133);
            this.picZTC1Switch1.Name = "picZTC1Switch1";
            this.picZTC1Switch1.Size = new System.Drawing.Size(55, 32);
            this.picZTC1Switch1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picZTC1Switch1.TabIndex = 13;
            this.picZTC1Switch1.TabStop = false;
            this.picZTC1Switch1.Tag = "";
            // 
            // picZTC1Switch4
            // 
            this.picZTC1Switch4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picZTC1Switch4.ErrorImage = null;
            this.picZTC1Switch4.Image = global::ZControl.Properties.Resources.device_close;
            this.picZTC1Switch4.InitialImage = null;
            this.picZTC1Switch4.Location = new System.Drawing.Point(131, 208);
            this.picZTC1Switch4.Name = "picZTC1Switch4";
            this.picZTC1Switch4.Size = new System.Drawing.Size(55, 32);
            this.picZTC1Switch4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picZTC1Switch4.TabIndex = 17;
            this.picZTC1Switch4.TabStop = false;
            this.picZTC1Switch4.Tag = "";
            // 
            // picZTC1Switch2
            // 
            this.picZTC1Switch2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picZTC1Switch2.ErrorImage = null;
            this.picZTC1Switch2.Image = global::ZControl.Properties.Resources.device_close;
            this.picZTC1Switch2.InitialImage = null;
            this.picZTC1Switch2.Location = new System.Drawing.Point(222, 133);
            this.picZTC1Switch2.Name = "picZTC1Switch2";
            this.picZTC1Switch2.Size = new System.Drawing.Size(55, 32);
            this.picZTC1Switch2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picZTC1Switch2.TabIndex = 15;
            this.picZTC1Switch2.TabStop = false;
            this.picZTC1Switch2.Tag = "";
            // 
            // picZTC1Switch3
            // 
            this.picZTC1Switch3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picZTC1Switch3.ErrorImage = null;
            this.picZTC1Switch3.Image = global::ZControl.Properties.Resources.device_close;
            this.picZTC1Switch3.InitialImage = null;
            this.picZTC1Switch3.Location = new System.Drawing.Point(40, 208);
            this.picZTC1Switch3.Name = "picZTC1Switch3";
            this.picZTC1Switch3.Size = new System.Drawing.Size(55, 32);
            this.picZTC1Switch3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picZTC1Switch3.TabIndex = 16;
            this.picZTC1Switch3.TabStop = false;
            this.picZTC1Switch3.Tag = "";
            // 
            // labZTC1Switch5Name
            // 
            this.labZTC1Switch5Name.AutoSize = true;
            this.labZTC1Switch5Name.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labZTC1Switch5Name.Location = new System.Drawing.Point(218, 243);
            this.labZTC1Switch5Name.Name = "labZTC1Switch5Name";
            this.labZTC1Switch5Name.Size = new System.Drawing.Size(59, 20);
            this.labZTC1Switch5Name.TabIndex = 12;
            this.labZTC1Switch5Name.Text = "插座6";
            this.labZTC1Switch5Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labZTC1Switch4Name
            // 
            this.labZTC1Switch4Name.AutoSize = true;
            this.labZTC1Switch4Name.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labZTC1Switch4Name.Location = new System.Drawing.Point(127, 243);
            this.labZTC1Switch4Name.Name = "labZTC1Switch4Name";
            this.labZTC1Switch4Name.Size = new System.Drawing.Size(59, 20);
            this.labZTC1Switch4Name.TabIndex = 11;
            this.labZTC1Switch4Name.Text = "插座5";
            this.labZTC1Switch4Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labZTC1Switch3Name
            // 
            this.labZTC1Switch3Name.AutoSize = true;
            this.labZTC1Switch3Name.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labZTC1Switch3Name.Location = new System.Drawing.Point(36, 243);
            this.labZTC1Switch3Name.Name = "labZTC1Switch3Name";
            this.labZTC1Switch3Name.Size = new System.Drawing.Size(59, 20);
            this.labZTC1Switch3Name.TabIndex = 10;
            this.labZTC1Switch3Name.Text = "插座4";
            this.labZTC1Switch3Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labZTC1Switch2Name
            // 
            this.labZTC1Switch2Name.AutoSize = true;
            this.labZTC1Switch2Name.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labZTC1Switch2Name.Location = new System.Drawing.Point(218, 168);
            this.labZTC1Switch2Name.Name = "labZTC1Switch2Name";
            this.labZTC1Switch2Name.Size = new System.Drawing.Size(59, 20);
            this.labZTC1Switch2Name.TabIndex = 9;
            this.labZTC1Switch2Name.Text = "插座3";
            this.labZTC1Switch2Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labZTC1Switch1Name
            // 
            this.labZTC1Switch1Name.AutoSize = true;
            this.labZTC1Switch1Name.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labZTC1Switch1Name.Location = new System.Drawing.Point(127, 168);
            this.labZTC1Switch1Name.Name = "labZTC1Switch1Name";
            this.labZTC1Switch1Name.Size = new System.Drawing.Size(59, 20);
            this.labZTC1Switch1Name.TabIndex = 8;
            this.labZTC1Switch1Name.Text = "插座2";
            this.labZTC1Switch1Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labZTC1Switch0Name
            // 
            this.labZTC1Switch0Name.AutoSize = true;
            this.labZTC1Switch0Name.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labZTC1Switch0Name.Location = new System.Drawing.Point(37, 168);
            this.labZTC1Switch0Name.Name = "labZTC1Switch0Name";
            this.labZTC1Switch0Name.Size = new System.Drawing.Size(59, 20);
            this.labZTC1Switch0Name.TabIndex = 6;
            this.labZTC1Switch0Name.Text = "插座1";
            this.labZTC1Switch0Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelZDC1
            // 
            this.panelZDC1.BackColor = System.Drawing.Color.Transparent;
            this.panelZDC1.Controls.Add(this.labelZDC1Current);
            this.panelZDC1.Controls.Add(this.labelZDC1Voltage);
            this.panelZDC1.Controls.Add(this.RegetZDC1);
            this.panelZDC1.Controls.Add(this.labelZDC1TotalTime);
            this.panelZDC1.Controls.Add(this.labelZDC1Power);
            this.panelZDC1.Controls.Add(this.label6);
            this.panelZDC1.Controls.Add(this.picZDC1Switch0);
            this.panelZDC1.Controls.Add(this.picZDC1Switch1);
            this.panelZDC1.Controls.Add(this.picZDC1Switch2);
            this.panelZDC1.Controls.Add(this.picZDC1Switch3);
            this.panelZDC1.Controls.Add(this.labZDC1Switch3Name);
            this.panelZDC1.Controls.Add(this.labZDC1Switch2Name);
            this.panelZDC1.Controls.Add(this.labZDC1Switch1Name);
            this.panelZDC1.Controls.Add(this.labZDC1Switch0Name);
            this.panelZDC1.Location = new System.Drawing.Point(349, 0);
            this.panelZDC1.Name = "panelZDC1";
            this.panelZDC1.Size = new System.Drawing.Size(310, 353);
            this.panelZDC1.TabIndex = 27;
            // 
            // RegetZDC1
            // 
            this.RegetZDC1.AutoSize = true;
            this.RegetZDC1.Location = new System.Drawing.Point(39, 271);
            this.RegetZDC1.Name = "RegetZDC1";
            this.RegetZDC1.Size = new System.Drawing.Size(77, 12);
            this.RegetZDC1.TabIndex = 24;
            this.RegetZDC1.TabStop = true;
            this.RegetZDC1.Text = "更新获取状态";
            // 
            // labelZDC1TotalTime
            // 
            this.labelZDC1TotalTime.Location = new System.Drawing.Point(39, 253);
            this.labelZDC1TotalTime.Name = "labelZDC1TotalTime";
            this.labelZDC1TotalTime.Size = new System.Drawing.Size(238, 16);
            this.labelZDC1TotalTime.TabIndex = 23;
            this.labelZDC1TotalTime.Text = "当前时间";
            // 
            // labelZDC1Power
            // 
            this.labelZDC1Power.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelZDC1Power.Location = new System.Drawing.Point(118, 85);
            this.labelZDC1Power.Name = "labelZDC1Power";
            this.labelZDC1Power.Size = new System.Drawing.Size(74, 23);
            this.labelZDC1Power.TabIndex = 20;
            this.labelZDC1Power.Text = "----";
            this.labelZDC1Power.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(129, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "当前功率";
            // 
            // picZDC1Switch0
            // 
            this.picZDC1Switch0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picZDC1Switch0.ErrorImage = null;
            this.picZDC1Switch0.Image = global::ZControl.Properties.Resources.device_close;
            this.picZDC1Switch0.InitialImage = null;
            this.picZDC1Switch0.Location = new System.Drawing.Point(37, 63);
            this.picZDC1Switch0.Name = "picZDC1Switch0";
            this.picZDC1Switch0.Size = new System.Drawing.Size(55, 32);
            this.picZDC1Switch0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picZDC1Switch0.TabIndex = 14;
            this.picZDC1Switch0.TabStop = false;
            this.picZDC1Switch0.Tag = "";
            // 
            // picZDC1Switch1
            // 
            this.picZDC1Switch1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picZDC1Switch1.ErrorImage = null;
            this.picZDC1Switch1.Image = global::ZControl.Properties.Resources.device_close;
            this.picZDC1Switch1.InitialImage = null;
            this.picZDC1Switch1.Location = new System.Drawing.Point(37, 138);
            this.picZDC1Switch1.Name = "picZDC1Switch1";
            this.picZDC1Switch1.Size = new System.Drawing.Size(55, 32);
            this.picZDC1Switch1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picZDC1Switch1.TabIndex = 13;
            this.picZDC1Switch1.TabStop = false;
            this.picZDC1Switch1.Tag = "";
            // 
            // picZDC1Switch2
            // 
            this.picZDC1Switch2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picZDC1Switch2.ErrorImage = null;
            this.picZDC1Switch2.Image = global::ZControl.Properties.Resources.device_close;
            this.picZDC1Switch2.InitialImage = null;
            this.picZDC1Switch2.Location = new System.Drawing.Point(128, 138);
            this.picZDC1Switch2.Name = "picZDC1Switch2";
            this.picZDC1Switch2.Size = new System.Drawing.Size(55, 32);
            this.picZDC1Switch2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picZDC1Switch2.TabIndex = 15;
            this.picZDC1Switch2.TabStop = false;
            this.picZDC1Switch2.Tag = "";
            // 
            // picZDC1Switch3
            // 
            this.picZDC1Switch3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picZDC1Switch3.ErrorImage = null;
            this.picZDC1Switch3.Image = global::ZControl.Properties.Resources.device_close;
            this.picZDC1Switch3.InitialImage = null;
            this.picZDC1Switch3.Location = new System.Drawing.Point(219, 138);
            this.picZDC1Switch3.Name = "picZDC1Switch3";
            this.picZDC1Switch3.Size = new System.Drawing.Size(55, 32);
            this.picZDC1Switch3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picZDC1Switch3.TabIndex = 16;
            this.picZDC1Switch3.TabStop = false;
            this.picZDC1Switch3.Tag = "";
            // 
            // labZDC1Switch3Name
            // 
            this.labZDC1Switch3Name.AutoSize = true;
            this.labZDC1Switch3Name.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labZDC1Switch3Name.Location = new System.Drawing.Point(215, 173);
            this.labZDC1Switch3Name.Name = "labZDC1Switch3Name";
            this.labZDC1Switch3Name.Size = new System.Drawing.Size(59, 20);
            this.labZDC1Switch3Name.TabIndex = 10;
            this.labZDC1Switch3Name.Text = "插座4";
            this.labZDC1Switch3Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labZDC1Switch2Name
            // 
            this.labZDC1Switch2Name.AutoSize = true;
            this.labZDC1Switch2Name.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labZDC1Switch2Name.Location = new System.Drawing.Point(124, 173);
            this.labZDC1Switch2Name.Name = "labZDC1Switch2Name";
            this.labZDC1Switch2Name.Size = new System.Drawing.Size(59, 20);
            this.labZDC1Switch2Name.TabIndex = 9;
            this.labZDC1Switch2Name.Text = "插座3";
            this.labZDC1Switch2Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labZDC1Switch1Name
            // 
            this.labZDC1Switch1Name.AutoSize = true;
            this.labZDC1Switch1Name.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labZDC1Switch1Name.Location = new System.Drawing.Point(33, 173);
            this.labZDC1Switch1Name.Name = "labZDC1Switch1Name";
            this.labZDC1Switch1Name.Size = new System.Drawing.Size(59, 20);
            this.labZDC1Switch1Name.TabIndex = 8;
            this.labZDC1Switch1Name.Text = "插座2";
            this.labZDC1Switch1Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labZDC1Switch0Name
            // 
            this.labZDC1Switch0Name.AutoSize = true;
            this.labZDC1Switch0Name.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labZDC1Switch0Name.Location = new System.Drawing.Point(34, 98);
            this.labZDC1Switch0Name.Name = "labZDC1Switch0Name";
            this.labZDC1Switch0Name.Size = new System.Drawing.Size(59, 20);
            this.labZDC1Switch0Name.TabIndex = 6;
            this.labZDC1Switch0Name.Text = "插座1";
            this.labZDC1Switch0Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelZDC1Voltage
            // 
            this.labelZDC1Voltage.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelZDC1Voltage.Location = new System.Drawing.Point(209, 71);
            this.labelZDC1Voltage.Name = "labelZDC1Voltage";
            this.labelZDC1Voltage.Size = new System.Drawing.Size(74, 23);
            this.labelZDC1Voltage.TabIndex = 25;
            this.labelZDC1Voltage.Text = "----";
            this.labelZDC1Voltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelZDC1Current
            // 
            this.labelZDC1Current.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelZDC1Current.Location = new System.Drawing.Point(209, 92);
            this.labelZDC1Current.Name = "labelZDC1Current";
            this.labelZDC1Current.Size = new System.Drawing.Size(74, 23);
            this.labelZDC1Current.TabIndex = 26;
            this.labelZDC1Current.Text = "----";
            this.labelZDC1Current.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DeviceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelZDC1);
            this.Controls.Add(this.panelZTC1);
            this.MaximumSize = new System.Drawing.Size(900, 355);
            this.MinimumSize = new System.Drawing.Size(312, 355);
            this.Name = "DeviceControl";
            this.Size = new System.Drawing.Size(898, 353);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelZTC1.ResumeLayout(false);
            this.panelZTC1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picZTC1SwitchAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZTC1Switch5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZTC1Switch0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZTC1Switch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZTC1Switch4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZTC1Switch2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZTC1Switch3)).EndInit();
            this.panelZDC1.ResumeLayout(false);
            this.panelZDC1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picZDC1Switch0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZDC1Switch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZDC1Switch2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZDC1Switch3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelMac;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelZTC1;
        private System.Windows.Forms.LinkLabel labLock;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label labelZTC1TotalTime;
        private System.Windows.Forms.PictureBox picZTC1SwitchAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelZTC1Power;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picZTC1Switch5;
        private System.Windows.Forms.PictureBox picZTC1Switch0;
        private System.Windows.Forms.PictureBox picZTC1Switch1;
        private System.Windows.Forms.PictureBox picZTC1Switch4;
        private System.Windows.Forms.PictureBox picZTC1Switch2;
        private System.Windows.Forms.PictureBox picZTC1Switch3;
        private System.Windows.Forms.Label labZTC1Switch5Name;
        private System.Windows.Forms.Label labZTC1Switch4Name;
        private System.Windows.Forms.Label labZTC1Switch3Name;
        private System.Windows.Forms.Label labZTC1Switch2Name;
        private System.Windows.Forms.Label labZTC1Switch1Name;
        private System.Windows.Forms.Label labZTC1Switch0Name;
        private System.Windows.Forms.Panel panelZDC1;
        private System.Windows.Forms.LinkLabel RegetZDC1;
        private System.Windows.Forms.Label labelZDC1TotalTime;
        private System.Windows.Forms.Label labelZDC1Power;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox picZDC1Switch0;
        private System.Windows.Forms.PictureBox picZDC1Switch1;
        private System.Windows.Forms.PictureBox picZDC1Switch2;
        private System.Windows.Forms.PictureBox picZDC1Switch3;
        private System.Windows.Forms.Label labZDC1Switch3Name;
        private System.Windows.Forms.Label labZDC1Switch2Name;
        private System.Windows.Forms.Label labZDC1Switch1Name;
        private System.Windows.Forms.Label labZDC1Switch0Name;
        private System.Windows.Forms.Label labelZDC1Current;
        private System.Windows.Forms.Label labelZDC1Voltage;
    }
}
