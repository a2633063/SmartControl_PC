using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZControl
{
    public enum DEVICETYPE
    {
        TYPE_UNKNOWN = -1,
        TYPE_BUTTON_MATE = 0,
        TYPE_TC1,
        TYPE_DC1,
        TYPE_A1,
        TYPE_M1,
        TYPE_TOTAL,

    }
    public class DeviceItem
    {

        public DEVICETYPE type = DEVICETYPE.TYPE_UNKNOWN;


        public String name;
        public String mac;
        public String typeName;



        //#region zBUTTONMATE属性


        //#endregion

        //#region zTC1属性
        //UInt32 zTC1power;   //功率
        //UInt32 zTC1total_time;  //运行时间
        //Boolean[] zTC1Switch = new Boolean[6] { false, false, false, false, false, false }; //开关状态
        //#endregion

        //#region zDC1属性
        //UInt32 zDC1total_time;  //运行时间
        //UInt16 zDC1power;   //功率
        //UInt16 zDC1voltage; //电压
        //UInt16 zDC1current; //电流
        //Boolean[] zDC1Switch = new Boolean[4] { false, false, false, false};//开关状态
        //#endregion

        //#region zA1属性

        //#endregion

        //#region zM1属性

        //#endregion




        public DeviceItem(DEVICETYPE type, String name, String mac)
        {
            this.name = name;
            this.type = type;
            this.mac = mac;
        }





    }
}
