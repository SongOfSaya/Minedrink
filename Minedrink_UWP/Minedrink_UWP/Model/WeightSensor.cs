using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minedrink_UWP.Model
{
    
    public class WeightSensor
    {
        public int ID { get; set; }
        public int PIN_DT { get; set; }
        public int PIN_SCK { get; set; }
        public float Result { get; set; }
        public float OffSet { get; set; }
        public float GapValue { get; set; }
        public WeightSensor()
        {

        }

    }
}
