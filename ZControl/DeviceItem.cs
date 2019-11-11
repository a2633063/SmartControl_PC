using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZControl
{
    class DeviceItem
    {

        public int type=-1;
        public String name;
        public String mac;

        public DeviceItem(int type, String name, String mac)
        {
            this.name = name;
            this.type = type;
            this.mac = mac;
        }





    }
}
