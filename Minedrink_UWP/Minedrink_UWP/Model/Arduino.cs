using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace Minedrink_UWP.Model
{
    public class Arduino
    {
        private static Random random = new Random();
        #region Properties
        public string ID { get; set; }
        private string name;
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //运行模式
        public string Mode { get; set; }
        //传感器列表
        private List<string> sensorList;

        public List<string> SensorList
        {
            get { return sensorList; }
            set { sensorList = value; }
        }
        //用以加强识别的特征颜色
        public Colors Color { get; set; }
        public string IP { get; set; }
        #endregion


        public Arduino()
        {
            ID = "构造函数的ID";
            Name = "主料区-构造函数";
        }
        #region Public Methods
        public static ObservableCollection<Arduino> GetArduinos(int numberOfArduino)
        {
            ObservableCollection<Arduino> arduinos = new ObservableCollection<Arduino>();
            for (int i = 0; i < numberOfArduino; i++)
            {
                arduinos.Add(GetNewArduino());
            }
            return arduinos;
        }
        public override string ToString()
        {
            return name;
        }

        #endregion
        public static Arduino GetNewArduino()
        {
            return new Arduino()
            {
                ID = random.Next().ToString(),
                name = "辅料区"
            };
        }
    }
}
