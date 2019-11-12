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

        #region 属性
        private DeviceItem device;
        private String name = null;
        private String mac = null;

        private Boolean autoCheck = true;

        Panel[] deviceTypeUIChoise = new Panel[(int)DEVICETYPE.TYPE_TOTAL];
        public DeviceItem Device
        {
            get { return device; }
            set
            {
                for (int i = 0; i < (int)DEVICETYPE.TYPE_TOTAL; i++)
                    deviceTypeUIChoise[i].Visible = false;

                device = value;
                if (device == null) return;

                deviceTypeUIChoise[(int)device.type].Visible = true;

                switch (device.type)
                {
                    case DEVICETYPE.TYPE_TC1:
                        zTC1Refresh();
                        break;
                }
            }
        }
        public bool AutoCheck
        {
            get { return autoCheck; }
            set { autoCheck = value; }
        }

        public String DeviceName
        {
            get { return name; }
            set
            {
                name = value;
                labelTitle.Text = name;
            }
        }

        public String DeviceMac
        {
            get { return mac; }
            set
            {
                mac = value;
                labelMac.Text = mac;
            }
        }

        #endregion

        public DeviceControl()
        {
            InitializeComponent();

            deviceTypeUIChoise[0] = panelZTC1;
            deviceTypeUIChoise[1] = panelZTC1;
            deviceTypeUIChoise[2] = panelZTC1;
            deviceTypeUIChoise[3] = panelZTC1;
            deviceTypeUIChoise[4] = panelZTC1;
            zTC1Init();
        }




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
            }
        }
        public void zTC1Refresh()
        {
            this.DeviceName = device.name;
            this.DeviceMac = device.mac;
            zTC1Power();
            zTC1TotalTime();
            for (int i = 0; i < picZTC1SwitchPic.Count(); i++)
            {
                zTC1Switch(i);
                zTC1SwitchName(i);
            }
        }

        public void zTC1Switch(int x)
        {
            picZTC1SwitchPic[x].Image = ((DeviceItemZTC1)device).zTC1Switch[x] ? Properties.Resources.device_open : Properties.Resources.device_close; ;
        }
        public void zTC1SwitchName(int x)
        {
            labZTC1SwitchName[x].Text = ((DeviceItemZTC1)device).zTC1SwitchName[x];
        }
        public void zTC1TotalTime()
        {
            if (((DeviceItemZTC1)device).zTC1TotalTime > 0)
                labelZTC1TotalTime.Text = "已运行时间:" + ((DeviceItemZTC1)device).zTC1TotalTime;
        }
        public void zTC1Power()
        {
            labelZTC1Power.Text = ((DeviceItemZTC1)device).zTC1Power + "W";
        }
        private void PicZTC1Switch_Click(object sender, EventArgs e)
        {
            PictureBox zTC1SwitchPic = (PictureBox)sender;
            int index = (int)zTC1SwitchPic.Tag;
            if (autoCheck)
            {
                ((DeviceItemZTC1)device).zTC1Switch[index] = !((DeviceItemZTC1)device).zTC1Switch[index];
                zTC1Switch(index);
            }
        }
        #endregion
    }
}
