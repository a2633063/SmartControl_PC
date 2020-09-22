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
    public partial class FormZTC1 : FormItem
    {
        public Boolean[] plugSwitch = new Boolean[6] { false, false, false, false, false, false }; //开关状态
        PictureBox[] picZTC1SwitchPic = new PictureBox[6];
        Label[] labZTC1SwitchName = new Label[6];


        private void Send(String message)
        {
            Send("device/ztc1/" + GetMac() + "/set", message);
        }
        public FormZTC1(String name, String mac) : base(DEVICETYPE.TYPE_TC1, name, mac)
        {
            InitializeComponent();


            picZTC1SwitchPic[0] = picZTC1Switch0;
            picZTC1SwitchPic[1] = picZTC1Switch1;
            picZTC1SwitchPic[2] = picZTC1Switch2;
            picZTC1SwitchPic[3] = picZTC1Switch3;
            picZTC1SwitchPic[4] = picZTC1Switch4;
            picZTC1SwitchPic[5] = picZTC1Switch5;
            labZTC1SwitchName[0] = labZTC1Switch0Name;
            labZTC1SwitchName[1] = labZTC1Switch1Name;
            labZTC1SwitchName[2] = labZTC1Switch2Name;
            labZTC1SwitchName[3] = labZTC1Switch3Name;
            labZTC1SwitchName[4] = labZTC1Switch4Name;
            labZTC1SwitchName[5] = labZTC1Switch5Name;
            for (int i = 0; i < picZTC1SwitchPic.Count(); i++)
            {
                picZTC1SwitchPic[i].Click += PicZTC1Switch_Click;
                picZTC1SwitchPic[i].Tag = i;

                picZTC1SwitchPic[i].MouseDown += PicSwitch_MouseDown;
                picZTC1SwitchPic[i].MouseUp += PicSwitch_MouseUp;
                picZTC1SwitchPic[i].MouseLeave += PicSwitch_MouseLeave;
            }

            picZTC1SwitchAll.MouseDown += PicSwitch_MouseDown;
            picZTC1SwitchAll.MouseUp += PicSwitch_MouseUp;
            picZTC1SwitchAll.MouseLeave += PicSwitch_MouseLeave;

        }

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
        private void picZTC1SwitchAll_Click(object sender, EventArgs e)
        {

            String message = "{\"mac\":\"" + GetMac() + "\",\"plug_0\":{\"on\":1},\"plug_1\":{\"on\":1},\"plug_2\":{\"on\":1},\"plug_3\":{\"on\":1},\"plug_4\":{\"on\":1},\"plug_5\":{\"on\":1}}";
            bool b = true;
            for (int i = 0; i < picZTC1SwitchPic.Length; i++)
            {
                if (plugSwitch[i])
                {
                    b = false;
                    message = "{\"mac\":\"" + GetMac() + "\",\"plug_0\":{\"on\":0},\"plug_1\":{\"on\":0},\"plug_2\":{\"on\":0},\"plug_3\":{\"on\":0},\"plug_4\":{\"on\":0},\"plug_5\":{\"on\":0}}";
                    break;
                }
            }

            picZTC1SwitchAll.Image = b ? Properties.Resources.device_open : Properties.Resources.device_close;


            Send(message);
        }

        private void PicZTC1Switch_Click(object sender, EventArgs e)
        {
            PictureBox zTC1SwitchPic = (PictureBox)sender;
            int index = (int)zTC1SwitchPic.Tag;
            Send("{\"mac\":\"" + GetMac() + "\",\"plug_" + index + "\":{\"on\":" + (plugSwitch[index] ? "0" : "1") + "}}");

            plugSwitch[index] = !plugSwitch[index];
            picZTC1SwitchPic[index].Image = plugSwitch[index] ? Properties.Resources.device_open : Properties.Resources.device_close;
            for (int i = 0; i < picZTC1SwitchPic.Length; i++)
            {
                if (plugSwitch[i])
                {
                    picZTC1SwitchAll.Image = Properties.Resources.device_open;
                    return;
                }
            }
            picZTC1SwitchAll.Image = Properties.Resources.device_close;

        }
        public override String[] GetRecvMqttTopic()
        {
            String[] topic = new String[3];
            topic[0] = "device/ztc1/" + GetMac() + "/state";
            topic[1] = "device/ztc1/" + GetMac() + "/sensor";
            topic[2] = "device/ztc1/" + GetMac() + "/availability";
            return topic;
        }
        public override void Received(String topic, String message)
        {
            JObject jsonObject = JObject.Parse(message);
            if (!GetMac().Equals(jsonObject["mac"].ToString())) return;

            if (jsonObject.Property("lock") != null)
            {
                if ((bool)jsonObject["lock"])
                {
                    labLock.Enabled = false;
                    labLock.Text = "已激活";
                }
                else
                {
                    labLock.Visible = true;
                    labLock.Text = "未激活";
                    labLock.Enabled = true;
                }
            }
            if (jsonObject.Property("power") != null)
            {
                labelZTC1Power.Text = jsonObject["power"].ToString() + "W";
            }

            if (jsonObject.Property("total_time") != null)
            {
                UInt32 time = (uint)jsonObject["total_time"];
                if (time > 0)
                {
                    String str = "";
                    UInt32 days = time / 86400; //天
                    UInt32 hours = ((time % 86400) / 3600); //小时
                    UInt32 minutes = ((time % 3600) / 60); //分

                    if (days > 0)   //天
                    {
                        str += days + "天";
                    }
                    if (hours > 0)   //小时
                    {
                        str += hours + "小时";
                    }
                    if (minutes > 0)   //分
                    {
                        str += minutes + "分钟";
                    }

                    labelZTC1TotalTime.Text = "已运行时间: " + str;
                }
            }
            if (jsonObject.Property("version") != null)
            {
                labelZTC1Version.Text = "固件版本: " + jsonObject["version"].ToString();
            }
            #region 解析plug
            int plugAllFlag = 0x0;
            for (int plug_id = 0; plug_id < 6; plug_id++)
            {
                if (jsonObject.Property("plug_" + plug_id) == null) continue;

                JObject jsonPlug = (JObject)jsonObject["plug_" + plug_id];
                if (jsonPlug.Property("on") != null)
                {
                    int on = (int)jsonPlug["on"];
                    plugSwitch[plug_id] = (on != 0);
                    picZTC1SwitchPic[plug_id].Image = plugSwitch[plug_id] ? Properties.Resources.device_open : Properties.Resources.device_close;
                    if (plugSwitch[plug_id]) plugAllFlag |= 0x81;
                    else plugAllFlag |= 0x80;
                }
                if (jsonPlug.Property("setting") == null) continue;
                JObject jsonPlugSetting = (JObject)jsonPlug["setting"];
                if (jsonPlugSetting.Property("name") != null)
                {
                    labZTC1SwitchName[plug_id].Text = jsonPlugSetting["name"].ToString();
                    labZTC1SwitchName[plug_id].Left = picZTC1SwitchPic[plug_id].Left + picZTC1SwitchPic[plug_id].Width / 2 - labZTC1SwitchName[plug_id].Width / 2;
                }
            }
            if (plugAllFlag == 0x81)
                picZTC1SwitchAll.Image = Properties.Resources.device_open;
            else if (plugAllFlag == 0x80)
                picZTC1SwitchAll.Image = Properties.Resources.device_close;
            #endregion


        }

        public override void RefreshStatus()
        {
            Send("{\"mac\": \"" + GetMac() + "\","
                            + "\"version\":null,"
                            + "\"lock\":null,"
                            + "\"plug_0\" : {\"on\" : null,\"setting\":{\"name\":null}},"
                            + "\"plug_1\" : {\"on\" : null,\"setting\":{\"name\":null}},"
                            + "\"plug_2\" : {\"on\" : null,\"setting\":{\"name\":null}},"
                            + "\"plug_3\" : {\"on\" : null,\"setting\":{\"name\":null}},"
                            + "\"plug_4\" : {\"on\" : null,\"setting\":{\"name\":null}},"
                            + "\"plug_5\" : {\"on\" : null,\"setting\":{\"name\":null}}}");
        }
        private void ZTC1linkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshStatus();
        }
    }
}
