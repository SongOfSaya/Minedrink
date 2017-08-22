using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPShopManagement.Helpers;

namespace UWPShopManagement.Models
{
    public class M_SensorDelta : Observable
    {
        private int _delta;

        public int Delta
        {
            get { return _delta; }
            set { Set(ref _delta, value); }
        }
        private TimeSpan _timing;

        public TimeSpan Timing
        {
            get { return _timing;}
            set { Set(ref _timing, value); }
        }
        public override string ToString()
        {
            string result = "↓ " + Delta + " g";
            TimeSpan deltaT = DateTime.Now.TimeOfDay - Timing;
            result += "|" + deltaT + "之前";
            return result;
        }
    }
}
