using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using static ZControl.DeviceItem;

namespace ZControl
{
    public partial class Form1 : Form
    {
        private MqttClient mqttClient;
        private Boolean reConnect = false;
        UdpClient udpClient;

        public Form1()
        {
            InitializeComponent();

            //labVersion.Text = "v" + System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;
            labVersion.Text = "软件版本 v0.2.0";



            //listBox1.Items.Add(new DeviceItemZTC1("zTC1_184d", "d0bae463184d"));
            //for (int i = 0; i < 1; i++)
               listBox1.Items.Add(new DeviceItemZDC1("zTC1_0000", "000000000000"));


            //JArray jArray = new JArray();
            //JObject obj = new JObject();
            //foreach (DeviceItem d in listBox1.Items)
            //{
            //    JObject objItem = new JObject();
            //    objItem["mac"] = d.mac;
            //    objItem["name"] = d.name;
            //    objItem["type"] = (int)d.type;
            //    objItem["type_name"] = d.typeName;
            //    jArray.Add(objItem);
            //}
            //obj["device"] = jArray;
            //string json = obj.ToString();
            //Console.WriteLine(json);

            try
            {
                string json = Properties.Settings.Default.Device;
                JObject jsonObject = JObject.Parse(json);
                JArray array = (JArray)jsonObject["device"];
                for (int i = 0; i < array.Count; i++)
                {
                    JObject jObject = (JObject)array[i];
                    Console.WriteLine(jObject.ToString());
                    Received(null, jObject.ToString());
                }
            }
            catch (Exception)
            {
                listBox1.Items.Clear();
                //throw;
            }


            if (listBox1.Items.Count < 1)
                listBox1.Items.Add(new DeviceItemZTC1("zTC1_演示设备", "000000000000"));

            listBox1.SelectedIndex = 0;
            deviceControl1.Device = (DeviceItem)listBox1.SelectedItem;
            deviceControl1.MsgPublishEvent += send;
            if (txtMQTTServer.TextLength > 0 && txtMQTTUser.TextLength > 0 && txtMQTTPassword.TextLength > 0)
            {
                mqttConnect(txtMQTTServer.Text, (int)numMQTTPort.Value, txtMQTTUser.Text, txtMQTTPassword.Text);
            }
            udpConnect();
        }

        private void send(string topic, string message)
        {
            if (mqttClient == null || !mqttClient.IsConnected || topic == null)
            {
                //IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 10182);
                //byte[] data = Encoding.Default.GetBytes(message);
                //udpClient.Send(data, data.Length, ipendpoint);

                UdpClient udpclient = new UdpClient();
                IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 10182);

                byte[] data = Encoding.Default.GetBytes(message);
                udpclient.Send(data, data.Length, ipendpoint);
                udpclient.Close();
            }
            else
            {
                mqttClient.Publish(topic, Encoding.UTF8.GetBytes(message));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mqttDisconnect();

            JArray jArray = new JArray();
            JObject obj = new JObject();
            foreach (DeviceItem d in listBox1.Items)
            {
                if (d.mac.Equals("000000000000")) continue;
                JObject objItem = new JObject();
                objItem["mac"] = d.mac;
                objItem["name"] = d.name;
                objItem["type"] = (int)d.type;
                objItem["type_name"] = d.typeName;
                jArray.Add(objItem);
            }
            obj["device"] = jArray;
            string json = obj.ToString();
            Console.WriteLine(json);
            Properties.Settings.Default.Device = json;
            Properties.Settings.Default.Save();
        }

        #region 更新Log显示内容(包含多线程处理)
        delegate void SetTextCallBack(string text);
        private void Log(string text)
        {
            if (this.LabelLog.InvokeRequired)
            {
                try
                {
                    this.Invoke(new SetTextCallBack(Log), new object[] { text });

                }
                catch (Exception)
                {
                    //throw;
                }
            }
            else
            {
                this.LabelLog.Text = text;
            }
        }
        #endregion
        #region MQTT通信

