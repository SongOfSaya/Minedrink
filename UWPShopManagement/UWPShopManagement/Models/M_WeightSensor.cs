using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UWPShopManagement.Models
{
    public class M_WeightSensor : M_SensorBase
    {
        private int _pin_dt;
        //DT口数值, 传感器相对于Arduino的唯一标识符
        public int PIN_DT
        {
            get { return _pin_dt; }
            set { Set(ref _pin_dt, value); }
        }
        private string _name;
        //传感器名称
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }
        private int _pin_sck;
        //Pin口
        public int PIN_SCK
        {
            get { return _pin_sck; }
            set { Set(ref _pin_sck, value); }
        }
        private int _reading;
        //即时读数
        public int Reading
        {
            get { return _reading; }
            set { Set(ref _reading, value); }
        }
        private int _steadyReading;
        //存储上次的稳定读数
        public int SteadyReading
        {
            get { return _steadyReading; }
            set { Set(ref _steadyReading, value); }
        }

        private int _offset;
        //传感器偏移值
        public int Offset
        {
            get { return _offset; }
            set { Set(ref _offset, value); }
        }
        private int _gapValue;
        //传感器校准值
        public int GapValue
        {
            get { return _gapValue; }
            set { Set(ref _gapValue, value); }
        }
        private M_SensorDelta _delta;
        //两次稳定测量之间的差值
        public M_SensorDelta Delta
        {
            get { return _delta; }
            set { Set(ref _delta, value); }
        }
        private int _checkTimes;
        //调整多少次近似读数可视为稳定状态
        public int CheckTimes
        {
            get { return _checkTimes; }
            set { Set(ref _checkTimes, value); }
        }

    }       
}
