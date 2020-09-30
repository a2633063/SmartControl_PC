using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using ZControl.FormDeviceClass;
using static ZControl.FormDeviceClass.FormItem;

namespace ZControl
{
    public partial class Form1 : Form
    {
        private MqttClient mqttClient;
        private Boolean reConnect = false;
        UdpClient udpClient;

        List<FormItem> deviceList = new List<FormItem>();

        public Form1()
        {

            InitializeComponent();
            //labVersion.Text = "软件版本: v" + System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;
            labVersion.Text = "软件版本: v" + System.Diagnostics.FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).FileVersion;

            //labVersion.Text = "软件版本 v0.2.0";
            this.MinimumSize = this.Size;

            #region 读取设备

            try
            {
                Json2Device(Properties.Settings.Default.Device);
            }
            catch (Exception)
            {
                listBox1.Items.Clear();
                //throw;
            }
            #endregion


            if (listBox1.Items.Count < 1)
            {
                //Received(null, @"{""name"":""zTC1_f003"",""mac"":""d0bae462f002"",""type"":1,""type_name"":""zTC1"",""ip"":""192.168.0.139""}");
                //Received(null, @"{""name"":""zTC1_d0bae4642298"",""mac"":""d0bae4642298"",""type"":1,""type_name"":""zTC1"",""ip"":""192.168.0.139""}");
                //Received(null, @"{""name"":""zM1"",""mac"":""b0f8932234f4"",""type"":4,""type_name"":""zTC1"",""ip"":""192.168.0.139""}");
                //Received(null, @"{""name"":""zDC1_35eb"",""mac"":""84f3eb5635eb"",""type"":2,""type_name"":""zTC1"",""ip"":""192.168.0.139""}");
                //Received(null, @"{""name"":""zA1"",""mac"":""b0f8932bc47a"",""type"":3,""type_name"":""zTC1"",""ip"":""192.168.0.139""}");
                //Received(null, @"{""name"":""zMOPS"",""mac"":""6001943fe3df"",""type"":7,""type_name"":""zMOPS"",""ip"":""192.168.0.2""}");
                Received(null, @"{""name"":""演示设备,请手动删除"",""mac"":""000000000000"",""type"":1,""type_name"":""zTC1"",""ip"":""192.168.0.2""}");
            }


            #region 获取本机所有ip地址
            string hostName = Dns.GetHostName();                    //获取主机名称  
            IPAddress[] addresses = Dns.GetHostAddresses(hostName); //解析主机IP地址  

            List<string> IPList = new List<string>();


            for (int i = 0; i < addresses.Length; i++)
            {
                if (addresses[i].AddressFamily.ToString().Equals("InterNetwork"))
                    CboIP.Items.Add(addresses[i].ToString());
            }
            CboIP.Items.Add("127.0.0.1");
            CboIP.Items.Add("255.255.255.255");

            if (CboIP.Items.Contains(Properties.Settings.Default.IP))
                CboIP.Text = Properties.Settings.Default.IP;

            if (CboIP.Text.Length < 1)
                CboIP.Text = "255.255.255.255";

            CboIP.SelectedIndexChanged += CboIP_SelectedIndexChanged;


            #endregion

            //listBox1.SelectedIndex = 0;
            //deviceControl1.Device = (DeviceItem)listBox1.SelectedItem;
            //deviceControl1.MsgPublishEvent += send;
            if (txtMQTTServer.TextLength > 0 && txtMQTTUser.TextLength > 0 && txtMQTTPassword.TextLength > 0)
            {
                mqttConnect(txtMQTTServer.Text, (int)numMQTTPort.Value, txtMQTTUser.Text, txtMQTTPassword.Text);
            }
            udpConnect();


            int listSeclet = Properties.Settings.Default.Seclect;
            if (listBox1.Items.Count > listSeclet && listSeclet >= 0)
            {
                listBox1.SelectedIndex = listSeclet;
            }
            else if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
            }
            else listBox1.SelectedIndex = -1;

