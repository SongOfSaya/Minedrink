
using System;
using System.Collections.ObjectModel;
using UWPShopManagement.Helpers;
namespace UWPShopManagement.Models
{
    /// <summary>
    /// 不知道是否需要Observeable
    /// </summary>
    public class M_ArduinoMarkA : Observable
    {        
        private string _name;

        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        private int _id;
        public int ID
        {
            get { return _id; }
            set
            {
                Set(ref _id, value);
                Name = NameConverter(_id);
            }
        }
        private TimeSpan _mills;

        public TimeSpan Mills
        {
            get { return _mills; }
            set { Set(ref _mills, value); }
        }
        private string _ip;

        public string IP
        {
            get { return _ip; }
            set { Set(ref _ip, value); }
        }
        private string _prot;

        public string Port
        {
            get { return _prot; }
            set { Set(ref _prot, value); }
        }

        private int _mode;
        public int Mode
        {
            get { return _mode; }
            set
            {
                Set(ref _mode, value);
                ModeName = ModeConverter(_mode);
            }
        }
        private string _modeName;

        public string ModeName
        {
            get { return _modeName; }
            set { Set(ref _modeName, value); }
        }
        private int _markColor;

        public int MarkColor
        {
            get { return _markColor; }
            set { Set(ref _markColor, value); }
        }
        private bool _isConnect;

        public bool IsConnect
        {
            get { return _isConnect; }
            set { Set(ref _isConnect, value); }
        }
        //此Arduino是否在线
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
