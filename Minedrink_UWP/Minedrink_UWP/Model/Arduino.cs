using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Sockets;
using Windows.UI;

namespace Minedrink_UWP.Model
{
    public class Arduino
    {
        private static Random random = new Random();
        
        #region Properties
        public string ID { get; set; }
        private string name;
        //与Arduino建立的TCP输入输出流
        public StreamWriter OutStream { get; private set; }
        public StreamReader InStream { get; private set; }
        public StreamSocket ClientSocket { get; private set; }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //运行模式
        public string Mode { get; set; }
        //传感器列表
        private List<WeightSensor> sensorList;

        public List<WeightSensor> SensorList
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
        public Arduino(StreamSocket socket, StreamWriter sw, StreamReader sr)
        {
            ClientSocket = socket;
            InStream = sr;
            OutStream = sw;
            Update();
        }
        private async void Update()
        {
            while (true)
            {
                string response = await InStream.ReadLineAsync();
                if (response.StartsWith("#"))
                {
                    string codeStr = response.Substring(0, 8);
                    CommCode code = CommHandle.StringConvertToEnum(codeStr);

                    switch (code)
                    {
                        case CommCode.ERROR:
                            Debug.WriteLine("错误的指令:" + codeStr);
                            break;
                        default:
                            break;
                    }
                }
                Debug.WriteLine("UPDATE:" + response);
            }
        }

        #region Public Methods
        public async void RefreshSensorsInfo()
        {
            string str = "#GETSENS";
            await OutStream.WriteLineAsync(str);
            await OutStream.FlushAsync();
        }
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
        public void SetInAndOutStream(StreamReader instream,StreamWriter outStream)
        {
            InStream = instream;
            OutStream = outStream;
        }
        
        public static Arduino GetNewArduino()
        {
            return new Arduino()
            {
                ID = random.Next().ToString(),
                name = "辅料区"
            };
        }
        #endregion
    }
}
