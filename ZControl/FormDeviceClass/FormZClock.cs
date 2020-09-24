using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZControl.FormDeviceClass
{
    public partial class FormZClock : FormItem
    {


        private void Send(String message)
        {
            Send("device/zclock/" + GetMac() + "/set", message);
        }
        public FormZClock(String name, String mac) : base(DEVICETYPE.TYPE_CLOCK, name, mac)
        {
            InitializeComponent();

        }
        #region 重写函数
        public override String[] GetRecvMqttTopic()
        {
            String[] topic = new String[3];
            topic[0] = "device/zclock/" + GetMac() + "/state";
            topic[1] = "device/zclock/" + GetMac() + "/sensor";
            topic[2] = "device/zclock/" + GetMac() + "/availability";
            return topic;
        }
        public override void Received(String topic, String message)
        {
            
            JObject jsonObject = JObject.Parse(message);
            if (!GetMac().Equals(jsonObject["mac"].ToString())) return;

            if (jsonObject.Property("version") != null)
            {
                labelVersion.Text = "固件版本: " + jsonObject["version"].ToString();
            }

            if (jsonObject.Property("brightness") != null)
            {
                trbBrightness.Value = (int)jsonObject["brightness"];
            }
            if (jsonObject.Property("auto_brightness") != null)
            {
                chkAutoBrightness.Checked = (((int)jsonObject["auto_brightness"])==1);
            }
            if (jsonObject.Property("direction") != null)
            {
                chkDirection.Checked = (((int)jsonObject["direction"]) == 1);
            }
            //if (jsonObject.Property("on") != null)
            //{
            //    int on = (int)jsonObject["on"];
            //    chkDirection.Checked = (on == 1);
            //}
        }

        public override void RefreshStatus()
        {
            Send("{\"mac\": \"" + GetMac() + "\","
                            + "\"version\":null,"
                            + "\"direction\" : null,"
                            + "\"auto_brightness\" : null,"
                            + "\"brightness\" : null,"
                            + "\"on\" : null}");
        }

        #endregion

        private void linkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshStatus();
        }

        private void chkDirection_Click(object sender, EventArgs e)
        {
            Console.WriteLine("chkSwitch_Click");
            Send("{\"mac\": \"" + GetMac() + "\",\"direction\" : " + (chkDirection.Checked ? "1" : "0") + "}");

        }
        private void chkAutoBrightness_Click(object sender, EventArgs e)
        {
            Send("{\"mac\": \"" + GetMac() + "\",\"auto_brightness\" : " + (chkAutoBrightness.Checked ? "1" : "0") + "}");
        }
        private void trbBrightness_Scroll(object sender, EventArgs e)
        {

            timerSend.Enabled = false;
            timerSend.Enabled = true;
            //Send("{\"mac\": \"" + GetMac() + "\",\"speed\" : " + trbSpeed.Value + "}");
        }

        private void timerSend_Tick(object sender, EventArgs e)
        {
            // Console.WriteLine("timerSend_Tick");

            Send("{\"mac\": \"" + GetMac() + "\",\"brightness\" : " + trbBrightness.Value + "}");
            timerSend.Enabled = false;
        }

        private void trbSpeed_ValueChanged(object sender, EventArgs e)
        {
            labBrightness.Text = "亮度:" + trbBrightness.Value;
        }


    }
}
