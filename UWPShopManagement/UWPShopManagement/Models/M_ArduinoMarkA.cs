using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace UWPShopManagement.Models
{
    /// <summary>
    /// 不知道是否需要Observeable
    /// </summary>
    public class M_ArduinoMarkA
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public long Mills { get; set; }
        public string IP { get; set; }
        public string Port { get; set; }
        public int Mode { get; set; }
        public int MarkColor { get; set; }
        //此Arduino是否在线
        public bool IsConnect { get; set; }
        public ObservableCollection<M_WeightSensor> SensorCollection { get; set; }
    }
    
}
