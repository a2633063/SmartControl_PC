namespace ZControl.FormDeviceClass
{
    partial class FormZClock
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
            this.trbBrightness = new System.Windows.Forms.TrackBar();
            this.labelVersion = new System.Windows.Forms.Label();
            this.linkRefresh = new System.Windows.Forms.LinkLabel();
            this.chkDirection = new System.Windows.Forms.CheckBox();
            this.timerSend = new System.Windows.Forms.Timer(this.components);
            this.labBrightness = new System.Windows.Forms.Label();
            this.chkAutoBrightness = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trbBrightness)).BeginInit();
            this.SuspendLayout();
            // 
            // trbBrightness
            // 
            this.trbBrightness.LargeChange = 1;
            this.trbBrightness.Location = new System.Drawing.Point(74, 119);
            this.trbBrightness.Maximum = 8;
            this.trbBrightness.Name = "trbBrightness";
            this.trbBrightness.Size = new System.Drawing.Size(224, 45);
            this.trbBrightness.TabIndex = 3;
            this.trbBrightness.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trbBrightness.Value = 8;
            this.trbBrightness.Scroll += new System.EventHandler(this.trbBrightness_Scroll);
            this.trbBrightness.ValueChanged += new System.EventHandler(this.trbSpeed_ValueChanged);
            // 
            // labelVersion
            // 
            this.labelVersion.Location = new System.Drawing.Point(13, 229);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(238, 18);
            this.labelVersion.TabIndex = 30;
            this.labelVersion.Text = "固件版本";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkRefresh
            // 
            this.linkRefresh.AutoSize = true;
            this.linkRefresh.Location = new System.Drawing.Point(13, 253);
            this.linkRefresh.Name = "linkRefresh";
            this.linkRefresh.Size = new System.Drawing.Size(77, 12);
            this.linkRefresh.TabIndex = 29;
            this.linkRefresh.TabStop = true;
            this.linkRefresh.Text = "更新获取状态";
            this.linkRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRefresh_LinkClicked);
            // 
            // chkDirection
            // 
            this.chkDirection.AutoSize = true;
            this.chkDirection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkDirection.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkDirection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDirection.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDirection.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkDirection.Location = new System.Drawing.Point(12, 170);
            this.chkDirection.Name = "chkDirection";
            this.chkDirection.Size = new System.Drawing.Size(93, 16);
            this.chkDirection.TabIndex = 33;
            this.chkDirection.Text = "切换显示方向";
            this.chkDirection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkDirection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkDirection.UseVisualStyleBackColor = true;
            this.chkDirection.Click += new System.EventHandler(this.chkDirection_Click);
            // 
            // timerSend
            // 
            this.timerSend.Interval = 200;
            this.timerSend.Tick += new System.EventHandler(this.timerSend_Tick);
            // 
            // labBrightness
            // 
            this.labBrightness.AutoSize = true;
            this.labBrightness.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labBrightness.Location = new System.Drawing.Point(12, 132);
            this.labBrightness.Name = "labBrightness";
            this.labBrightness.Size = new System.Drawing.Size(56, 16);
            this.labBrightness.TabIndex = 34;
            this.labBrightness.Text = "亮度:8";
            // 
            // chkAutoBrightness
            // 
            this.chkAutoBrightness.AutoSize = true;
            this.chkAutoBrightness.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkAutoBrightness.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkAutoBrightness.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAutoBrightness.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkAutoBrightness.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkAutoBrightness.Location = new System.Drawing.Point(229, 170);
            this.chkAutoBrightness.Name = "chkAutoBrightness";
            this.chkAutoBrightness.Size = new System.Drawing.Size(69, 16);
            this.chkAutoBrightness.TabIndex = 35;
            this.chkAutoBrightness.Text = "自动亮度";
            this.chkAutoBrightness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkAutoBrightness.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkAutoBrightness.UseVisualStyleBackColor = true;
            this.chkAutoBrightness.Click += new System.EventHandler(this.chkAutoBrightness_Click);
            // 
            // FormZClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 350);
            this.Controls.Add(this.chkAutoBrightness);
            this.Controls.Add(this.labBrightness);
            this.Controls.Add(this.chkDirection);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.linkRefresh);
            this.Controls.Add(this.trbBrightness);
            this.Name = "FormZClock";
            this.Text = "FormZClock";
            this.Controls.SetChildIndex(this.trbBrightness, 0);
            this.Controls.SetChildIndex(this.linkRefresh, 0);
            this.Controls.SetChildIndex(this.labelVersion, 0);
            this.Controls.SetChildIndex(this.chkDirection, 0);
            this.Controls.SetChildIndex(this.labBrightness, 0);
            this.Controls.SetChildIndex(this.chkAutoBrightness, 0);
            ((System.ComponentModel.ISupportInitialize)(this.trbBrightness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar trbBrightness;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.LinkLabel linkRefresh;
        private System.Windows.Forms.CheckBox chkDirection;
        private System.Windows.Forms.Timer timerSend;
        private System.Windows.Forms.Label labBrightness;
        private System.Windows.Forms.CheckBox chkAutoBrightness;
    }
}