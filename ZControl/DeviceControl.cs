using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ZControl.DeviceItem;

namespace ZControl
{
    public partial class DeviceControl : UserControl
    {

        public delegate void MsgPublishEventHandler(String topic,String message);
        public event MsgPublishEventHandler MsgPublishEvent;

        #region 属性
        private DeviceItem device;

        private Boolean autoCheck = true;

        Panel[] deviceTypeUIChoise = new Panel[(int)DEVICETYPE.TYPE_TOTAL];
        public DeviceItem Device
        {
            get { return device; }
            set
            {
                labelZTC1Power.Text = "----";
                labelZTC1TotalTime.Text = "";
                labelZDC1Power.Text = "----";
                labelZDC1Current.Text = "----";
                labelTitle.Text = "";
                labLock.Text = "";
                labelMac.Text = "";

                for (int i = 0; i < (int)DEVICETYPE.TYPE_TOTAL; i++)
                {
                    deviceTypeUIChoise[i].Dock = DockStyle.None;
                    deviceTypeUIChoise[i].Visible = false;
                }

                device = value;
                if (device == null) return;

                deviceTypeUIChoise[(int)device.type].Visible = true;

                switch (device.type)
                {
                    case DEVICETYPE.TYPE_TC1:
                        panelZTC1.Dock = DockStyle.Fill;
                        zTC1RefreshAll();
                        break;
                    case DEVICETYPE.TYPE_DC1:
                        panelZTC1.Dock = DockStyle.Fill;
                        zDC1RefreshAll();
                        break;
                }
            }
        }
        public bool AutoCheck
        {
            get { return autoCheck; }
            set { autoCheck = value; }
        }

        #endregion

        public DeviceControl()
        {
            InitializeComponent();

            deviceTypeUIChoise[0] = panelZTC1;
            deviceTypeUIChoise[1] = panelZTC1;
            deviceTypeUIChoise[2] = panelZDC1;
            deviceTypeUIChoise[3] = panelZTC1;
            deviceTypeUIChoise[4] = panelZTC1;

            foreach(Panel p in deviceTypeUIChoise)
            {
                p.Location = new Point(0, 0);
            }

            zTC1Init();
            zDC1Init();
        }




        #region 通用
        private void LabelMac_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(device.mac);
            MessageBox.Show("设备MAC地址已复制!");
        }


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
        #endregion


