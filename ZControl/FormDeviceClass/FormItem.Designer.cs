namespace ZControl.FormDeviceClass
{
    partial class FormItem
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
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelMac = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHass = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.Transparent;
            this.panelTitle.Controls.Add(this.labelMac);
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(620, 55);
            this.panelTitle.TabIndex = 2;
            // 
            // labelMac
            // 
            this.labelMac.AutoSize = true;
            this.labelMac.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelMac.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelMac.Location = new System.Drawing.Point(0, 38);
            this.labelMac.Name = "labelMac";
            this.labelMac.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.labelMac.Size = new System.Drawing.Size(55, 12);
            this.labelMac.TabIndex = 1;
            this.labelMac.Text = "mac地址";
            this.labelMac.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.labelMac.DoubleClick += new System.EventHandler(this.labelMac_DoubleClick);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelTitle.Font = new System.Drawing.Font("宋体", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.Location = new System.Drawing.Point(4, 4);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(133, 30);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "设备名称";
            this.labelTitle.DoubleClick += new System.EventHandler(this.labelTitle_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnHass);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(310, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 295);
            this.panel1.TabIndex = 4;
            // 
            // btnHass
            // 
            this.btnHass.Enabled = false;
            this.btnHass.Location = new System.Drawing.Point(28, 245);
            this.btnHass.Name = "btnHass";
            this.btnHass.Size = new System.Drawing.Size(254, 38);
            this.btnHass.TabIndex = 4;
            this.btnHass.Text = "生成hass配置文件";
            this.btnHass.UseVisualStyleBackColor = true;
            this.btnHass.Click += new System.EventHandler(this.btnHass_Click);
            // 
            // FormItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 350);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTitle);
            this.Name = "FormItem";
            this.Text = "FormItem";
            this.Load += new System.EventHandler(this.FormItem_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelMac;
        protected System.Windows.Forms.Button btnHass;
        protected System.Windows.Forms.Panel panel1;
    }
}