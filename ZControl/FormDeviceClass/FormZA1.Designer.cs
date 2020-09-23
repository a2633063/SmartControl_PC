namespace ZControl.FormDeviceClass
{
    partial class FormZA1
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
            this.components = new System.ComponentModel.Container();
            this.trbSpeed = new System.Windows.Forms.TrackBar();
            this.labelVersion = new System.Windows.Forms.Label();
            this.linkRefresh = new System.Windows.Forms.LinkLabel();
            this.labSpeed = new System.Windows.Forms.Label();
            this.chkSwitch = new System.Windows.Forms.CheckBox();
            this.timerSend = new System.Windows.Forms.Timer(this.components);
            this.labLock = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // trbSpeed
            // 
            this.trbSpeed.Location = new System.Drawing.Point(15, 157);
            this.trbSpeed.Maximum = 100;
            this.trbSpeed.Minimum = 1;
            this.trbSpeed.Name = "trbSpeed";
            this.trbSpeed.Size = new System.Drawing.Size(270, 45);
            this.trbSpeed.TabIndex = 3;
            this.trbSpeed.TickFrequency = 10;
            this.trbSpeed.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trbSpeed.Value = 100;
            this.trbSpeed.Scroll += new System.EventHandler(this.trbSpeed_Scroll);
            this.trbSpeed.ValueChanged += new System.EventHandler(this.trbSpeed_ValueChanged);
            // 
            // labelVersion
            // 
            this.labelVersion.Location = new System.Drawing.Point(13, 205);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(238, 18);
            this.labelVersion.TabIndex = 30;
            this.labelVersion.Text = "固件版本";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkRefresh
            // 
            this.linkRefresh.AutoSize = true;
            this.linkRefresh.Location = new System.Drawing.Point(13, 232);
            this.linkRefresh.Name = "linkRefresh";
            this.linkRefresh.Size = new System.Drawing.Size(77, 12);
            this.linkRefresh.TabIndex = 29;
            this.linkRefresh.TabStop = true;
            this.linkRefresh.Text = "更新获取状态";
            this.linkRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRefresh_LinkClicked);
            // 
            // labSpeed
            // 
            this.labSpeed.AutoSize = true;
            this.labSpeed.Location = new System.Drawing.Point(223, 139);
            this.labSpeed.Name = "labSpeed";
            this.labSpeed.Size = new System.Drawing.Size(53, 12);
            this.labSpeed.TabIndex = 32;
            this.labSpeed.Text = "风速:100";
            // 
            // chkSwitch
            // 
            this.chkSwitch.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSwitch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkSwitch.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSwitch.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkSwitch.Image = global::ZControl.Properties.Resources.device_close;
            this.chkSwitch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkSwitch.Location = new System.Drawing.Point(92, 88);
            this.chkSwitch.Name = "chkSwitch";
            this.chkSwitch.Size = new System.Drawing.Size(92, 42);
            this.chkSwitch.TabIndex = 33;
            this.chkSwitch.Text = "启动";
            this.chkSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSwitch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkSwitch.UseVisualStyleBackColor = true;
            this.chkSwitch.CheckedChanged += new System.EventHandler(this.chkSwitch_CheckedChanged);
            this.chkSwitch.Click += new System.EventHandler(this.chkSwitch_Click);
            // 
            // timerSend
            // 
            this.timerSend.Interval = 500;
            this.timerSend.Tick += new System.EventHandler(this.timerSend_Tick);
            // 
            // labLock
            // 
            this.labLock.AutoSize = true;
            this.labLock.Location = new System.Drawing.Point(235, 58);
            this.labLock.Name = "labLock";
            this.labLock.Size = new System.Drawing.Size(41, 12);
            this.labLock.TabIndex = 34;
            this.labLock.TabStop = true;
            this.labLock.Text = "未激活";
            this.labLock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labLock.Visible = false;
            this.labLock.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labLock_LinkClicked);
            // 
            // FormZA1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 311);
            this.Controls.Add(this.labLock);
            this.Controls.Add(this.chkSwitch);
            this.Controls.Add(this.labSpeed);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.linkRefresh);
            this.Controls.Add(this.trbSpeed);
            this.Name = "FormZA1";
            this.Text = "FormZA1";
            this.Controls.SetChildIndex(this.trbSpeed, 0);
            this.Controls.SetChildIndex(this.linkRefresh, 0);
            this.Controls.SetChildIndex(this.labelVersion, 0);
            this.Controls.SetChildIndex(this.labSpeed, 0);
            this.Controls.SetChildIndex(this.chkSwitch, 0);
            this.Controls.SetChildIndex(this.labLock, 0);
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trbSpeed;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.LinkLabel linkRefresh;
        private System.Windows.Forms.Label labSpeed;
        private System.Windows.Forms.CheckBox chkSwitch;
        private System.Windows.Forms.Timer timerSend;
        private System.Windows.Forms.LinkLabel labLock;
    }
}