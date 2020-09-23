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

namespace ZControl.FormDeviceClass
{
    public partial class FormZM1 : FormItem
    {

        private void Send(String message)
        {
            Send("device/zm1/" + GetMac() + "/set", message);
        }
        public FormZM1(String name, String mac) : base(DEVICETYPE.TYPE_M1, name, mac)
        {
            InitializeComponent();
        }
        #region 重写函数
        public override String[] GetRecvMqttTopic()
        {
            String[] topic = new String[3];
            topic[0] = "device/zm1/" + GetMac() + "/state";
            topic[1] = "device/zm1/" + GetMac() + "/sensor";
            topic[2] = "device/zm1/" + GetMac() + "/availability";
            return topic;
        }
        public override void Received(String topic, String message)
        {
            JObject jsonObject = JObject.Parse(message);
            if (!GetMac().Equals(jsonObject["mac"].ToString())) return;

            if (jsonObject.Property("PM25") != null)
            {
                labPM25.Text = "PM2.5:"+ jsonObject["PM25"].ToString() + "ug/m³";
            }
            if (jsonObject.Property("formaldehyde") != null)
            {
                labFormaldehyde.Text = "甲醛:" + jsonObject["formaldehyde"].ToString() + "mg/m³";
            }

            if (jsonObject.Property("temperature") != null)
            {
                labTemperature.Text = "温度:" + jsonObject["temperature"].ToString() + "℃";
            }

            if (jsonObject.Property("humidity") != null)
            {
                labHumidity.Text = "湿度:" + jsonObject["humidity"].ToString() + "%";
            }
            if (jsonObject.Property("brightness") != null)
            {
                trbBrightness.Value = (int)jsonObject["brightness"];
            }
            if (jsonObject.Property("version") != null)
            {
                labelVersion.Text = "固件版本: " + jsonObject["version"].ToString();
            }

        }

        public override void RefreshStatus()
        {
            Send("{\"mac\": \"" + GetMac() + "\","
                            + "\"version\":null,"
                            + "\"brightness\":null}");
        }

        #endregion

        private void linkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshStatus();
        }

        private void trbBrightness_Scroll(object sender, EventArgs e)
        {
            timerSend.Enabled = false;
            timerSend.Enabled = true;
            //Send("{\"mac\":\"" + GetMac() + "\",\"brightness\":" + trbBrightness.Value + "}");
        }

        private void timerSend_Tick(object sender, EventArgs e)
        {
            Send("{\"mac\":\"" + GetMac() + "\",\"brightness\":" + trbBrightness.Value + "}");
            timerSend.Enabled = false;
        }
    }
}
