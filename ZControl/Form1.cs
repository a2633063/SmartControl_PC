using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                //创建客户端实例
                client = new MqttClient("wiww.xyz");


                client.MqttMsgPublishReceived += client_recievedMessage;
                byte code = client.Connect(Guid.NewGuid().ToString(), "z", "2633063");



                client.Subscribe(new String[] { "/testing" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

                String temp ="asdf";
                client.Publish("sensor/temp", Encoding.UTF8.GetBytes(temp));


                client.Disconnect();

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

        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // access data bytes throug e.Message
        }

        static void client_recievedMessage(object sender, MqttMsgPublishEventArgs e)
        {
            // Handle message received
            var message = System.Text.Encoding.Default.GetString(e.Message);
            System.Console.WriteLine("Message received: " + message);
        }
    }
}
