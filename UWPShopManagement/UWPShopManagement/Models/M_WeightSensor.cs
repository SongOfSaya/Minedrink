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

        public int PIN_DT
        {
            get { return _pin_dt; }
            set { Set(ref _pin_dt, value); }
        }
        private int _pin_sck;

        public int PIN_SCK
        {
            get { return _pin_sck; }
            set { Set(ref _pin_sck, value); }
        }
        private int _reading;

        public int Reading
        {
            get { return _reading; }
            set { Set(ref _reading, value); }
        }
        private int _offset;

        public int Offset
        {
            get { return _offset; }
            set { Set(ref _offset, value); }
        }
        private int _gapValue;

        public int GapValue
        {
            get { return _gapValue; }
            set { Set(ref _gapValue, value); }
        }
        private M_SensorDelta _delta;

        public M_SensorDelta Delta
        {
            get { return _delta; }
            set { Set(ref _delta, value); }
        }
    }       
}
