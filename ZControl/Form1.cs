using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ZControl
{
    public partial class Form1 : Form
    {
        private MqttClient client;
        private Boolean reConnect = false;
        public Form1()
        {
            InitializeComponent();

            if (txtMQTTServer.TextLength > 0 || txtMQTTUser.TextLength > 0 || txtMQTTPassword.TextLength > 0)
            {
                mqtt_connect(txtMQTTServer.Text, txtMQTTUser.Text, txtMQTTPassword.Text);
            }

            for(int i=0;i<50;i++)
            listBox1.Items.Add(new DeviceItem(1, "test"+i, "00000000000" + i));
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            mqtt_disconnect();
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
        private void mqtt_disconnect()
        {
            if (client != null && client.IsConnected)
            {
                client.Disconnect();
            }
        }
        private void mqtt_connect(String url, String user, String password)
        {
            try
            {
                //创建客户端实例
                client = new MqttClient(url);

                client.MqttMsgPublishReceived += MqttMsgPublishReceived;
                client.ConnectionClosed += ConnectionClosed;
                client.MqttMsgUnsubscribed += MqttMsgUnsubscribed;
                client.MqttMsgSubscribed += MqttMsgSubscribed;
                client.MqttMsgPublished += MqttMsgPublished;

                byte code = client.Connect(Guid.NewGuid().ToString(), user, password);
                if (code != 0)
                {
                    Log("MQTT服务器连接失败:" + code);
                    return;
                }
                MQTTConnectInit(true);
                Log("MQTT服务器已连接");

                client.Subscribe(new String[] { "/testing" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

                String temp = "asdf";
                client.Publish("sensor/temp", Encoding.UTF8.GetBytes(temp));




                //client = new MqttClient(IPAddress.Parse(ip), Convert.ToInt32(port), false, null);

                // admin和password是之前在apache apollo中设置的用户名和密码
                //byte code = client.Connect("123123123","z","a2633063"); 
                //client.Connect(clientId, "admin", "password", false, 0x01, false, null, null, true, 60);
                //buttonLink.Enabled = false;
                //btnLose.Enabled = true;
                //textBoxLS.ForeColor = Color.LimeGreen;
                //textBoxLS.Text = "已连接";
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

            MQTTPublishReceived(e.Topic, System.Text.Encoding.Default.GetString(e.Message));
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




        #region mqtt接受数据处理函数(包含线程处理)
        private void MQTTPublishReceivedCallBack(String topic, String message)
        {
            System.Console.WriteLine("MQTT Received topic [" + topic + "] :" + message);

        }
        private delegate void MQTTPublishReceived_dg(String topic, String message);
        private void MQTTPublishReceived(String topic, String message)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MQTTPublishReceived_dg(MQTTPublishReceivedCallBack), new object[] { topic, message });

                }
                catch (Exception)
                {
                    //throw;
                }
            }
            else
            {
                MQTTPublishReceivedCallBack(topic, message);
            }
        }
        #endregion

        private void BtMQTTConfirm_Click(object sender, EventArgs e)
        {
            if (txtMQTTServer.TextLength < 1 || txtMQTTUser.TextLength < 1 || txtMQTTPassword.TextLength < 1)
            {
                MessageBox.Show("请确认MQTT服务填写正确!");
                return;
            }

            if (client != null && client.IsConnected)
                mqtt_disconnect();
            else
                mqtt_connect(txtMQTTServer.Text, txtMQTTUser.Text, txtMQTTPassword.Text);



        }


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
            Font nameFont = new Font(e.Font.FontFamily, 20);

            Rectangle newBounds = new Rectangle(e.Bounds.Location, e.Bounds.Size);

            // draw the name string
            e.Graphics.DrawString(device.name, nameFont, fontColor, newBounds.X + DEVICE_LIST_ITEM_HEIGHT, newBounds.Y);
            // calculate the new rectangle


            // draw the mac string
            e.Graphics.DrawString(device.mac, e.Font, fontColor, newBounds.X+ DEVICE_LIST_ITEM_HEIGHT+2, newBounds.Y+25);

            // draw the focus
            e.DrawFocusRectangle();
            

        }

        private void ListBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            //if (e.Index == 2)

            {

                e.ItemHeight = DEVICE_LIST_ITEM_HEIGHT;
            }
        }
    }
}
