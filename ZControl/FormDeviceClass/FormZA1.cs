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
    public partial class FormZA1 : FormItem
    {


        private void Send(String message)
        {
            Send("device/za1/" + GetMac() + "/set", message);
        }
        public FormZA1(String name, String mac) : base(DEVICETYPE.TYPE_A1, name, mac)
        {
            InitializeComponent();
            btnHass.Enabled = true;
        }
        #region 重写函数
        public override String[] GetRecvMqttTopic()
        {
            String[] topic = new String[3];
            topic[0] = "device/za1/" + GetMac() + "/state";
            topic[1] = "device/za1/" + GetMac() + "/sensor";
            topic[2] = "device/za1/" + GetMac() + "/availability";
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

            if (jsonObject.Property("version") != null)
            {
                labelVersion.Text = "固件版本: " + jsonObject["version"].ToString();
            }

            if (jsonObject.Property("speed") != null)
            {
                trbSpeed.Value = (int)jsonObject["speed"];
            }
            if (jsonObject.Property("on") != null)
            {
                int on = (int)jsonObject["on"];
                chkSwitch.Checked = (on == 1);
            }
        }

        public override void RefreshStatus()
        {
            Send("{\"mac\": \"" + GetMac() + "\","
                            + "\"version\":null,"
                            + "\"on\" : null,"
                            + "\"lock\" : null,"
                            + "\"speed\" : null}");
        }

        #endregion

        private void linkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshStatus();
        }

        private void trbSpeed_ValueChanged(object sender, EventArgs e)
        {
            labSpeed.Text = "风速" + trbSpeed.Value;
        }

        private void chkSwitch_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("chkSwitch_CheckedChanged");
            if (chkSwitch.Checked)
            {
                chkSwitch.Text = "关闭";
                chkSwitch.Image = Properties.Resources.device_open;
            }
            else
            {
                chkSwitch.Text = "启动";
                chkSwitch.Image = Properties.Resources.device_close;
            }
        }

        private void chkSwitch_Click(object sender, EventArgs e)
        {
            Console.WriteLine("chkSwitch_Click");
            Send("{\"mac\": \"" + GetMac() + "\",\"on\" : " + (chkSwitch.Checked ? "1" : "0") + "}");

        }

        private void trbSpeed_Scroll(object sender, EventArgs e)
        {

            timerSend.Enabled = false;
            timerSend.Enabled = true;
            //Send("{\"mac\": \"" + GetMac() + "\",\"speed\" : " + trbSpeed.Value + "}");
        }

        private void timerSend_Tick(object sender, EventArgs e)
        {
            // Console.WriteLine("timerSend_Tick");

            Send("{\"mac\": \"" + GetMac() + "\",\"speed\" : " + trbSpeed.Value + "}");
            timerSend.Enabled = false;
        }

        private void labLock_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string lockStr = Microsoft.VisualBasic.Interaction.InputBox("请输入32位长度激活码\r\n\r\nzA1激活码为16元/个,激活码请根据文档获取\r\n\r\nzTC1激活码免费获取,zA1激活码收费,其他设备不需要激活码,免费试用", "输入激活码", "");
            lockStr = lockStr.Trim().ToLower();
            Regex regex = new Regex(@"[1234567890abcdef]{32}");
            if (/*lockStr == null || */ !regex.IsMatch(lockStr))
            {
                MessageBox.Show("激活码格式输入错误.\r\n请确认不包含mac地址,长度32位字符串.\r\n请重试");
                return;
            }

            Send("{\"mac\":\"" + GetMac() + "\",\"lock\":\"" + lockStr + "\"}");
        }


        #region hass配置文件相关
        const string hassConfig = "mqtt:\n" +
                                    "  fan:\n" +
                                    "    name: 'za1_MACMAC'\n" +
                                    "    unique_id: za1_MACMAC\n" +
                                    "    state_topic: \"device/za1/MACMAC/state\"\n" +
                                    "    command_topic: \"device/za1/MACMAC/set\"\n" +
                                    "    payload_on: '{\"mac\":\"MACMAC\",\"on\":1}'\n" +
                                    "    payload_off: '{\"mac\":\"MACMAC\",\"on\":0}'\n" +
                                    "    state_value_template: >\n" +
                                    "      {%- if value_json.on == 0 -%}\n" +
                                    "        {\"mac\":\"MACMAC\",\"on\":0}\n" +
                                    "      {%- else -%}\n" +
                                    "        {\"mac\":\"MACMAC\",\"on\":1}\n" +
                                    "      {%- endif -%}\n" +
                                    "    qos: 0\n" +
                                    "    percentage_state_topic: \"device/za1/MACMAC/state\"\n" +
                                    "    percentage_command_topic: \"device/za1/MACMAC/set\"\n" +
                                    "    percentage_command_template: '{\"mac\":\"MACMAC\",\"speed\":{{ value }}}'\n" +
                                    "    percentage_value_template: '{{ value_json.speed }}'\n" +
                                    "\n" +

                                    "homeassistant:\n" +
                                    "  customize:\n" +
                                    "    fan.za1_MACMAC:\n" +
                                    "      friendly_name: zA1空气净化器\n";

        protected override String GetHassString()
        {
            String str = hassConfig.Replace("\n", "\r\n").Replace("MACMAC", GetMac());
            return str;
        }

        #endregion
    }
}
