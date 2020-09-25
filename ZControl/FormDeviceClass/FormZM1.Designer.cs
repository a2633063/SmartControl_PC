namespace ZControl.FormDeviceClass
{
    partial class FormZM1
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.linkRefresh = new System.Windows.Forms.LinkLabel();
            this.labTemperature = new System.Windows.Forms.Label();
            this.labHumidity = new System.Windows.Forms.Label();
            this.labPM25 = new System.Windows.Forms.Label();
            this.labFormaldehyde = new System.Windows.Forms.Label();
            this.timerSend = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbBrightness)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.SetChildIndex(this.btnHass, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            // 
            // trbBrightness
            // 
            this.trbBrightness.LargeChange = 1;
            this.trbBrightness.Location = new System.Drawing.Point(77, 163);
            this.trbBrightness.Maximum = 4;
            this.trbBrightness.Name = "trbBrightness";
            this.trbBrightness.Size = new System.Drawing.Size(221, 45);
            this.trbBrightness.TabIndex = 4;
            this.trbBrightness.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trbBrightness.Value = 4;
            this.trbBrightness.Scroll += new System.EventHandler(this.trbBrightness_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "亮度:";
            // 
            // labelVersion
            // 
            this.labelVersion.Location = new System.Drawing.Point(12, 218);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(238, 18);
            this.labelVersion.TabIndex = 32;
            this.labelVersion.Text = "固件版本";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkRefresh
            // 
            this.linkRefresh.AutoSize = true;
            this.linkRefresh.Location = new System.Drawing.Point(12, 238);
            this.linkRefresh.Name = "linkRefresh";
            this.linkRefresh.Size = new System.Drawing.Size(77, 12);
            this.linkRefresh.TabIndex = 31;
            this.linkRefresh.TabStop = true;
            this.linkRefresh.Text = "更新获取状态";
            this.linkRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRefresh_LinkClicked);
            // 
            // labTemperature
            // 
            this.labTemperature.AutoSize = true;
            this.labTemperature.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTemperature.Location = new System.Drawing.Point(13, 128);
            this.labTemperature.Name = "labTemperature";
            this.labTemperature.Size = new System.Drawing.Size(49, 20);
            this.labTemperature.TabIndex = 33;
            this.labTemperature.Text = "温度";
            // 
            // labHumidity
            // 
            this.labHumidity.AutoSize = true;
            this.labHumidity.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labHumidity.Location = new System.Drawing.Point(155, 128);
            this.labHumidity.Name = "labHumidity";
            this.labHumidity.Size = new System.Drawing.Size(49, 20);
            this.labHumidity.TabIndex = 34;
            this.labHumidity.Text = "湿度";
            // 
            // labPM25
            // 
            this.labPM25.AutoSize = true;
            this.labPM25.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPM25.Location = new System.Drawing.Point(13, 76);
            this.labPM25.Name = "labPM25";
            this.labPM25.Size = new System.Drawing.Size(59, 20);
            this.labPM25.TabIndex = 35;
            this.labPM25.Text = "PM2.5";
            // 
            // labFormaldehyde
            // 
            this.labFormaldehyde.AutoSize = true;
            this.labFormaldehyde.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labFormaldehyde.Location = new System.Drawing.Point(155, 76);
            this.labFormaldehyde.Name = "labFormaldehyde";
            this.labFormaldehyde.Size = new System.Drawing.Size(49, 20);
            this.labFormaldehyde.TabIndex = 36;
            this.labFormaldehyde.Text = "甲醛";
            // 
            // timerSend
            // 
            this.timerSend.Tick += new System.EventHandler(this.timerSend_Tick);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(40, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 114);
            this.label2.TabIndex = 7;
            this.label2.Text = "注意: hass配置文件生成功能暂时未做验证!生成文件后请在hass中确认配置正确.若错误,请使用文档中hass配置方式";
            // 
            // FormZM1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 350);
            this.Controls.Add(this.labFormaldehyde);
            this.Controls.Add(this.labPM25);
            this.Controls.Add(this.labHumidity);
            this.Controls.Add(this.labTemperature);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.linkRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trbBrightness);
            this.Name = "FormZM1";
            this.Text = "FormZM1";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.trbBrightness, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.linkRefresh, 0);
            this.Controls.SetChildIndex(this.labelVersion, 0);
            this.Controls.SetChildIndex(this.labTemperature, 0);
            this.Controls.SetChildIndex(this.labHumidity, 0);
            this.Controls.SetChildIndex(this.labPM25, 0);
            this.Controls.SetChildIndex(this.labFormaldehyde, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trbBrightness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trbBrightness;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.LinkLabel linkRefresh;
        private System.Windows.Forms.Label labTemperature;
        private System.Windows.Forms.Label labHumidity;
        private System.Windows.Forms.Label labPM25;
        private System.Windows.Forms.Label labFormaldehyde;
        private System.Windows.Forms.Timer timerSend;
        private System.Windows.Forms.Label label2;
    }
}