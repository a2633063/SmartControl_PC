using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZControl
{
    class DeviceItemZDC1 : DeviceItem
    {
        public String zDC1Power = null;   //功率
        public String zDC1Voltage = null;   //功率
        public String zDC1Current = null;   //电流
        public UInt32 zDC1TotalTime = 0;  //运行时间
        public Boolean[] zDC1Switch = new Boolean[4] { false, false, false, false }; //开关状态
        public String[] zDC1SwitchName = new String[4] { "总开关","插口1", "插口2", "插口3"}; //开关名称

        public DeviceItemZDC1( String name, String mac) : base(DEVICETYPE.TYPE_DC1,name,mac)
        {
           // this.name = name;
           // this.type = type;
            //this.mac = mac;
        }

    }
}
