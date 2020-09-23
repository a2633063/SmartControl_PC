namespace ZControl.FormDeviceClass
{
    partial class FormZDC1
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
            this.labelZDC1Version = new System.Windows.Forms.Label();
            this.labelZDC1Current = new System.Windows.Forms.Label();
            this.labelZDC1Voltage = new System.Windows.Forms.Label();
            this.linkRefresh = new System.Windows.Forms.LinkLabel();
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
            this.panelZDC1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picZDC1Switch0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZDC1Switch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZDC1Switch2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZDC1Switch3)).BeginInit();
            this.SuspendLayout();
            // 
            // panelZDC1
            // 
            this.panelZDC1.BackColor = System.Drawing.Color.Transparent;
            this.panelZDC1.Controls.Add(this.labelZDC1Version);
            this.panelZDC1.Controls.Add(this.labelZDC1Current);
            this.panelZDC1.Controls.Add(this.labelZDC1Voltage);
            this.panelZDC1.Controls.Add(this.linkRefresh);
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
            this.panelZDC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelZDC1.Location = new System.Drawing.Point(0, 55);
            this.panelZDC1.Name = "panelZDC1";
            this.panelZDC1.Size = new System.Drawing.Size(745, 314);
            this.panelZDC1.TabIndex = 28;
            // 
            // labelZDC1Version
            // 
            this.labelZDC1Version.Location = new System.Drawing.Point(33, 165);
            this.labelZDC1Version.Name = "labelZDC1Version";
            this.labelZDC1Version.Size = new System.Drawing.Size(238, 18);
            this.labelZDC1Version.TabIndex = 28;
            this.labelZDC1Version.Text = "固件版本";
            this.labelZDC1Version.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelZDC1Current
            // 
            this.labelZDC1Current.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelZDC1Current.Location = new System.Drawing.Point(200, 40);
            this.labelZDC1Current.Name = "labelZDC1Current";
            this.labelZDC1Current.Size = new System.Drawing.Size(87, 23);
            this.labelZDC1Current.TabIndex = 26;
            this.labelZDC1Current.Text = "----";
            this.labelZDC1Current.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelZDC1Voltage
            // 
            this.labelZDC1Voltage.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelZDC1Voltage.Location = new System.Drawing.Point(196, 20);
            this.labelZDC1Voltage.Name = "labelZDC1Voltage";
            this.labelZDC1Voltage.Size = new System.Drawing.Size(94, 23);
            this.labelZDC1Voltage.TabIndex = 25;
            this.labelZDC1Voltage.Text = "----";
            this.labelZDC1Voltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // labelZDC1Power
            // 
            this.labelZDC1Power.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelZDC1Power.Location = new System.Drawing.Point(107, 32);
            this.labelZDC1Power.Name = "labelZDC1Power";
            this.labelZDC1Power.Size = new System.Drawing.Size(93, 23);
            this.labelZDC1Power.TabIndex = 20;
            this.labelZDC1Power.Text = "----";
            this.labelZDC1Power.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(127, 20);
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
            this.picZDC1Switch0.Location = new System.Drawing.Point(34, 12);
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
            this.picZDC1Switch1.Location = new System.Drawing.Point(34, 87);
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
            this.picZDC1Switch2.Location = new System.Drawing.Point(125, 87);
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
            this.picZDC1Switch3.Location = new System.Drawing.Point(216, 87);
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
            this.labZDC1Switch3Name.Location = new System.Drawing.Point(212, 122);
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
            this.labZDC1Switch2Name.Location = new System.Drawing.Point(121, 122);
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
            this.labZDC1Switch1Name.Location = new System.Drawing.Point(30, 122);
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
            this.labZDC1Switch0Name.Location = new System.Drawing.Point(31, 47);
            this.labZDC1Switch0Name.Name = "labZDC1Switch0Name";
            this.labZDC1Switch0Name.Size = new System.Drawing.Size(59, 20);
            this.labZDC1Switch0Name.TabIndex = 6;
            this.labZDC1Switch0Name.Text = "插座1";
            this.labZDC1Switch0Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormZDC1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 369);
            this.Controls.Add(this.panelZDC1);
            this.Name = "FormZDC1";
            this.Text = "FormZDC1";
            this.Controls.SetChildIndex(this.panelZDC1, 0);
            this.panelZDC1.ResumeLayout(false);
            this.panelZDC1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picZDC1Switch0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZDC1Switch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZDC1Switch2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZDC1Switch3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelZDC1;
        private System.Windows.Forms.Label labelZDC1Current;
        private System.Windows.Forms.Label labelZDC1Voltage;
        private System.Windows.Forms.LinkLabel linkRefresh;
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
        private System.Windows.Forms.Label labelZDC1Version;
    }
}