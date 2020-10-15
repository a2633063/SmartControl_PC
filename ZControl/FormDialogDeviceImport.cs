using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZControl
{
    public partial class FormDialogDeviceImport : Form
    {
        String returnString=null;
        public FormDialogDeviceImport()
        {
            InitializeComponent();
        }
        public new string ShowDialog()
        {
            var result = base.ShowDialog();

            return returnString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = txtDeviceJson.Text;
            try
            {
                JObject jObject = JObject.Parse(s);
                returnString = s;
                this.Close();
            }
            catch (Exception)
            {
                returnString = null;
                MessageBox.Show("输入内容不是Json格式!", "错误",MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw;
            }
        }
    }
}
