namespace ZControl.FormDeviceClass
{
    partial class FormZS7
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
            this.labelVersion = new System.Windows.Forms.Label();
            this.linkRefresh = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.labWeight = new System.Windows.Forms.Label();
            this.labLastTime = new System.Windows.Forms.Label();
            this.chkHeat = new System.Windows.Forms.CheckBox();
            this.labZS7Log = new System.Windows.Forms.Label();
            this.LstHistory = new System.Windows.Forms.ListBox();
            this.labBattery = new System.Windows.Forms.Label();
            this.labCharge = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelVersion
            // 
            this.labelVersion.Location = new System.Drawing.Point(12, 293);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(238, 18);
            this.labelVersion.TabIndex = 32;
            this.labelVersion.Text = "固件版本";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkRefresh
            // 
            this.linkRefresh.AutoSize = true;
            this.linkRefresh.Location = new System.Drawing.Point(12, 311);
            this.linkRefresh.Name = "linkRefresh";
            this.linkRefresh.Size = new System.Drawing.Size(77, 12);
            this.linkRefresh.TabIndex = 31;
            this.linkRefresh.TabStop = true;
            this.linkRefresh.Text = "更新获取状态";
            this.linkRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRefresh_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(117, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 37;
            this.label1.Text = "最近测量体重";
            // 
            // labWeight
            // 
            this.labWeight.AutoSize = true;
            this.labWeight.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labWeight.Location = new System.Drawing.Point(77, 78);
            this.labWeight.Name = "labWeight";
            this.labWeight.Size = new System.Drawing.Size(157, 40);
            this.labWeight.TabIndex = 38;
            this.labWeight.Text = "-----kg";
            // 
            // labLastTime
            // 
            this.labLastTime.Location = new System.Drawing.Point(8, 122);
            this.labLastTime.Name = "labLastTime";
            this.labLastTime.Size = new System.Drawing.Size(294, 12);
            this.labLastTime.TabIndex = 39;
            this.labLastTime.Text = "上次测量时间:----/--/-- --:--";
            this.labLastTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkHeat
            // 
            this.chkHeat.AutoSize = true;
            this.chkHeat.Location = new System.Drawing.Point(131, 140);
            this.chkHeat.Name = "chkHeat";
            this.chkHeat.Size = new System.Drawing.Size(48, 16);
            this.chkHeat.TabIndex = 40;
            this.chkHeat.Text = "加热";
            this.chkHeat.UseVisualStyleBackColor = true;
            this.chkHeat.Click += new System.EventHandler(this.chkHeat_Click);
            // 
            // labZS7Log
            // 
            this.labZS7Log.AutoSize = true;
            this.labZS7Log.Location = new System.Drawing.Point(12, 327);
            this.labZS7Log.Name = "labZS7Log";
            this.labZS7Log.Size = new System.Drawing.Size(53, 12);
            this.labZS7Log.TabIndex = 41;
            this.labZS7Log.Text = "设备离线";
            this.labZS7Log.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labZS7Log.Visible = false;
            // 
            // LstHistory
            // 
            this.LstHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LstHistory.FormattingEnabled = true;
            this.LstHistory.ItemHeight = 12;
            this.LstHistory.Items.AddRange(new object[] {
            "",
            "",
            "",
            "",
            "          未获取到数据       "});
            this.LstHistory.Location = new System.Drawing.Point(54, 162);
            this.LstHistory.Name = "LstHistory";
            this.LstHistory.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.LstHistory.Size = new System.Drawing.Size(196, 120);
            this.LstHistory.TabIndex = 42;
            // 
            // labBattery
            // 
            this.labBattery.AutoSize = true;
            this.labBattery.Location = new System.Drawing.Point(249, 327);
            this.labBattery.Name = "labBattery";
            this.labBattery.Size = new System.Drawing.Size(59, 12);
            this.labBattery.TabIndex = 43;
            this.labBattery.Text = "电量:100%";
            this.labBattery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labBattery.Visible = false;
            // 
            // labCharge
            // 
            this.labCharge.AutoSize = true;
            this.labCharge.Location = new System.Drawing.Point(267, 313);
            this.labCharge.Name = "labCharge";
            this.labCharge.Size = new System.Drawing.Size(41, 12);
            this.labCharge.TabIndex = 44;
            this.labCharge.Text = "充电中";
            this.labCharge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labCharge.Visible = false;
            // 
            // FormZS7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(620, 350);
            this.Controls.Add(this.labCharge);
            this.Controls.Add(this.labBattery);
            this.Controls.Add(this.LstHistory);
            this.Controls.Add(this.labZS7Log);
            this.Controls.Add(this.chkHeat);
            this.Controls.Add(this.labLastTime);
            this.Controls.Add(this.labWeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.linkRefresh);
            this.Name = "FormZS7";
            this.Text = "FormZS7";
            this.Controls.SetChildIndex(this.linkRefresh, 0);
            this.Controls.SetChildIndex(this.labelVersion, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.labWeight, 0);
            this.Controls.SetChildIndex(this.labLastTime, 0);
            this.Controls.SetChildIndex(this.chkHeat, 0);
            this.Controls.SetChildIndex(this.labZS7Log, 0);
            this.Controls.SetChildIndex(this.LstHistory, 0);
            this.Controls.SetChildIndex(this.labBattery, 0);
            this.Controls.SetChildIndex(this.labCharge, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.LinkLabel linkRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labWeight;
        private System.Windows.Forms.Label labLastTime;
        private System.Windows.Forms.CheckBox chkHeat;
        private System.Windows.Forms.Label labZS7Log;
        private System.Windows.Forms.ListBox LstHistory;
        private System.Windows.Forms.Label labBattery;
        private System.Windows.Forms.Label labCharge;
    }
}