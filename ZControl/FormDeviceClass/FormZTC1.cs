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

            btnHass.Enabled = true;
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
        #region 重写函数
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
        #region 控件触发函数
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

        private void ZTC1linkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshStatus();
        }

        private void labLock_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string lockStr = Microsoft.VisualBasic.Interaction.InputBox("请输入32位长度激活码\r\n\r\n激活码方式见文档说明.zTC1激活码免费获取!", "输入激活码", "");
            lockStr = lockStr.Trim().ToLower();
            Regex regex = new Regex(@"[1234567890abcdef]{32}");
            if (/*lockStr == null || */ !regex.IsMatch(lockStr))
            {
                MessageBox.Show("激活码格式输入错误.请确认不包含mac地址,长度32位字符串.\r\n请重试");
                return;
            }

            Send("{\"mac\":\"" + GetMac() + "\",\"lock\":\"" + lockStr + "\"}");
        }
        #endregion


        #region hass配置文件相关
        const string hassConfig = "switch:\n" +
         "  - platform: mqtt\n" +
         "    name: 'ztc1_1_MACMAC'\n" +
         "    unique_id: ztc1_1_MACMAC\n" +
         "    state_topic: 'device/ztc1/MACMAC/state'\n" +
         "    command_topic: 'device/ztc1/MACMAC/set'\n" +
         "    payload_on: '{\"mac\":\"MACMAC\",\"plug_0\":{\"on\":1}}'\n" +
         "    payload_off: '{\"mac\":\"MACMAC\",\"plug_0\":{\"on\":0}}'\n" +
         "    value_template: '{{ value_json.plug_0.on }}'\n" +
         "    state_on: '1'\n" +
         "    state_off: '0'\n" +
         "  - platform: mqtt\n" +
         "    name: 'ztc1_2_MACMAC'\n" +
         "    unique_id: ztc1_2_MACMAC\n" +
         "    state_topic: 'device/ztc1/MACMAC/state'\n" +
         "    command_topic: 'device/ztc1/MACMAC/set'\n" +
         "    payload_on: '{\"mac\":\"MACMAC\",\"plug_1\":{\"on\":1}}'\n" +
         "    payload_off: '{\"mac\":\"MACMAC\",\"plug_1\":{\"on\":0}}'\n" +
         "    value_template: '{{ value_json.plug_1.on }}'\n" +
         "    state_on: '1'\n" +
         "    state_off: '0'\n" +
         "  - platform: mqtt\n" +
         "    name: 'ztc1_3_MACMAC'\n" +
         "    unique_id: ztc1_3_MACMAC\n" +
         "    state_topic: 'device/ztc1/MACMAC/state'\n" +
         "    command_topic: 'device/ztc1/MACMAC/set'\n" +
         "    payload_on: '{\"mac\":\"MACMAC\",\"plug_2\":{\"on\":1}}'\n" +
         "    payload_off: '{\"mac\":\"MACMAC\",\"plug_2\":{\"on\":0}}'\n" +
         "    value_template: '{{ value_json.plug_2.on }}'\n" +
         "    state_on: '1'\n" +
         "    state_off: '0'\n" +
         "  - platform: mqtt\n" +
         "    name: 'ztc1_4_MACMAC'\n" +
         "    unique_id: ztc1_4_MACMAC\n" +
         "    state_topic: 'device/ztc1/MACMAC/state'\n" +
         "    command_topic: 'device/ztc1/MACMAC/set'\n" +
         "    payload_on: '{\"mac\":\"MACMAC\",\"plug_3\":{\"on\":1}}'\n" +
         "    payload_off: '{\"mac\":\"MACMAC\",\"plug_3\":{\"on\":0}}'\n" +
         "    value_template: '{{ value_json.plug_3.on }}'\n" +
         "    state_on: '1'\n" +
         "    state_off: '0'\n" +
         "  - platform: mqtt\n" +
         "    name: 'ztc1_5_MACMAC'\n" +
         "    unique_id: ztc1_5_MACMAC\n" +
         "    state_topic: 'device/ztc1/MACMAC/state'\n" +
         "    command_topic: 'device/ztc1/MACMAC/set'\n" +
         "    payload_on: '{\"mac\":\"MACMAC\",\"plug_4\":{\"on\":1}}'\n" +
         "    payload_off: '{\"mac\":\"MACMAC\",\"plug_4\":{\"on\":0}}'\n" +
         "    value_template: '{{ value_json.plug_4.on }}'\n" +
         "    state_on: '1'\n" +
         "    state_off: '0'\n" +
         "  - platform: mqtt\n" +
         "    name: 'ztc1_6_MACMAC'\n" +
         "    unique_id: ztc1_6_MACMAC\n" +
         "    state_topic: 'device/ztc1/MACMAC/state'\n" +
         "    command_topic: 'device/ztc1/MACMAC/set'\n" +
         "    payload_on: '{\"mac\":\"MACMAC\",\"plug_5\":{\"on\":1}}'\n" +
         "    payload_off: '{\"mac\":\"MACMAC\",\"plug_5\":{\"on\":0}}'\n" +
         "    value_template: '{{ value_json.plug_5.on }}'\n" +
         "    state_on: '1'\n" +
         "    state_off: '0'\n" +
         "\n" +
         "sensor:\n" +
         "  - platform: mqtt\n" +
         "    name: 'ztc1_power_MACMAC'\n" +
         "    unique_id: ztc1_power_MACMAC\n" +
         "    state_topic: 'device/ztc1/MACMAC/sensor'\n" +
         "    unit_of_measurement: 'W'\n" +
         "    icon: 'mdi:gauge'\n" +
         "    value_template: '{{ value_json.power }}'\n" +
         "  - platform: mqtt\n" +
         "    name: 'ztc1_time_MACMAC'\n" +
         "    unique_id: ztc1_time_MACMAC\n" +
         "    state_topic: 'device/ztc1/MACMAC/sensor'\n" +
         "    #unit_of_measurement: '秒'\n" +
         "    icon: 'mdi:gauge'\n" +
         "    #value_template: '{{ value_json.total_time }}'\n" +
         "    value_template: >-\n" +
         "      {% set time = value_json.total_time %}\n" +
         "      {% set minutes = ((time % 3600) / 60) | int %}\n" +
         "      {% set hours = ((time % 86400) / 3600) | int %}\n" +
         "      {% set days = (time / 86400) | int %}\n" +
         "      {%- if time < 60 -%}\n" +
         "        <1分钟\n" +
         "      {%- else -%}\n" +
         "        {%- if days > 0 -%}\n" +
         "            {{ days }}天\n" +
         "        {%- endif -%}\n" +
         "        {%- if hours > 0 -%}\n" +
         "            {{ hours }}小时\n" +
         "        {%- endif -%}\n" +
         "        {%- if minutes > 0 -%}\n" +
         "            {{ minutes }}分钟\n" +
         "        {%- endif -%}\n" +
         "      {%- endif -%}\n" +
         "    \n" +
         "#可以手动修改一下内容来自定义各设备名称\n" +
         "homeassistant:\n" +
         "  customize:\n" +
         "    switch.ztc1_1_MACMAC:\n" +
         "      friendly_name: zTC1插口1\n" +
         "    switch.ztc1_2_MACMAC:\n" +
         "      friendly_name: zTC1插口2\n" +
         "    switch.ztc1_3_MACMAC:\n" +
         "      friendly_name: zTC1插口3\n" +
         "    switch.ztc1_4_MACMAC:\n" +
         "      friendly_name: zTC1插口4\n" +
         "    switch.ztc1_5_MACMAC:\n" +
         "      friendly_name: zTC1插口5\n" +
         "    switch.ztc1_6_MACMAC:\n" +
         "      friendly_name: zTC1插口6\n" +
         "    sensor.ztc1_power_MACMAC:\n" +
         "      friendly_name: zTC1功率\n" +
         "    sensor.ztc1_time_MACMAC:\n" +
         "      friendly_name: zTC1运行时间\n";

        protected override String GetHassString()
        {
            String str = hassConfig.Replace("\n", "\r\n").Replace("MACMAC", GetMac());
            if (chkHassNameChoice.Checked){
                str = str.Replace("zTC1插口1", labZTC1SwitchName[0].Text);
                str = str.Replace("zTC1插口2", labZTC1SwitchName[1].Text);
                str = str.Replace("zTC1插口3", labZTC1SwitchName[2].Text);
                str = str.Replace("zTC1插口4", labZTC1SwitchName[3].Text);
                str = str.Replace("zTC1插口5", labZTC1SwitchName[4].Text);
                str = str.Replace("zTC1插口6", labZTC1SwitchName[5].Text);
            }
            return str;
        }

        #endregion
    }
}
