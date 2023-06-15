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
    public partial class FormZDC1 : FormItem
    {
        public Boolean[] plugSwitch = new Boolean[4] { false, false, false, false }; //开关状态

        PictureBox[] picZDC1SwitchPic = new PictureBox[4];
        Label[] labZDC1SwitchName = new Label[4];

        private void Send(String message)
        {
            Send("device/zdc1/" + GetMac() + "/set", message);
        }
        public FormZDC1(String name, String mac) : base(DEVICETYPE.TYPE_DC1, name, mac)
        {
            InitializeComponent();

            btnHass.Enabled = true;
            picZDC1SwitchPic[0] = picZDC1Switch0;
            picZDC1SwitchPic[1] = picZDC1Switch1;
            picZDC1SwitchPic[2] = picZDC1Switch2;
            picZDC1SwitchPic[3] = picZDC1Switch3;

            labZDC1SwitchName[0] = labZDC1Switch0Name;
            labZDC1SwitchName[1] = labZDC1Switch1Name;
            labZDC1SwitchName[2] = labZDC1Switch2Name;
            labZDC1SwitchName[3] = labZDC1Switch3Name;
            for (int i = 0; i < picZDC1SwitchPic.Count(); i++)
            {
                picZDC1SwitchPic[i].Click += PicZDC1Switch_Click;
                picZDC1SwitchPic[i].Tag = i;

                picZDC1SwitchPic[i].MouseDown += PicSwitch_MouseDown;
                picZDC1SwitchPic[i].MouseUp += PicSwitch_MouseUp;
                picZDC1SwitchPic[i].MouseLeave += PicSwitch_MouseLeave;
            }


        }
        #region 重写函数
        public override String[] GetRecvMqttTopic()
        {
            String[] topic = new String[3];
            topic[0] = "device/zdc1/" + GetMac() + "/state";
            topic[1] = "device/zdc1/" + GetMac() + "/sensor";
            topic[2] = "device/zdc1/" + GetMac() + "/availability";
            return topic;
        }
        public override void Received(String topic, String message)
        {
            JObject jsonObject = JObject.Parse(message);
            if (!GetMac().Equals(jsonObject["mac"].ToString())) return;


            if (jsonObject.Property("power") != null)
            {
                labelZDC1Power.Text = jsonObject["power"].ToString() + "W";
            }

            if (jsonObject.Property("voltage") != null)
            {
                labelZDC1Voltage.Text = jsonObject["voltage"].ToString() + "V";
            }

            if (jsonObject.Property("current") != null)
            {
                labelZDC1Current.Text = jsonObject["current"].ToString() + "A";
            }
            if (jsonObject.Property("version") != null)
            {
                labelZDC1Version.Text = "固件版本: " + jsonObject["version"].ToString();
            }
            #region 解析plug
            int plugAllFlag = 0x0;
            for (int plug_id = 0; plug_id < 4; plug_id++)
            {
                if (jsonObject.Property("plug_" + plug_id) == null) continue;

                JObject jsonPlug = (JObject)jsonObject["plug_" + plug_id];
                if (jsonPlug.Property("on") != null)
                {
                    int on = (int)jsonPlug["on"];
                    plugSwitch[plug_id] = (on != 0);
                    picZDC1SwitchPic[plug_id].Image = plugSwitch[plug_id] ? Properties.Resources.device_open : Properties.Resources.device_close;
                    if (plugSwitch[plug_id]) plugAllFlag |= 0x81;
                    else plugAllFlag |= 0x80;
                }
                if (jsonPlug.Property("setting") == null) continue;
                JObject jsonPlugSetting = (JObject)jsonPlug["setting"];
                if (plug_id > 0 && jsonPlugSetting.Property("name") != null)
                {
                    labZDC1SwitchName[plug_id].Text = jsonPlugSetting["name"].ToString();
                    labZDC1SwitchName[plug_id].Left = picZDC1SwitchPic[plug_id].Left + picZDC1SwitchPic[plug_id].Width / 2 - labZDC1SwitchName[plug_id].Width / 2;
                }
            }

            #endregion


        }

        public override void RefreshStatus()
        {
            Send("{\"mac\": \"" + GetMac() + "\","
                            + "\"version\":null,"
                            + "\"plug_0\" : {\"on\" : null,\"setting\":{\"name\":null}},"
                            + "\"plug_1\" : {\"on\" : null,\"setting\":{\"name\":null}},"
                            + "\"plug_2\" : {\"on\" : null,\"setting\":{\"name\":null}},"
                            + "\"plug_3\" : {\"on\" : null,\"setting\":{\"name\":null}}}");
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

        private void PicZDC1Switch_Click(object sender, EventArgs e)
        {
            PictureBox zDC1SwitchPic = (PictureBox)sender;
            int index = (int)zDC1SwitchPic.Tag;

            if (index > 0)
            {
                Send("{\"mac\":\"" + GetMac() + "\",\"plug_" + index + "\":{\"on\":" + (plugSwitch[index] ? "0" : "1") + "}}");
            }
            else
            {
                if (plugSwitch[index])
                    Send("{\"mac\":\"" + GetMac() + "\",\"plug_0\":{\"on\":0},\"plug_1\":{\"on\":0},\"plug_2\":{\"on\":0},\"plug_3\":{\"on\":0}}");
                else
                    Send("{\"mac\":\"" + GetMac() + "\",\"plug_0\":{\"on\":1},\"plug_1\":{\"on\":1},\"plug_2\":{\"on\":1},\"plug_3\":{\"on\":1}}");
            }

            plugSwitch[index] = !plugSwitch[index];
            picZDC1SwitchPic[index].Image = plugSwitch[index] ? Properties.Resources.device_open : Properties.Resources.device_close;

        }

        private void linkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshStatus();
        }

        #region hass配置文件相关
        const string hassConfig =   "mqtt:\n" +
                                    "  switch:\n" +
                                    "    - name: 'zDC1_plug0_MACMAC'\n" +
                                    "      unique_id: zDC1_plug0_MACMAC\n" +
                                    "      state_topic: 'device/zdc1/MACMAC/state'\n" +
                                    "      command_topic: 'device/zdc1/MACMAC/set'\n" +
                                    "      payload_on: '{\"mac\":\"MACMAC\",\"plug_0\":{\"on\":1},\"plug_1\":{\"on\":1},\"plug_2\":{\"on\":1},\"plug_3\":{\"on\":1}}'\n" +
                                    "      payload_off: '{\"mac\":\"MACMAC\",\"plug_0\":{\"on\":0}}'\n" +
                                    "      value_template: '{{ value_json.plug_0.on }}'\n" +
                                    "      state_on: '1'\n" +
                                    "      state_off: '0'\n" +
                                    "#      availability_topic: \"device/zdc1/MACMAC/availability\"\n" +
                                    "#      payload_available: 1\n" +
                                    "#      payload_not_available: 0\n" +
                                    "    - name: 'zDC1_plug1_MACMAC'\n" +
                                    "      unique_id: zDC1_plug1_MACMAC\n" +
                                    "      state_topic: 'device/zdc1/MACMAC/state'\n" +
                                    "      command_topic: 'device/zdc1/MACMAC/set'\n" +
                                    "      payload_on: '{\"mac\":\"MACMAC\",\"plug_1\":{\"on\":1}}'\n" +
                                    "      payload_off: '{\"mac\":\"MACMAC\",\"plug_1\":{\"on\":0}}'\n" +
                                    "      value_template: '{{ value_json.plug_1.on }}'\n" +
                                    "      state_on: '1'\n" +
                                    "      state_off: '0'\n" +
                                    "#      availability_topic: \"device/zdc1/MACMAC/availability\"\n" +
                                    "#      payload_available: 1\n" +
                                    "#      payload_not_available: 0\n" +
                                    "    - name: 'zDC1_plug2_MACMAC'\n" +
                                    "      unique_id: zDC1_plug2_MACMAC\n" +
                                    "      state_topic: 'device/zdc1/MACMAC/state'\n" +
                                    "      command_topic: 'device/zdc1/MACMAC/set'\n" +
                                    "      payload_on: '{\"mac\":\"MACMAC\",\"plug_2\":{\"on\":1}}'\n" +
                                    "      payload_off: '{\"mac\":\"MACMAC\",\"plug_2\":{\"on\":0}}'\n" +
                                    "      value_template: '{{ value_json.plug_2.on }}'\n" +
                                    "      state_on: '1'\n" +
                                    "      state_off: '0'\n" +
                                    "#      availability_topic: \"device/zdc1/MACMAC/availability\"\n" +
                                    "#      payload_available: 1\n" +
                                    "#      payload_not_available: 0\n" +
                                    "    - name: 'zDC1_plug3_MACMAC'\n" +
                                    "      unique_id: zDC1_plug3_MACMAC\n" +
                                    "      state_topic: 'device/zdc1/MACMAC/state'\n" +
                                    "      command_topic: 'device/zdc1/MACMAC/set'\n" +
                                    "      payload_on: '{\"mac\":\"MACMAC\",\"plug_3\":{\"on\":1}}'\n" +
                                    "      payload_off: '{\"mac\":\"MACMAC\",\"plug_3\":{\"on\":0}}'\n" +
                                    "      value_template: '{{ value_json.plug_3.on }}'\n" +
                                    "      state_on: '1'\n" +
                                    "      state_off: '0'\n" +
                                    "#      availability_topic: \"device/zdc1/MACMAC/availability\"\n" +
                                    "#      payload_available: 1\n" +
                                    "#      payload_not_available: 0\n" +
                                    "  sensor:\n" +
                                    "    - name: 'zdc1_power_MACMAC'\n" +
                                    "      unique_id: zdc1_power_MACMAC\n" +
                                    "      state_topic: 'device/zdc1/MACMAC/sensor'\n" +
                                    "      unit_of_measurement: 'W'\n" +
                                    "      icon: 'mdi:gauge'\n" +
                                    "      value_template: '{{ value_json.power }}'\n" +
                                    "    - name: 'zdc1_current_MACMAC'\n" +
                                    "      unique_id: zdc1_current_MACMAC\n" +
                                    "      state_topic: 'device/zdc1/MACMAC/sensor'\n" +
                                    "      unit_of_measurement: 'A'\n" +
                                    "      icon: 'mdi:gauge'\n" +
                                    "      value_template: '{{ value_json.current}}'\n" +
                                    "    - name: 'zdc1_voltage_MACMAC'\n" +
                                    "      unique_id: zdc1_voltage_MACMAC\n" +
                                    "      state_topic: 'device/zdc1/MACMAC/sensor'\n" +
                                    "      unit_of_measurement: 'V'\n" +
                                    "      icon: 'mdi:gauge'\n" +
                                    "      value_template: '{{ value_json.voltage}}'\n" +
                                    "\n" +
                                    "#可以手动修改一下内容来自定义各设备名称\n" +
                                    "\n" +
                                    "homeassistant:\n" +
                                    "  customize:\n" +
                                    "    switch.zDC1_plug0_MACMAC:\n" +
                                    "      friendly_name: zDC1总开关\n" +
                                    "    switch.zDC1_plug1_MACMAC:\n" +
                                    "      friendly_name: zDC1插槽1\n" +
                                    "    switch.zDC1_plug2_MACMAC:\n" +
                                    "      friendly_name: zDC1插槽2\n" +
                                    "    switch.zDC1_plug3_MACMAC:\n" +
                                    "      friendly_name: zDC1插槽3\n" +
                                    "    sensor.zdc1_power_MACMAC:\n" +
                                    "      friendly_name: zDC1功率\n" +
                                    "    sensor.zdc1_current_MACMAC:\n" +
                                    "      friendly_name: zDC1电流\n" +
                                    "    sensor.zdc1_voltage_MACMAC:\n" +
                                    "      friendly_name: zDC1电压\n";

        protected override String GetHassString()
        {
            String str = hassConfig.Replace("\n", "\r\n").Replace("MACMAC", GetMac());
            if (chkHassNameChoice.Checked)
            {
                str = str.Replace("zTC1插口2", labZDC1SwitchName[1].Text);
                str = str.Replace("zTC1插口3", labZDC1SwitchName[2].Text);
                str = str.Replace("zTC1插口4", labZDC1SwitchName[3].Text);
            }
            return str;
        }

        #endregion

    }
}
