using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Networking.Sockets;
using Windows.UI;

namespace Minedrink_UWP.Model
{
    public class Arduino
    {
        private static Random random = new Random();
        #region Properties
        public int ID { get; set; }
        public Colors DisplayColor { get; set; }
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
            ID = 1235;
            Name = "主料区-构造函数";
        }
        public Arduino(StreamSocket socket, StreamWriter sw, StreamReader sr)
        {
            ClientSocket = socket;
            InStream = sr;
            OutStream = sw;
            Update();
            SendCommCode(TXCommCode.GetAllInfo);
        }
        private async void Update()
        {
            while (true)
            { 
                string response = await InStream.ReadLineAsync();
                if (response.StartsWith("#"))
                {
                    string codeStr = response.Substring(0, 8);
                    RXCommCode code = CommHandle.StringConvertToEnum(codeStr);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
                    switch (code)
                    {
                        case RXCommCode.ERROR:
                            Debug.WriteLine("错误的指令:" + codeStr);
                            break;
                        case RXCommCode.AllInfo:
                            string json = response.Remove(0, 9);
                            if (CheckJson())
                            {
                                ReadAllInfo(json);
                            }
                            break;
                        case RXCommCode.Update:
                            break;
                        default:

                            break;
                    }
                }
                Debug.WriteLine("UPDATE:" + response);
            }
        }

        public void ReadAllInfo(string jsonString)
        {
            var rootObject = JsonObject.Parse(jsonString);
            ID = (int)(rootObject["ID"].GetNumber());
            Debug.WriteLine(rootObject["ID"]);
        }

        private bool CheckJson()
        {
            return true;
        }

        #region Public Methods
        public async void SendCommCode(TXCommCode txCommCode)
        {
            string str = CommHandle.TXCCodeConverToString(txCommCode);
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
                ID = random.Next(),
                name = "辅料区"
            };
        }
        #endregion
    }
}
