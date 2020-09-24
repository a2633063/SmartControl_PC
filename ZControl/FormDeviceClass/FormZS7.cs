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
    public partial class FormZS7 : FormItem
    {
        bool heat_flag = false;//接收到关闭且此为true时提示插上usb电才能加热
        private void Send(String message)
        {
            Send("device/zs7/" + GetMac() + "/set", message);
        }
        public FormZS7(String name, String mac) : base(DEVICETYPE.TYPE_S7, name, mac)
        {
            InitializeComponent();
        }
        #region 重写函数
        public override String[] GetRecvMqttTopic()
        {
            String[] topic = new String[3];
            topic[0] = "device/zs7/" + GetMac() + "/state";
            topic[1] = "device/zs7/" + GetMac() + "/sensor";
            topic[2] = "device/zs7/" + GetMac() + "/availability";
            return topic;
        }
        public override void Received(String topic, String message)
        {

            JObject jsonObject = JObject.Parse(message);
            if (!GetMac().Equals(jsonObject["mac"].ToString())) return;

            #region 加热
            if (jsonObject.ContainsKey("heat"))
            {
                int heat = (int)jsonObject["heat"];
                chkHeat.Checked = (heat != 0);

                if (heat == 0 && jsonObject.ContainsKey("charge") && (int)jsonObject["charge"] == 0
                        && heat_flag)
                {
                    heat_flag = false;
                    MessageBox.Show("请插USB电源后再打开加热功能");
                }
            }
            #endregion
            #region 更新体重信息
            if (jsonObject.ContainsKey("weight") && jsonObject.ContainsKey("time"))
            {
                int weight = (int)jsonObject["weight"];
                long utc = (long)jsonObject["time"] - 28800;   //多算了时区
                if (utc > 1500000000)
                {
                    DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
                    startTime = startTime.AddSeconds(utc);
                    //startTime = startTime.AddHours(0);//转化为北京时间(北京时间=UTC时间+8小时 )            
                    labLastTime.Text = "上次测量时间: " + startTime.ToString("yyyy/MM/dd HH:mm:ss");
                }
                else
                {
                    labLastTime.Text = "上次测量时间: 未知";
                }

                labWeight.Text = weight / 100 + "." + weight % 100 + "kg";
            }
            #endregion

            #region 历史体重数据
            if (jsonObject.ContainsKey("history"))
            {

                JToken jsonHistory = jsonObject["history"];
                JToken jsonWeight = jsonHistory["weight"];
                JToken jsonTime = jsonHistory["utc"];
                if (jsonWeight != null && jsonTime != null)
                {
                    LstHistory.Items.Clear();
                    for (int i = 0; i < jsonWeight.Count() && i < jsonTime.Count(); i++)
                    {
                        int weight = (int)jsonWeight[i];
                        long utc = (long)jsonTime[i] - 28800;   //多算了时区
                        String time = "    未知时间    ";
                        if (utc > 1500000000)
                        {
                            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
                            startTime = startTime.AddSeconds(utc);
                            //startTime = startTime.AddHours(0);//转化为北京时间(北京时间=UTC时间+8小时 )            
                            time = startTime.ToString("yyyy/MM/dd HH:mm");
                        }
                        LstHistory.Items.Insert(0,String.Format("{0,2}: {1,12}  {2,3}.{3:D2}kg", jsonWeight.Count()-i, time, weight / 100, weight % 100));
                    }
                }


                //JArray jsonWeight = jsonHistory.getJSONArray("weight");
                //JArray jsonTime = jsonHistory.getJSONArray("utc");
                //int length = jsonWeight.length();
                //if (length < 1)
                //{
                //    labWeight.Text="无历史数据";
                //}
                //else
                //{

                //    int weight = jsonWeight.getInt(length - 1);
                //    long utc = jsonTime.getLong(length - 1) - 28800;   //多算了时区
                //    if (utc > 1500000000)
                //    {
                //        Date date = new Date(utc * 1000);
                //        SimpleDateFormat sdf = new SimpleDateFormat("yyyy/MM/dd  HH:mm ");
                //        tv_time.setText("上次测量时间: " + sdf.format(date));
                //    }
                //    else
                //    {
                //        tv_time.setText("上次测量时间: 未知");
                //    }

                //    tv_weight.setText(weight / 100 + "." + weight % 100 + "kg");
                //    lineTable.getWeightList().clear();
                //    for (int i = 0; i < length; i++)
                //    {
                //        lineTable.getWeightList().add(new WeightHistoryData(jsonWeight.getInt(i), jsonTime.getLong(i) - 28800));
                //    }
                //    lineTable.invalidate();
                //}
            }
            #endregion


            #region 电池/充电状态
            if (jsonObject.ContainsKey("battery"))
            {
                int bat = (int)jsonObject["battery"];
                bat = (bat - 370) * 2;
                if (bat > 98) bat = 100;
                else if (bat < 0) bat = 0;
                labBattery.Text =
                    String.Format("电量:{0,3}%", bat);
                labBattery.Visible = true;
            }
            if (jsonObject.ContainsKey("charge"))
            {
                int charge = (int)jsonObject["charge"];
                labCharge.Visible = (charge != 0);
            }

            #endregion



            if (jsonObject.Property("version") != null)
            {
                labelVersion.Text = "固件版本: " + jsonObject["version"].ToString();
            }

        }

        public override void RefreshStatus()
        {
            Send("{\"mac\": \"" + GetMac() + "\","
                            + "\"version\":null,"
                            + "\"battery\":null,"
                            + "\"heat\":null,"
                            + "\"charge\":null,"
                            + "\"history\":null}");
        }

        public override void SetOnline(bool online)
        {
            base.SetOnline(online);
            labZS7Log.Visible = true;
            if (online)
            {
                labZS7Log.Text = "设备在线";
                RefreshStatus();
            }
            else { labZS7Log.Text = "设备离线,请站上称点亮屏幕以连接设备"; }
        }
        #endregion

        private void linkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshStatus();
        }

        private void chkHeat_Click(object sender, EventArgs e)
        {
            if (chkHeat.Checked) heat_flag = true;

            Send("{\"mac\":\"" + GetMac() + "\",\"heat\":" + (chkHeat.Checked ? "1" : "0") + "}");

        }
    }
}
