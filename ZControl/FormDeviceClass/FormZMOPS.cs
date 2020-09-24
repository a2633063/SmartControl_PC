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
    public partial class FormZMOPS : FormItem
    {
        public Boolean plugSwitch = false; //开关状态


        private void Send(String message)
        {
            Send("device/zmops/" + GetMac() + "/set", message);
        }
        public FormZMOPS(String name, String mac) : base(DEVICETYPE.TYPE_MOPS, name, mac)
        {
            InitializeComponent();

            picSwitch.Click += PicSwitch_Click;
            picSwitch.MouseDown += PicSwitch_MouseDown;
            picSwitch.MouseUp += PicSwitch_MouseUp;
            picSwitch.MouseLeave += PicSwitch_MouseLeave;



        }
        #region 重写函数
        public override String[] GetRecvMqttTopic()
        {
            String[] topic = new String[3];
            topic[0] = "device/zmops/" + GetMac() + "/state";
            topic[1] = "device/zmops/" + GetMac() + "/sensor";
            topic[2] = "device/zmops/" + GetMac() + "/availability";
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

            if (jsonObject.Property("on") != null)
            {
                int on = (int)jsonObject["on"];
                plugSwitch = (on != 0);
                picSwitch.Image = plugSwitch ? Properties.Resources.device_open : Properties.Resources.device_close;
            }
        }

        public override void RefreshStatus()
        {
            Send("{\"mac\": \"" + GetMac() + "\","
                            + "\"version\":null,"
                            + "\"on\":null}");
        }

        #endregion
        #region 开关图片按下效果
        private void PicSwitch_MouseDown(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BorderStyle = BorderStyle.Fixed3D;
        }
        private void PicSwitch_MouseUp(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BorderStyle = BorderStyle.None;
        }
        private void PicSwitch_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BorderStyle = BorderStyle.None;
        }
        #endregion

        private void PicSwitch_Click(object sender, EventArgs e)
        {
            if (plugSwitch)
                Send("{\"mac\":\"" + GetMac() + "\",\"on\":0}");
            else
                Send("{\"mac\":\"" + GetMac() + "\",\"on\":1}");

            plugSwitch = !plugSwitch;
            picSwitch.Image = plugSwitch ? Properties.Resources.device_open : Properties.Resources.device_close;
        }

        private void linkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshStatus();
        }
    }
}
