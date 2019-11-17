using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZControl
{
    class DeviceItemZTC1 : DeviceItem
    {
        public String zTC1Power=null;   //功率
        public UInt32 zTC1TotalTime;  //运行时间
        public Boolean[] zTC1Switch = new Boolean[6] { false, false, false, false, false, false }; //开关状态
        public String[] zTC1SwitchName = new String[6] {"插口1", "插口2", "插口3", "插口4", "插口5", "插口6" }; //开关名称
        public bool zTC1Lock = false;   //锁定状态

        public DeviceItemZTC1( String name, String mac) : base(DEVICETYPE.TYPE_TC1,name,mac)
        {
           // this.name = name;
           // this.type = type;
            //this.mac = mac;
        }
    }
}
