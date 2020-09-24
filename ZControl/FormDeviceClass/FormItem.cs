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
    public partial class FormItem : Form
    {
        public delegate void MsgPublishEventHandler(String topic, String message);
        public event MsgPublishEventHandler MsgPublishEvent;

        bool online = false;
        DEVICETYPE type = DEVICETYPE.TYPE_UNKNOWN;

        public enum DEVICETYPE
        {
            TYPE_UNKNOWN = -1,
            TYPE_BUTTON_MATE = 0,
            TYPE_TC1,
            TYPE_DC1,
            TYPE_A1,
            TYPE_M1,
            TYPE_S7,
            TYPE_CLOCK,
            TYPE_MOPS,
            TYPE_RGBW,
            TYPE_TOTAL,

        }
        public static String[] TypeName = new String[]{
            "按键伴侣",//0
            "智能排插zTC1",//1
            "智能排插zDC1",   //2
            "空气净化器zA1", //3
            "空气检测仪zM1", //4
            "体重秤zS7/zS7pe",   //5
            "时钟",    //6
            "zMOPS插座",   //7
            "zRGBW灯",   //8
        };

        public static Image[] Tyep_Icon = new Image[]{
            Properties.Resources.device_icon_ongoing,
            Properties.Resources.device_icon_diy,
            Properties.Resources.device_icon_ztc1,
            Properties.Resources.device_icon_zdc1,
            Properties.Resources.device_icon_za1,
            Properties.Resources.device_icon_zm1,
            Properties.Resources.device_icon_zs7,
            Properties.Resources.device_icon_zclock,
            Properties.Resources.device_icon_zmops,
            Properties.Resources.device_icon_ongoing,
            Properties.Resources.device_icon_ongoing,

        };
        public FormItem()
        {
            InitializeComponent();
        }

        public FormItem(DEVICETYPE type, String name, String mac)
        {
            InitializeComponent();
            this.type = type;
            labelTitle.Text = name;
            labelMac.Text = mac;
        }
        private void FormItem_Load(object sender, EventArgs e)
        {
            var toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;

            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.labelMac, @"设备mac,双击复制");
            toolTip1.SetToolTip(this.labelTitle, @"设备名称,双击复制");
        }
        #region gitter and setter
        public DEVICETYPE GetTypeID()
        {
            return type;
        }
        public String GetTypeName()
        {
            return TypeName[(int)type];
        }
        public Image GetTypeIcon()
        {
            return Tyep_Icon[(int)type+1];
        }
        public String GetName()
        {
            return labelTitle.Text;
        }

        public void SetName(String name)
        {
            labelTitle.Text = name;
        }

        public String GetMac()
        {
            return labelMac.Text;
        }

        public virtual void SetOnline(bool online)
        {
            this.online = online;
        }
        public virtual bool isOnline()
        {
            return online;
        }

        #endregion

        public virtual String[] GetRecvMqttTopic()
        {
            return null;
        }
        public virtual void RefreshStatus()
        {
        }
        public virtual void Received(String topic, String message)
        {
        }
        public void Send(String topic, String message)
        {
            if (MsgPublishEvent != null) MsgPublishEvent(topic, message);
        }

        private void labelTitle_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(GetName());
            MessageBox.Show("已复制设备名称");
        }

        private void labelMac_DoubleClick(object sender, EventArgs e)
        {

            Clipboard.SetText(GetMac());
            MessageBox.Show("已复制设备mac");
        }


    }
}