        #region 更新mqtt连接/断开时UI更新
        private void MQTTConnectInitCallBack(bool isConnect)
        {
            if (isConnect)
            {
                //groupBoxMQTT.Enabled = false;
                txtMQTTServer.Enabled = false;
                numMQTTPort.Enabled = false;
                txtMQTTUser.Enabled = false;
                txtMQTTPassword.Enabled = false;
                btMQTTConfirm.Text = "断开";
                btMQTTConfirm.Image = Properties.Resources.open;
            }
            else
            {
                //groupBoxMQTT.Enabled = true;
                txtMQTTServer.Enabled = true;
                numMQTTPort.Enabled = true;
                txtMQTTUser.Enabled = true;
                txtMQTTPassword.Enabled = true;
                btMQTTConfirm.Text = "连接";
                btMQTTConfirm.Image = Properties.Resources.close;
            }

        }
        private delegate void MQTTConnectInit_dg(bool _b);
        private void MQTTConnectInit(bool isConnect)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MQTTConnectInit_dg(MQTTConnectInitCallBack), new object[] { isConnect });

                }
                catch (Exception)
                {
                    //throw;
                }
            }
            else
            {
                MQTTConnectInitCallBack(isConnect);
            }
        }
        #endregion

        #region mqtt连接/断开子函数
        private void mqttDisconnect()
        {
            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Disconnect();
            }
        }
        private void mqttConnect(String url, int port, String user, String password)
        {
            try
            {
                //创建客户端实例
                mqttClient = new MqttClient(url, port, false, null, null, MqttSslProtocols.None);

                mqttClient.MqttMsgPublishReceived += MqttMsgPublishReceived;
                mqttClient.ConnectionClosed += ConnectionClosed;
                mqttClient.MqttMsgUnsubscribed += MqttMsgUnsubscribed;
                mqttClient.MqttMsgSubscribed += MqttMsgSubscribed;
                mqttClient.MqttMsgPublished += MqttMsgPublished;

                byte code = mqttClient.Connect(Guid.NewGuid().ToString(), user, password);
                if (code != 0)
                {
                    Log("MQTT服务器连接失败:" + code);
                    return;
                }
                MQTTConnectInit(true);
                Log("MQTT服务器已连接");

                mqttClient.Subscribe(new String[] { "device/ztc1/+/sensor" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                mqttClient.Subscribe(new String[] { "device/ztc1/+/state" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });


                mqttClient.Subscribe(new String[] { "device/zdc1/+/sensor" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                mqttClient.Subscribe(new String[] { "device/zdc1/+/state" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

                //String temp = "asdf";
                //mqttClient.Publish("sensor/temp", Encoding.UTF8.GetBytes(temp));

            }
            catch (Exception ee)
            {
                MessageBox.Show("无法连接，请确定代理服务器是否启动，IP端口是否正确");
            }
        }
        #endregion

        #region mqtt状态事件函数
        void MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // Handle message received
            //var message = System.Text.Encoding.Default.GetString(e.Message);
            //System.Console.WriteLine("MqttMsgPublishReceived: " + message);

            Received(e.Topic, System.Text.Encoding.UTF8.GetString(e.Message));
        }
        void ConnectionClosed(object sender, EventArgs e)
        {
            System.Console.WriteLine("ConnectionClosed");
            MQTTConnectInit(false);
            Log("MQTT服务器已断开");
        }
        void MqttMsgUnsubscribed(object sender, MqttMsgUnsubscribedEventArgs e)
        {
            System.Console.WriteLine("MqttMsgUnsubscribed");
        }
        void MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            System.Console.WriteLine("MqttMsgSubscribed");
        }
        void MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        {
            System.Console.WriteLine("MqttMsgPublished");
        }
        #endregion



        #endregion
        #region UDP通信
        void udpConnect()
        {
            //创建接收线程
            Thread RecivceThread = new Thread(RecivceMsg);
            RecivceThread.IsBackground = true;
            RecivceThread.Start();

        }

        private void RecivceMsg()
        {
            //IPEndPoint local = new IPEndPoint(0xffffffff, 10181);
            udpClient = new UdpClient(10181);

            IPEndPoint remote = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                try
                {
                    byte[] recivcedata = udpClient.Receive(ref remote);
                    string strMsg = Encoding.UTF8.GetString(recivcedata, 0, recivcedata.Length);
                    //System.Console.WriteLine("udp:"+string.Format("来自{0}：{1}", remote, strMsg));
                    Received(null, strMsg);
                }
                catch
                {
                    break;
                }
            }
        }

        #endregion
        #region MQTT/UDP接受数据处理函数(包含线程处理)
        private void PublishReceivedCallBack(String topic, String message)
        {
            System.Console.WriteLine("Received topic [" + topic + "] :" + message);
            int index;
            try
            {
                JObject jObject = JObject.Parse(message);
                if (jObject.Property("mac") == null) return;

                if (jObject.Property("type") != null
                   && jObject.Property("type_name") != null
                   && jObject.Property("name") != null
                   && jObject.Property("mac") != null)
                {

                    for (index = 0; index < listBox1.Items.Count; index++)
                    {
                        if (jObject["mac"].ToString().Equals(((DeviceItem)listBox1.Items[index]).mac))
                        {
                            break;
                        }
                    }
                    if (index < listBox1.Items.Count) return;   //设备重复,不增加
                    switch ((DEVICETYPE)(int)jObject["type"])
                    {
                        case DEVICETYPE.TYPE_TC1:
                            DeviceItemZTC1 deviceItemZTC1 = new DeviceItemZTC1(jObject["name"].ToString(), jObject["mac"].ToString());
                            deviceItemZTC1.typeName = jObject["type_name"].ToString();
                            listBox1.Items.Insert(0, deviceItemZTC1);
                            break;
                        case DEVICETYPE.TYPE_DC1:
                            DeviceItemZDC1 deviceItemZDC1 = new DeviceItemZDC1(jObject["name"].ToString(), jObject["mac"].ToString());
                            deviceItemZDC1.typeName = jObject["type_name"].ToString();
                            listBox1.Items.Insert(0, deviceItemZDC1);
                            break;
                    }
                    return;
                }


                String reMac = jObject["mac"].ToString();


                for (index = 0; index < listBox1.Items.Count; index++)
                {
                    //if(index)
                    if (reMac.Equals(((DeviceItem)listBox1.Items[index]).mac))
                    {
                        System.Console.WriteLine("设备:" + index);
                        break;
                    }
                }

                if (index >= listBox1.Items.Count) return;

                switch (((DeviceItem)listBox1.Items[index]).type)
                {
                    case DEVICETYPE.TYPE_TC1:
                        zTC1Received(index, message);
                        break;
                    case DEVICETYPE.TYPE_DC1:
                        zDC1Received(index, message);
                        break;

                }

            }
            catch (Exception)
            {

                //throw;
            }

        }
        #region MQTT/UDP接受数据线程处理函数
        private delegate void PublishReceived_dg(String topic, String message);
        private void Received(String topic, String message)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new PublishReceived_dg(PublishReceivedCallBack), new object[] { topic, message });

                }
                catch (Exception)
                {
                    //throw;
                }
            }
            else
            {
                PublishReceivedCallBack(topic, message);
            }
        }
        #endregion
        #endregion

        private void zTC1Received(int index, string message)
        {
            DeviceItemZTC1 device = (DeviceItemZTC1)listBox1.Items[index];
            JObject jsonObject = JObject.Parse(message);
            if (!device.mac.Equals(jsonObject["mac"].ToString())) return;


            if (jsonObject.Property("name") != null)
            {
                device.name = jsonObject["name"].ToString();
                if (index == listBox1.SelectedIndex) deviceControl1.zTC1RefreshName();
                listBox1.Refresh(); //更新列表里的名称/mac地址
            }

            if (jsonObject.Property("lock") != null)
            {
                device.zTC1Lock = (bool)jsonObject["lock"];
                if (index == listBox1.SelectedIndex) deviceControl1.zTC1RefreshLock();
            }
            if (jsonObject.Property("power") != null)
            {
                device.zTC1Power = jsonObject["power"].ToString();
                if (index == listBox1.SelectedIndex) deviceControl1.zTC1RefreshPower();

            }
            if (jsonObject.Property("total_time") != null)
            {
                device.zTC1TotalTime = (uint)jsonObject["total_time"];
                if (index == listBox1.SelectedIndex) deviceControl1.zTC1RefreshTotalTime();
            }

            #region 解析plug
            bool plugReturnFlag = false;
            for (int plug_id = 0; plug_id < 6; plug_id++)
            {
                if (jsonObject.Property("plug_" + plug_id) == null) continue;
                plugReturnFlag = true;
                JObject jsonPlug = (JObject)jsonObject["plug_" + plug_id];
                if (jsonPlug.Property("on") != null)
                {
                    int on = (int)jsonPlug["on"];
                    device.zTC1Switch[plug_id] = (on != 0);
                    deviceControl1.zTC1RefreshSwitch(plug_id);
                }
                if (jsonPlug.Property("setting") == null) continue;
                JObject jsonPlugSetting = (JObject)jsonPlug["setting"];
                if (jsonPlugSetting.Property("name") != null)
                {
                    device.zTC1SwitchName[plug_id] = jsonPlugSetting["name"].ToString();
                    deviceControl1.zTC1RefreshSwitchName(plug_id);
                }
            }
            #endregion


            //if (index == listBox1.SelectedIndex)
            //{
            //    deviceControl1.zTC1RefreshName();
            //    deviceControl1.zTC1RefreshMac();
            //    deviceControl1.zTC1RefreshPower();
            //    deviceControl1.zTC1RefreshTotalTime();
            //    for (int i = 0; i < 6; i++)
            //    {
            //         deviceControl1.zTC1RefreshSwitch(i);
            //        deviceControl1.zTC1RefreshSwitchName(i);
            //    }
            //}
        }
        private void zDC1Received(int index, string message)
        {
            DeviceItemZDC1 device = (DeviceItemZDC1)listBox1.Items[index];
            JObject jsonObject = JObject.Parse(message);
            if (!device.mac.Equals(jsonObject["mac"].ToString())) return;


            if (jsonObject.Property("name") != null)
            {
                device.name = jsonObject["name"].ToString();
                if (index == listBox1.SelectedIndex) deviceControl1.zDC1RefreshName();
                listBox1.Refresh(); //更新列表里的名称/mac地址
            }


            if (jsonObject.Property("power") != null)
            {
                device.zDC1Power = jsonObject["power"].ToString();
                if (index == listBox1.SelectedIndex) deviceControl1.zDC1RefreshPower();

            }
            if (jsonObject.Property("voltage") != null)
            {
                device.zDC1Voltage = jsonObject["voltage"].ToString();
                if (index == listBox1.SelectedIndex) deviceControl1.zDC1RefreshVoltage();

            }
            if (jsonObject.Property("current") != null)
            {
                device.zDC1Current = jsonObject["current"].ToString();
                if (index == listBox1.SelectedIndex) deviceControl1.zDC1RefreshCurrent();

            }
            if (jsonObject.Property("total_time") != null)
            {
                device.zDC1TotalTime = (uint)jsonObject["total_time"];
                if (index == listBox1.SelectedIndex) deviceControl1.zDC1RefreshTotalTime();
            }

            #region 解析plug
            bool plugReturnFlag = false;
            for (int plug_id = 0; plug_id < 6; plug_id++)
            {
                if (jsonObject.Property("plug_" + plug_id) == null) continue;
                plugReturnFlag = true;
                JObject jsonPlug = (JObject)jsonObject["plug_" + plug_id];
                if (jsonPlug.Property("on") != null)
                {
                    int on = (int)jsonPlug["on"];
                    device.zDC1Switch[plug_id] = (on != 0);
                    deviceControl1.zDC1RefreshSwitch(plug_id);
                }
                if (jsonPlug.Property("setting") == null) continue;
                JObject jsonPlugSetting = (JObject)jsonPlug["setting"];
                if (jsonPlugSetting.Property("name") != null)
                {
                    device.zDC1SwitchName[plug_id] = jsonPlugSetting["name"].ToString();
                    deviceControl1.zDC1RefreshSwitchName(plug_id);
                }
            }
            #endregion

        }

        #region 设置devicelist Item自定义界面
        const int DEVICE_LIST_ITEM_HEIGHT = 40;
        private void ListBox1_DrawItem(object sender, DrawItemEventArgs e)
        {


            if (e.Index == -1)
                return;
            e.DrawBackground();

            e.DrawFocusRectangle();
            // prefixes are drawed bold

            DeviceItem device = (DeviceItem)((ListBox)sender).Items[e.Index];


            //draw the ICON
            Rectangle rectangle = new Rectangle(e.Bounds.Location, new Size(DEVICE_LIST_ITEM_HEIGHT, DEVICE_LIST_ITEM_HEIGHT));
            //e.Graphics.DrawImage(Properties.Resources.device_item_0, e.Bounds.Location);
            e.Graphics.DrawImage(Properties.Resources.device_item_0, rectangle);

            //draw the txt
            Brush fontColor = new SolidBrush(Color.Black);
            Font nameFont = new Font(e.Font.FontFamily, 12, FontStyle.Bold);

            Rectangle newBounds = new Rectangle(e.Bounds.Location, e.Bounds.Size);

            // draw the name string
            e.Graphics.DrawString(device.name, nameFont, fontColor, newBounds.X + DEVICE_LIST_ITEM_HEIGHT, newBounds.Y + 5);
            // calculate the new rectangle


            // draw the mac string
            e.Graphics.DrawString(device.mac, e.Font, fontColor, newBounds.X + DEVICE_LIST_ITEM_HEIGHT + 2, newBounds.Y + 26);

            // draw the focus
            e.DrawFocusRectangle();


        }

        private void ListBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = DEVICE_LIST_ITEM_HEIGHT;
        }
        #endregion

        private void BtMQTTConfirm_Click(object sender, EventArgs e)
        {
            if (txtMQTTServer.TextLength < 1 || txtMQTTUser.TextLength < 1 || txtMQTTPassword.TextLength < 1)
            {
                MessageBox.Show("请确认MQTT服务填写正确!");
                return;
            }

            if (mqttClient != null && mqttClient.IsConnected)
                mqttDisconnect();
            else
                mqttConnect(txtMQTTServer.Text, (int)numMQTTPort.Value, txtMQTTUser.Text, txtMQTTPassword.Text);



        }


        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            deviceControl1.Device = (DeviceItem)listBox1.SelectedItem;
        }

        private void BtnDeviceListDel_Click(object sender, EventArgs e)
        {
            DeviceItem d = (DeviceItem)listBox1.SelectedItem;
            if (d == null) return;
            if (MessageBox.Show("删除设备:\n" + d.name + " (" + d.mac + ")", "删除设备", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.OK)
            {
                int index = listBox1.SelectedIndex;
                if (listBox1.Items.Count == 1) index = -1;
                else if (index > 0) index--;
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                listBox1.SelectedIndex = index;
            }
        }

        private void BtnDeviceListAdd_Click(object sender, EventArgs e)
        {
            send(null, "{\"cmd\":\"device report\"}");
        }

        private void BtnDeviceMQTTSend_Click(object sender, EventArgs e)
        {
            DeviceItem d = (DeviceItem)listBox1.SelectedItem;
            if (d == null) return;

            if (!mqttClient.IsConnected)
            {
                MessageBox.Show("MQTT服务器未连接成功,请先确认连接成后,再同步mqtt服务器", "MQTT未连接");
                return;
            }

            JArray jArray = new JArray();
            JObject obj = new JObject();
            obj["mac"] = d.mac;

            JObject objItem = new JObject();
            objItem["mqtt_uri"] = txtMQTTServer.Text;
            objItem["mqtt_port"] = (int)numMQTTPort.Value;
            objItem["mqtt_user"] = txtMQTTUser.Text;
            objItem["mqtt_password"] = txtMQTTPassword.Text;


            obj["setting"] = objItem;
            string json = obj.ToString();

            send(null, json);
        }

        private void ZDC1热点配网toolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("zDC1 热点模式配网步骤:\r\n" +
                "1. 排插断电,等待20秒后按住按键上电.上电2秒左右松开按键(按键不要超过5秒)\r\n" +
                "2. pc连接热点,并断开其他网络.\r\n" +
                "3. 单击本软件获取局域网按钮,添加新排插\r\n" +
                "4. 输入要连接的wifi名称及密码,然后点击配对,等待排插连上路由器\r\n" +
                "5. 恢复pc网络即可","配对方法:");
            deviceControl1.ZDC1WifiShow = ((ToolStripMenuItem)sender).Checked;
        }
    }
}
