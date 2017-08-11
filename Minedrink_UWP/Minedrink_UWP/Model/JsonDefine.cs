using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minedrink_UWP.Model
{
    /// <summary>
    /// 定义了用于通信的标准json格式,以及相关字符常量
    /// 变量名统一1~3大写字符,避免过长增加传输压力
    /// </summary>
    public class JsonDefine
    {
        //Arduino发给SMS的初始化信息 
        //无\格式:{"AID":"M01","MIS":1234567,"MOD":4,"CO":12,"SS":[{"SID":"W01","OFF":134,"GV":1,"DT":41,"SCK":43},{"SID":"W02","OFF":12,"GV":44,"DT":1,"SCK":43}]}
        public const string AllInfoSampleJson = "{\"AID\":\"M01\",\"MIS\":1234567,\"MOD\":4,\"CO\":12,\"SS\":[{\"SID\":\"W01\",\"OFF\":134,\"GV\":1,\"DT\":41,\"SCK\":43},{\"SID\":\"W02\",\"OFF\":12,\"GV\":44,\"DT\":1,\"SCK\":43}]}";
        //Arduino周期性发给SMS的json模板 
        //无\格式:{"ID":10, "Mills" : 1243, "Mode" : 1, "Sensors" : [{"ID":1085, "Result" : 123.44}, { "ID":1086,"Result" : 1234.4 }]}
        public const string UpdateSampleJson = "{\"AID\":10,\"Mills\":1243, \"Mode\":1,\"Sensors\":[{\"ID\":1085,\"Result\":123.44},{\"ID\":1086,\"Result\":1234.4}]}";
        //Arduino的ID
        public const string AID = "AID";
        //Arduino已运行时间
        public const string Mills = "MIS";
        //Arduino的运行模式
        public const string Mode = "MOD";
        //Arduino的传感器数组
        public const string SenSors = "SS";
        //传感器的ID
        public const string SID = "SID";
        //传感器读数
        public const string Result = "RES";
        //传感器DT_PIN口
        public const string DT = "DT";
        //传感器SCK_PIN口
        public const string SCK = "SCK";
        //重量传感器的偏移量
        public const string Offset = "OFF";
        //重量传感器的GapValue(应变系数)
        public const string GapValue = "GV";
    }
}
