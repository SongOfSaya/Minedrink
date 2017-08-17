using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPShopManagement.Models
{
    public class M_WeightSensor : M_SensorBase
    {
        public int PIN_DT { get; set; }
        public int PIN_SCK { get; set; }
        public float Result { get; set; }
        public float OffSet { get; set; }
        public float GapValue { get; set; }
    }
}