        #region zTC1部分
        PictureBox[] picZTC1SwitchPic = new PictureBox[6];
        Label[] labZTC1SwitchName = new Label[6];
        void zTC1Init()
        {
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
        public void zTC1RefreshAll()
        {
            zTC1RefreshName();
            zTC1RefreshMac();
            zTC1RefreshLock();
            zTC1RefreshPower();
            zTC1RefreshTotalTime();
            for (int i = 0; i < picZTC1SwitchPic.Count(); i++)
            {
                zTC1RefreshSwitch(i);
                zTC1RefreshSwitchName(i);
            }
        }

        public void zTC1RefreshSwitch(int x)
        {
            picZTC1SwitchPic[x].Image = ((DeviceItemZTC1)device).zTC1Switch[x] ? Properties.Resources.device_open : Properties.Resources.device_close;
            for(int i=0;i< picZTC1SwitchPic.Length; i++)
            {
                if(((DeviceItemZTC1)device).zTC1Switch[i])
                {
                    picZTC1SwitchAll.Image = Properties.Resources.device_open;
                    return;
                }
            }
            picZTC1SwitchAll.Image = Properties.Resources.device_close;
        }
        public void zTC1RefreshSwitchName(int x)
        {
            labZTC1SwitchName[x].Text = ((DeviceItemZTC1)device).zTC1SwitchName[x];
            labZTC1SwitchName[x].Left = picZTC1SwitchPic[x].Left + picZTC1SwitchPic[x].Width / 2 - labZTC1SwitchName[x].Width / 2;
        }
        public void zTC1RefreshTotalTime()
        {
            UInt32 time = ((DeviceItemZTC1)device).zTC1TotalTime;
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
        public void zTC1RefreshPower()
        {
            if (((DeviceItemZTC1)device).zTC1Power != null)
                labelZTC1Power.Text = ((DeviceItemZTC1)device).zTC1Power + "W";
        }

        public void zTC1RefreshName()
        {
            labelTitle.Text = device.name;
        }
        public void zTC1RefreshMac()
        {
            labelMac.Text = device.mac;
        }
        public void zTC1RefreshLock()
        {
            if (((DeviceItemZTC1)device).zTC1Lock)
            {
                labLock.Enabled = false;
                labLock.Text = "已激活"; }
            else {labLock.Text = "未激活";
                labLock.Enabled = true;
             }
        }
        private void PicZTC1Switch_Click(object sender, EventArgs e)
        {
            PictureBox zTC1SwitchPic = (PictureBox)sender;
            int index = (int)zTC1SwitchPic.Tag;
            if (MsgPublishEvent != null) MsgPublishEvent("device/ztc1/" + device.mac + "/set", "{\"mac\":\""+device.mac+"\",\"plug_"+ index+"\":{\"on\":"+ (((DeviceItemZTC1)device).zTC1Switch[index] ? "0":"1")+ "}}");
            if (autoCheck)
            {
                ((DeviceItemZTC1)device).zTC1Switch[index] = !((DeviceItemZTC1)device).zTC1Switch[index];
                zTC1RefreshSwitch(index);
            }
        }

        private void PicZTC1SwitchAll_Click(object sender, EventArgs e)
        {
            if (MsgPublishEvent == null) return;

            String message = "{\"mac\":\"" + device.mac + "\",\"plug_0\":{\"on\":1},\"plug_1\":{\"on\":1},\"plug_2\":{\"on\":1},\"plug_3\":{\"on\":1},\"plug_4\":{\"on\":1},\"plug_5\":{\"on\":1}}";
            bool b = true;
            for (int i = 0; i < picZTC1SwitchPic.Length; i++)
            {
                if (((DeviceItemZTC1)device).zTC1Switch[i])
                {
                    b = false;
                    message = "{\"mac\":\"" + device.mac + "\",\"plug_0\":{\"on\":0},\"plug_1\":{\"on\":0},\"plug_2\":{\"on\":0},\"plug_3\":{\"on\":0},\"plug_4\":{\"on\":0},\"plug_5\":{\"on\":0}}";
                    break;
                }
            }
            if (autoCheck)
            {
                picZTC1SwitchAll.Image = b ? Properties.Resources.device_open : Properties.Resources.device_close;
            }

            MsgPublishEvent("device/ztc1/" + device.mac + "/set", message);

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MsgPublishEvent != null) MsgPublishEvent("device/ztc1/" + device.mac + "/set", "{\"mac\": \"" + device.mac + "\",\"lock\":null,\"plug_0\" : {\"on\" : null,\"setting\":{\"name\":null}},\"plug_1\" : {\"on\" : null,\"setting\":{\"name\":null}},\"plug_2\" : {\"on\" : null,\"setting\":{\"name\":null}},\"plug_3\" : {\"on\" : null,\"setting\":{\"name\":null}},\"plug_4\" : {\"on\" : null,\"setting\":{\"name\":null}},\"plug_5\" : {\"on\" : null,\"setting\":{\"name\":null}}}");
        }


        #endregion

        #region zDC1部分
        PictureBox[] picZDC1SwitchPic = new PictureBox[4];
        Label[] labZDC1SwitchName = new Label[4];
        void zDC1Init()
        {
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
        public void zDC1RefreshAll()
        {
            zDC1RefreshName();
            zDC1RefreshMac();
            zDC1RefreshPower();
            zDC1RefreshTotalTime();
            for (int i = 0; i < picZDC1SwitchPic.Count(); i++)
            {
                zDC1RefreshSwitch(i);
                zDC1RefreshSwitchName(i);
            }
        }

        public void zDC1RefreshSwitch(int x)
        {
            picZDC1SwitchPic[x].Image = ((DeviceItemZDC1)device).zDC1Switch[x] ? Properties.Resources.device_open : Properties.Resources.device_close;
            for (int i = 0; i < picZDC1SwitchPic.Length; i++)
            {
                //if (((DeviceItemZDC1)device).zDC1Switch[i])
                //{
                //    //picZDC1SwitchAll.Image = Properties.Resources.device_open;
                //    return;
                //}
            }
            //picZDC1SwitchAll.Image = Properties.Resources.device_close;
        }
        public void zDC1RefreshSwitchName(int x)
        {
            labZDC1SwitchName[x].Text = ((DeviceItemZDC1)device).zDC1SwitchName[x];
            labZDC1SwitchName[x].Left = picZDC1SwitchPic[x].Left + picZDC1SwitchPic[x].Width / 2 - labZDC1SwitchName[x].Width / 2;
        }
        public void zDC1RefreshTotalTime()
        {
            UInt32 time = ((DeviceItemZDC1)device).zDC1TotalTime;
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

                labelZDC1TotalTime.Text = "已运行时间: " + str;
            }
        }
        public void zDC1RefreshPower()
        {
            if (((DeviceItemZDC1)device).zDC1Power != null)
                labelZDC1Power.Text = ((DeviceItemZDC1)device).zDC1Power + "W";
        }
        public void zDC1RefreshVoltage()
        {
            if (((DeviceItemZDC1)device).zDC1Power != null)
                labelZDC1Voltage.Text = ((DeviceItemZDC1)device).zDC1Voltage + "V";
        }
        public void zDC1RefreshCurrent()
        {
            if (((DeviceItemZDC1)device).zDC1Power != null)
                labelZDC1Current.Text = ((DeviceItemZDC1)device).zDC1Current + "A";
        }

        public void zDC1RefreshName()
        {
            labelTitle.Text = device.name;
        }
        public void zDC1RefreshMac()
        {
            labelMac.Text = device.mac;
        }

        private void PicZDC1Switch_Click(object sender, EventArgs e)
        {
            PictureBox zDC1SwitchPic = (PictureBox)sender;
            int index = (int)zDC1SwitchPic.Tag;
            if (MsgPublishEvent != null) MsgPublishEvent("device/zdc1/" + device.mac + "/set", "{\"mac\":\"" + device.mac + "\",\"plug_" + index + "\":{\"on\":" + (((DeviceItemZDC1)device).zDC1Switch[index] ? "0" : "1") + "}}");
            if (autoCheck)
            {
                ((DeviceItemZDC1)device).zDC1Switch[index] = !((DeviceItemZDC1)device).zDC1Switch[index];
                zDC1RefreshSwitch(index);
            }
        }


        private void RegetZDC1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MsgPublishEvent != null) MsgPublishEvent("device/zdc1/" + device.mac + "/set", "{\"mac\": \"" + device.mac + "\",\"lock\":null,\"plug_0\" : {\"on\" : null,\"setting\":{\"name\":null}},\"plug_1\" : {\"on\" : null,\"setting\":{\"name\":null}},\"plug_2\" : {\"on\" : null,\"setting\":{\"name\":null}},\"plug_3\" : {\"on\" : null,\"setting\":{\"name\":null}},\"plug_4\" : {\"on\" : null,\"setting\":{\"name\":null}},\"plug_5\" : {\"on\" : null,\"setting\":{\"name\":null}}}");
        }





        #endregion

    }
}
