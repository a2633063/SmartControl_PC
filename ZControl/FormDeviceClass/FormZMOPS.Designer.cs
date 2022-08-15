namespace ZControl.FormDeviceClass
{
    partial class FormZMOPS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelZDC1 = new System.Windows.Forms.Panel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.linkRefresh = new System.Windows.Forms.LinkLabel();
            this.picSwitch = new System.Windows.Forms.PictureBox();
            this.labSwitchName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkMOPSLedLock = new System.Windows.Forms.CheckBox();
            this.chkZMOPSChildLock = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panelZDC1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSwitch)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHass
            // 
            this.btnHass.Enabled = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.SetChildIndex(this.btnHass, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            // 
            // panelZDC1
            // 
            this.panelZDC1.BackColor = System.Drawing.Color.Transparent;
            this.panelZDC1.Controls.Add(this.chkMOPSLedLock);
            this.panelZDC1.Controls.Add(this.chkZMOPSChildLock);
            this.panelZDC1.Controls.Add(this.labelVersion);
            this.panelZDC1.Controls.Add(this.linkRefresh);
            this.panelZDC1.Controls.Add(this.picSwitch);
            this.panelZDC1.Controls.Add(this.labSwitchName);
            this.panelZDC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelZDC1.Location = new System.Drawing.Point(0, 55);
            this.panelZDC1.Name = "panelZDC1";
            this.panelZDC1.Size = new System.Drawing.Size(310, 295);
            this.panelZDC1.TabIndex = 28;
            // 
            // labelVersion
            // 
            this.labelVersion.Location = new System.Drawing.Point(32, 189);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(238, 18);
            this.labelVersion.TabIndex = 28;
            this.labelVersion.Text = "固件版本";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkRefresh
            // 
            this.linkRefresh.AutoSize = true;
            this.linkRefresh.Location = new System.Drawing.Point(32, 207);
            this.linkRefresh.Name = "linkRefresh";
            this.linkRefresh.Size = new System.Drawing.Size(77, 12);
            this.linkRefresh.TabIndex = 24;
            this.linkRefresh.TabStop = true;
            this.linkRefresh.Text = "更新获取状态";
            this.linkRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRefresh_LinkClicked);
            // 
            // picSwitch
            // 
            this.picSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSwitch.ErrorImage = null;
            this.picSwitch.Image = global::ZControl.Properties.Resources.device_close;
            this.picSwitch.InitialImage = null;
            this.picSwitch.Location = new System.Drawing.Point(118, 75);
            this.picSwitch.Name = "picSwitch";
            this.picSwitch.Size = new System.Drawing.Size(75, 47);
            this.picSwitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picSwitch.TabIndex = 14;
            this.picSwitch.TabStop = false;
            this.picSwitch.Tag = "";
            // 
            // labSwitchName
            // 
            this.labSwitchName.AutoSize = true;
            this.labSwitchName.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labSwitchName.Location = new System.Drawing.Point(131, 125);
            this.labSwitchName.Name = "labSwitchName";
            this.labSwitchName.Size = new System.Drawing.Size(49, 20);
            this.labSwitchName.TabIndex = 6;
            this.labSwitchName.Text = "开关";
            this.labSwitchName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(40, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 114);
            this.label2.TabIndex = 8;
            this.label2.Text = "注意: hass配置文件生成功能暂时未做验证!生成文件后请在hass中确认配置正确.若错误,请使用文档中hass配置方式";
            // 
            // chkMOPSLedLock
            // 
            this.chkMOPSLedLock.AutoSize = true;
            this.chkMOPSLedLock.Location = new System.Drawing.Point(198, 207);
            this.chkMOPSLedLock.Name = "chkMOPSLedLock";
            this.chkMOPSLedLock.Size = new System.Drawing.Size(72, 16);
            this.chkMOPSLedLock.TabIndex = 29;
            this.chkMOPSLedLock.Text = "夜间模式";
            this.chkMOPSLedLock.UseVisualStyleBackColor = true;
            this.chkMOPSLedLock.Click += new System.EventHandler(this.chkMOPSLedLock_Click);
            // 
            // chkZMOPSChildLock
            // 
            this.chkZMOPSChildLock.AutoSize = true;
            this.chkZMOPSChildLock.Location = new System.Drawing.Point(198, 191);
            this.chkZMOPSChildLock.Name = "chkZMOPSChildLock";
            this.chkZMOPSChildLock.Size = new System.Drawing.Size(48, 16);
            this.chkZMOPSChildLock.TabIndex = 30;
            this.chkZMOPSChildLock.Text = "童锁";
            this.chkZMOPSChildLock.UseVisualStyleBackColor = true;
            this.chkZMOPSChildLock.Click += new System.EventHandler(this.chkZMOPSChildLock_Click);
            // 
            // FormZMOPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 350);
            this.Controls.Add(this.panelZDC1);
            this.Name = "FormZMOPS";
            this.Text = "FormZMOPS";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panelZDC1, 0);
            this.panel1.ResumeLayout(false);
            this.panelZDC1.ResumeLayout(false);
            this.panelZDC1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSwitch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelZDC1;
        private System.Windows.Forms.LinkLabel linkRefresh;
        private System.Windows.Forms.PictureBox picSwitch;
        private System.Windows.Forms.Label labSwitchName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkMOPSLedLock;
        private System.Windows.Forms.CheckBox chkZMOPSChildLock;
    }
}