
using System;
using System.Collections.ObjectModel;

namespace UWPShopManagement.Models
{
    /// <summary>
    /// 不知道是否需要Observeable
    /// </summary>
    public class M_ArduinoMarkA
    {
        public string Name { get; set; }
        private int _id;
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                Name = NameConverter(_id);
            }
        }
        public TimeSpan Mills { get; set; }
        public string IP { get; set; }
        public string Port { get; set; }
        private int _mode;
        public int Mode
        {
            get { return _mode; }
            set
            {
                _mode = value;
                ModeName = ModeConverter(_mode);
            }
        }
        public string ModeName { get; set; }
        public int MarkColor { get; set; }
        //此Arduino是否在线
        public bool IsConnect { get; set; }

        public ObservableCollection<M_WeightSensor> SensorCollection { get; set; }
        public static string NameConverter(int ID)
        {
            string result;
            switch (ID)
            {
                case 1001:
                    result = "主料区#1001";
                    break;
                case 1002:
                    result = "辅料区#1002";
                    break;
                default:
                    result = "未定义名称#" + ID.ToString();
                    break;
            }
            return result;
        }
        public static TimeSpan MillsConverter(long mills)
        {
            DateTime now = DateTime.Now;
            int second = 0;
            second = (int)(mills / 1000);
            TimeSpan pastTime = new TimeSpan(0, 0, second);
            return pastTime;
        }
        public static string ModeConverter(int mode)
        {
            string modeStr;
            switch (mode)
            {
                case 1:
                    modeStr = "称重模式#1";
                    break;
                case 2:
                    modeStr = "闲置模式#2";
                    break;
                default:
                    modeStr = "未定义模式#" + mode.ToString();
                    break;
            }
            return modeStr;
        }
    }

}
