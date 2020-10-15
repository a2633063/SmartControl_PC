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
            btnHass.Enabled = true;
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


        #region hass配置文件相关
        const string hassConfig = "sensor:\n" +
                    "  - platform: mqtt\n" +
                    "    name: 'zm1_MACMAC_temperature'\n" +
                    "    unique_id: zm1_MACMAC_temperature\n" +
                    "    # friendly_name: 温度\n" +
                    "    state_topic: 'device/zm1/MACMAC/sensor'\n" +
                    "    unit_of_measurement: '°C'\n" +
                    "    icon: 'mdi:thermometer'\n" +
                    "    value_template: '{{ value_json.temperature }}'\n" +
                    "  - platform: mqtt\n" +
                    "    name: 'zm1_MACMAC_humidity'\n" +
                    "    unique_id: zm1_MACMAC_humidity\n" +
                    "    # friendly_name: 湿度\n" +
                    "    state_topic: 'device/zm1/MACMAC/sensor'\n" +
                    "    unit_of_measurement: '%'\n" +
                    "    icon: mdi:water-percent\n" +
                    "    value_template: '{{ value_json.humidity }}'\n" +
                    "  - platform: mqtt\n" +
                    "    name: 'zm1_MACMAC_pm25'\n" +
                    "    unique_id: zm1_MACMAC_pm25\n" +
                    "    # friendly_name: PM25\n" +
                    "    state_topic: 'device/zm1/MACMAC/sensor'\n" +
                    "    unit_of_measurement: 'μg/m³'\n" +
                    "    icon: mdi:blur\n" +
                    "    value_template: '{{ value_json.PM25 }}'\n" +
                    "  - platform: mqtt\n" +
                    "    name: 'zm1_MACMAC_hcho'\n" +
                    "    unique_id: zm1_MACMAC_hcho\n" +
                    "    # friendly_name: 甲醛\n" +
                    "    state_topic: 'device/zm1/MACMAC/sensor'\n" +
                    "    unit_of_measurement: 'mg/m³'\n" +
                    "    icon: mdi:chemical-weapon\n" +
                    "    value_template: '{{ value_json.formaldehyde }}'\n" +
                    "\n" +
                    "light:\n" +
                    "  - platform: mqtt\n" +
                    "    name: zm1_MACMAC_brightness\n" +
                    "    unique_id: zm1_MACMAC_brightness\n" +
                    "    schema: template\n" +
                    "    command_topic: \"device/zm1/MACMAC/set\"\n" +
                    "    state_topic: \"device/zm1/MACMAC/state\"\n" +
                    "    command_on_template: >\n" +
                    "      {\"mac\": \"MACMAC\"\n" +
                    "      {%- if brightness is defined -%}\n" +
                    "      , \"brightness\": {{ ((brightness-1) / 64 )|int +1 }}\n" +
                    "      {%- else -%}\n" +
                    "      , \"brightness\": 4\n" +
                    "      {%- endif -%}\n" +
                    "      }\n" +
                    "    command_off_template: '{\"mac\": \"MACMAC\", \"brightness\": 0}'\n" +
                    "    state_template: >\n" +
                    "      {%- if value_json.brightness == 0 -%}\n" +
                    "        off\n" +
                    "      {%- else -%}\n" +
                    "        on\n" +
                    "      {%- endif -%}\n" +
                    "    brightness_template: >\n" +
                    "      {%- if value_json.brightness is defined -%}\n" +
                    "        {{ ( value_json.brightness *64 )|int }}\n" +
                    "      {%- endif -%}\n" +
                    "\n" +
                    "\n" +
                    "homeassistant:\n" +
                    "  customize:\n" +
                    "    light.zm1_MACMAC_brightness:\n" +
                    "      friendly_name: zM1亮度\n" +
                    "    sensor.zm1_MACMAC_temperature:\n" +
                    "      friendly_name: zM1温度\n" +
                    "    sensor.zm1_MACMAC_humidity:\n" +
                    "      friendly_name: zM1湿度\n" +
                    "    sensor.zm1_MACMAC_pm25:\n" +
                    "      friendly_name: zM1 PM2.5\n" +
                    "    sensor.zm1_MACMAC_hcho:\n" +
                    "      friendly_name: zM1甲醛\n";

        protected override String GetHassString()
        {
            String str = hassConfig.Replace("\n", "\r\n").Replace("MACMAC", GetMac());
            return str;
        }

        #endregion
    }
}