            #region 设置鼠标悬停提示
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 0;
            toolTip1.ReshowDelay = 0;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.CboIP, "若无法通信,请选择与设备同网段的ip地址");
            #endregion


            checkUpdate();
        }

        private void send(string topic, string message)
        {
            if (mqttClient == null || !mqttClient.IsConnected || topic == null)
            {
                if (udpClient != null)
                {
                    IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 10182);
                    byte[] data = Encoding.Default.GetBytes(message);
                    udpClient.Send(data, data.Length, ipendpoint);
                }
                //UdpClient udpclient = new UdpClient();
                //IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 10182);

                //byte[] data = Encoding.Default.GetBytes(message);
                //udpclient.Send(data, data.Length, ipendpoint);
                //udpclient.Close();
            }
            else
            {
                mqttClient.Publish(topic, Encoding.UTF8.GetBytes(message));
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (udpClient != null) { udpClient.Close(); udpClient = null; }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            mqttDisconnect();

            string json = GetDeviceJsonString();
            Properties.Settings.Default.Device = json;
            Properties.Settings.Default.Seclect = listBox1.SelectedIndex;
            Properties.Settings.Default.IP = CboIP.Text;
            Properties.Settings.Default.Save();
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width > 608 || this.Height > 490)
            {
                labMoreFunction.Text = "------<<<------";
            }
            else
            {
                labMoreFunction.Text = "------>>>------";
            }
        }
        #region 多线程处理   更新Log显示内容/读取ip当前选择项目
        #region 更新Log显示内容
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
        #region 读取ComboBox当前选择项目
        public delegate string commbdelegate(ComboBox cb);
        public string commb(ComboBox cb)
        {
            try
            {
                if (cb.InvokeRequired)
                {
                    commbdelegate dt = new commbdelegate(commb);
                    IAsyncResult ia = cb.BeginInvoke(dt, new object[] { cb });
                    return (string)cb.EndInvoke(ia);  //这里需要利用EndInvoke来获取返回值
                }
                else
                {
                    return cb.Text;
                }
            }
            catch (Exception)
            {
                return null;
                //throw;
            }
        }

        #endregion
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

                //mqttClient.Subscribe(new String[] { "device/ztc1/+/sensor" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                //mqttClient.Subscribe(new String[] { "device/ztc1/+/state" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });


                //mqttClient.Subscribe(new String[] { "device/zdc1/+/sensor" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                //mqttClient.Subscribe(new String[] { "device/zdc1/+/state" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

                foreach (FormItem d in listBox1.Items)
                {
                    String[] topic = d.GetRecvMqttTopic();
                    if (topic != null)
                    {
                        byte[] qos = new byte[topic.Length];
                        for (int i = 0; i < qos.Length; i++) qos[i] = MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE;
                        mqttClient.Subscribe(topic, qos);
                        //                        Log.d(Tag, "subscribe:" + d.getMqttStateTopic());
                    }
                }

                foreach (FormItem d in listBox1.Items)
                {
                    d.RefreshStatus();
                }

            }
            catch (Exception)
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
            Log("MQTT服务器已断开,当前使用局域网udp通信");
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

            IPEndPoint remote = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                if (udpClient == null)
                {
                    String ip = commb(CboIP);
                    if (ip == null || ip == "") continue;
                    if (ip.Equals("255.255.255.255")) ip = "0.0.0.0";
                    IPEndPoint local = new IPEndPoint(IPAddress.Parse(ip), 10181);
                    udpClient = new UdpClient(local);
                    //udpClient = new UdpClient(10181);
                }

                try
                {
                    byte[] recivcedata = udpClient.Receive(ref remote);

                    string strMsg = Encoding.UTF8.GetString(recivcedata, 0, recivcedata.Length);
                    //System.Console.WriteLine("udp:"+string.Format("来自{0}：{1}", remote, strMsg));
                    Received(null, strMsg);
                }
                catch (Exception e)
                {
                    //break;
                }

            }
        }

        #endregion
        #region MQTT/UDP接受数据处理函数(包含线程处理)
        private void PublishReceivedCallBack(String topic, String message)
        {
            Console.WriteLine("Received topic [" + topic + "] :" + message);
            txtLogAll.AppendText("[" + DateTime.Now.ToLongTimeString().ToString() + "][" + topic + "] :" + message + "\r\n");
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
                        if (jObject["mac"].ToString().Equals(((FormItem)listBox1.Items[index]).GetMac()))
                        {
                            break;
                        }
                    }
                    if (index < listBox1.Items.Count) return;   //设备重复,不增加
                    switch ((DEVICETYPE)(int)jObject["type"])
                    {
                        case DEVICETYPE.TYPE_TC1:
                            listBox1.Items.Insert(0, new FormZTC1(jObject["name"].ToString(), jObject["mac"].ToString()));
                            break;
                        case DEVICETYPE.TYPE_DC1:
                            listBox1.Items.Insert(0, new FormZDC1(jObject["name"].ToString(), jObject["mac"].ToString()));
                            break;
                        case DEVICETYPE.TYPE_A1:
                            listBox1.Items.Insert(0, new FormZA1(jObject["name"].ToString(), jObject["mac"].ToString()));
                            break;
                        case DEVICETYPE.TYPE_M1:
                            listBox1.Items.Insert(0, new FormZM1(jObject["name"].ToString(), jObject["mac"].ToString()));
                            break;
                        case DEVICETYPE.TYPE_S7:
                            listBox1.Items.Insert(0, new FormZS7(jObject["name"].ToString(), jObject["mac"].ToString()));
                            break;
                        case DEVICETYPE.TYPE_CLOCK:
                            listBox1.Items.Insert(0, new FormZClock(jObject["name"].ToString(), jObject["mac"].ToString()));
                            break;
                        case DEVICETYPE.TYPE_MOPS:
                            listBox1.Items.Insert(0, new FormZMOPS(jObject["name"].ToString(), jObject["mac"].ToString()));
                            break;
                        default:
                            return;
                    }

                    FormItem f = (FormItem)listBox1.Items[0];
                    //f.MdiParent = this;
                    f.TopLevel = false;
                    // f.Dock = DockStyle.Fill;
                    f.FormBorderStyle = FormBorderStyle.None;
                    f.MsgPublishEvent += send;
                    panelDeviceControl.Controls.Add(f);
                    f.Show();
                    if (mqttClient != null && mqttClient.IsConnected)
                    {
                        String[] t = f.GetRecvMqttTopic();
                        if (t != null)
                        {
                            byte[] qos = new byte[t.Length];
                            for (int i = 0; i < qos.Length; i++) qos[i] = MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE;
                            mqttClient.Subscribe(t, qos);

                            //Log.d(Tag, "subscribe:" + d.getMqttStateTopic());
                        }
                    }
                    f.RefreshStatus();
                    return;
                }


                String reMac = jObject["mac"].ToString();


                for (index = 0; index < listBox1.Items.Count; index++)
                {
                    //if(index)
                    if (reMac.Equals(((FormItem)listBox1.Items[index]).GetMac()))
                    {
                        System.Console.WriteLine("设备:" + index);
                        break;
                    }
                }

                if (index >= listBox1.Items.Count) return;

                if (jObject.Property("name") != null)
                {
                    ((FormItem)listBox1.Items[index]).SetName(jObject["name"].ToString());
                }
                ((FormItem)listBox1.Items[index]).Received(topic, message);

            }
            catch (Exception e)
            {

                #region 处理设备离线在线数据
                if (topic != null)
                {
                    Regex regex = new Regex(@".*/([1234567890abcdef]{12})/availability");
                    Match match = regex.Match(topic);
                    if (match.Success && match.Groups.Count == 2)
                    {
                        for (index = 0; index < listBox1.Items.Count; index++)
                        {
                            //if(index)
                            if (match.Groups[1].ToString().Equals(((FormItem)listBox1.Items[index]).GetMac()))
                            {
                                ((FormItem)listBox1.Items[index]).SetOnline(message.Equals("1"));
                                //((FormItem)listBox1.Items[index]).Received(topic, message);
                                break;
                            }
                        }
                    }
                }
                #endregion


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

        #region 子函数
        private string GetDeviceJsonString()
        {
            JArray jArray = new JArray();
            JObject obj = new JObject();
            foreach (FormItem d in listBox1.Items)
            {
                if (d.GetMac().Equals("000000000000")) continue;
                JObject objItem = new JObject();
                objItem["mac"] = d.GetMac();
                objItem["name"] = d.GetName();
                objItem["type"] = (int)d.GetTypeID();
                objItem["type_name"] = d.GetTypeName();
                jArray.Add(objItem);
            }
            obj["device"] = jArray;
            string json = obj.ToString();
            Console.WriteLine(json);
            return json;
        }
        private void Json2Device(string s)
        {

            string json = Properties.Settings.Default.Device;
            JObject jsonObject = JObject.Parse(json);
            JArray array = (JArray)jsonObject["device"];
            for (int i = array.Count; i > 0; i--)
            {
                JObject jObject = (JObject)array[i - 1];
                Console.WriteLine(jObject.ToString());
                Received(null, jObject.ToString());
            }

        }
        #endregion
        #region 控件事件
        #region 设置devicelist Item自定义界面
        const int DEVICE_LIST_ITEM_HEIGHT = 40;
        private void ListBox1_DrawItem(object sender, DrawItemEventArgs e)
        {


            if (e.Index == -1)
                return;
            e.DrawBackground();

            e.DrawFocusRectangle();
            // prefixes are drawed bold

            FormItem device = (FormItem)((ListBox)sender).Items[e.Index];


            //draw the ICON
            Rectangle rectangle = new Rectangle(e.Bounds.Location, new Size(DEVICE_LIST_ITEM_HEIGHT, DEVICE_LIST_ITEM_HEIGHT));
            e.Graphics.DrawImage(device.GetTypeIcon(), rectangle);

            //draw the txt
            Brush fontColor = new SolidBrush(Color.Black);
            Font nameFont = new Font(e.Font.FontFamily, 12, FontStyle.Bold);

            Rectangle newBounds = new Rectangle(e.Bounds.Location, e.Bounds.Size);

            // draw the name string
            e.Graphics.DrawString(device.GetName(), nameFont, fontColor, newBounds.X + DEVICE_LIST_ITEM_HEIGHT, newBounds.Y + 5);
            // calculate the new rectangle


            // draw the mac string
            e.Graphics.DrawString(device.GetMac(), e.Font, fontColor, newBounds.X + DEVICE_LIST_ITEM_HEIGHT + 2, newBounds.Y + 26);

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
            if (((ListBox)sender).Items.Count < 1) return;
            if (((ListBox)sender).SelectedIndex == -1) ((ListBox)sender).SelectedIndex = 0;
            FormItem deviceForm = (FormItem)((ListBox)sender).SelectedItem;
            deviceForm.BringToFront();
        }

        private void BtnDeviceListDel_Click(object sender, EventArgs e)
        {
            FormItem d = (FormItem)listBox1.SelectedItem;
            if (d == null) return;
            if (MessageBox.Show("删除设备:\n" + d.GetName() + " (" + d.GetMac() + ")", "删除设备", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.OK)
            {
                int index = listBox1.SelectedIndex;
                if (listBox1.Items.Count == 1) index = -1;
                else if (index > 0) index--;
                d.Close();
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
            FormItem d = (FormItem)listBox1.SelectedItem;
            if (d == null) return;

            if (mqttClient == null || !mqttClient.IsConnected)
            {
                MessageBox.Show("MQTT服务器未连接成功,请先确认连接成后,再同步mqtt服务器", "MQTT未连接");
                return;
            }

            JArray jArray = new JArray();
            JObject obj = new JObject();
            obj["mac"] = d.GetMac();

            JObject objItem = new JObject();
            objItem["mqtt_uri"] = txtMQTTServer.Text;
            objItem["mqtt_port"] = (int)numMQTTPort.Value;
            objItem["mqtt_user"] = txtMQTTUser.Text;
            objItem["mqtt_password"] = txtMQTTPassword.Text;


            obj["setting"] = objItem;
            string json = obj.ToString();

            send(null, json);
        }

        private void CboIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (udpClient != null) { udpClient.Close(); udpClient = null; }
        }

        private void labMoreFunction_Click(object sender, EventArgs e)
        {
            if (this.Width == 608 && this.Height == 490)
            {
                //labMoreFunction.Text = "------<<<------";
                this.Width = 608 + 310;
                this.Height = 490;
            }
            else
            {
                //labMoreFunction.Text = "------>>>------";
                this.Width = 608;
                this.Height = 490;
            }
        }


        private void btnDeviceExport_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(GetDeviceJsonString());
            MessageBox.Show("设备导出至剪贴板成功!");
        }

        private void btnDeviceImport_Click(object sender, EventArgs e)
        {
            FormDialogDeviceImport f = new FormDialogDeviceImport();
            string s = f.ShowDialog();
            if (s != null)
            {
                // MessageBox.Show(s);
                Json2Device(s);
            }

        }
        #endregion

        #region 检查软件更新
        private string getWebHtml(string url)
        {
            // 获取网页源代码
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //if (cbProxy.Checked)
            //{
            //    var cre = new NetworkCredential(ProxyID.Text, ProxyPW.Text);
            //    var proxy = new WebProxy(ProxyUrl.Text, Convert.ToInt32(ProxyPort.Value)) { Credentials = cre };
            //    request.Proxy = proxy;
            //}
            WebResponse response = request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(resStream);
            return sr.ReadToEnd();


        }
        private SynchronizationContext mainThreadSynContext;

        private void checkUpdate()
        {
            mainThreadSynContext = SynchronizationContext.Current;
            Thread mythread = new Thread(ThreadMain);
            mythread.Start(labVersion.Text.Replace("软件版本: ", ""));
        }
        class OTAInfo
        {
            public String tag_name = null; //版本名称
            public String message = null;  //更新内容
            public String title = null;    //更新内容标题
            public String url = null;     //固件下载地址
            public String created_at = null;     //ota日期
        }
        OTAInfo versionInfo = null;
        private void OnConnected(object state)//由于是主线程的同步对象Post调用，这个是在主线程中执行的
        {
            if (state != null)
            {
                toolTip1.SetToolTip(this.labVersion, "检测到新版本,点击更新");
                versionInfo = (OTAInfo)state;

                labVersion.Text = labVersion.Text + "(×)";
                labVersion.ForeColor = Color.FromArgb(0, 0, 255);
                labVersion.Cursor = Cursors.Hand;
                Font s = new Font(this.labVersion.Font.FontFamily, this.labVersion.Font.Size, FontStyle.Underline);
                labVersion.Font = s;
                labVersion.Click += LabVersion_Click;

            }
            else
            {
                labVersion.Cursor = Cursors.Default;
                toolTip1.SetToolTip(this.labVersion, "已是最新版本");
                labVersion.Text = labVersion.Text + "(√)";
            }

        }

        private void LabVersion_Click(object sender, EventArgs e)
        {
            if (versionInfo == null) 
            {
                System.Diagnostics.Process.Start("https://github.com/a2633063/SmartControl_PC/releases/latest");
                return; 
            }
            DialogResult res = MessageBox.Show("更新内容:\r\n" + versionInfo.message + "\r\n\r\n更新时间:" + versionInfo.created_at + "\r\n\r\n点击确认打开浏览器开始下载文件", "有新版本:" + versionInfo.tag_name, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(versionInfo.url);
            }
        }

        private void OnConnectedFail(object state)//由于是主线程的同步对象Post调用，这个是在主线程中执行的
        {
            //labVersion.Text = state.ToString();


            toolTip1.SetToolTip(this.labVersion, "检测新版本失败,请点击确认是否有新版本更新");
            versionInfo = null;

            labVersion.Text = labVersion.Text + "(×)";
            labVersion.ForeColor = Color.FromArgb(0, 0, 255);
            labVersion.Cursor = Cursors.Hand;
            Font s = new Font(this.labVersion.Font.FontFamily, this.labVersion.Font.Size, FontStyle.Underline);
            labVersion.Font = s;
            labVersion.Click += LabVersion_Click;



            //这里就回到了主线程里面了
            //做一些事情

        }
        private void ThreadMain(object v)
        {
            OTAInfo otaInfo = new OTAInfo();
            try
            {
                String JsonStr = getWebHtml("https://gitee.com/api/v5/repos/a2633063/SmartControl_PC/releases/latest");
                if (JsonStr == null || JsonStr.Length < 3)
                    throw new Exception("获取最新版本信息失败");

                //Console.WriteLine(s);
                JObject obj = JObject.Parse(JsonStr);

                otaInfo = new OTAInfo();
                otaInfo.title = obj["name"].ToString();
                otaInfo.message = obj["body"].ToString();
                otaInfo.tag_name = obj["tag_name"].ToString();
                otaInfo.created_at = obj["created_at"].ToString();

                String tag_name_old = v.ToString();
                if (tag_name_old.Equals(otaInfo.tag_name))
                {
                    Console.WriteLine("已经是最新版本");
                    mainThreadSynContext.Post(new SendOrPostCallback(OnConnected), null);//通知主线程
                    return;
                }


                // Toast.makeText(getActivity(), "已是最新版本", Toast.LENGTH_SHORT).show();
                Console.WriteLine("当前版本:" + tag_name_old + ",发布版本:" + otaInfo.tag_name);
                bool show_ota = true;
                String[] version_new = otaInfo.tag_name.Replace("v", "").Split('.');
                String[] version_old = tag_name_old.Replace("v", "").Split('.');
                #region 判断当前是否是更新版本
                for (int i = 0; i < version_new.Length && i < version_old.Length; i++)
                {
                    try
                    {
                        int a = Convert.ToInt32(version_new[i]);
                        int b = Convert.ToInt32(version_old[i]);
                        if (b < a) break;
                        else if (b > a)
                        {
                            show_ota = false;
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        //e.printStackTrace();
                    }
                }

                if (!show_ota)
                {
                    //Toast.makeText(MainActivity.this, "当前版本暂时未发布，测试中\n当前版本:" + tag_name_old + "\n发布版本:" + tag_name, Toast.LENGTH_LONG).show();
                    mainThreadSynContext.Post(new SendOrPostCallback(OnConnected), null);//通知主线程
                    return;
                }
                #endregion

                JsonStr = getWebHtml("https://gitee.com/api/v5/repos/a2633063/Release/releases/tags/zControl_PC");
                obj = JObject.Parse(JsonStr);

                if (obj["name"].ToString().Equals("zA1发布地址_" + otaInfo.tag_name))
                {
                    String otauriAll = obj["body"].ToString();
                    otaInfo.url = otauriAll.Trim();
                    mainThreadSynContext.Post(new SendOrPostCallback(OnConnected), otaInfo);//通知主线程
                }
                else
                    throw new Exception("获取固件下载地址获取失败");



            }
            catch (Exception e)
            {
                mainThreadSynContext.Post(new SendOrPostCallback(OnConnectedFail), e.Message);//通知主线程
                //throw;
            }
        }

        #endregion


    }
}
