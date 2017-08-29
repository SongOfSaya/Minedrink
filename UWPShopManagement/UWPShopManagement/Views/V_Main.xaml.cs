using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UWPShopManagement.Helpers;
using UWPShopManagement.Models;
using UWPShopManagement.Services;
using UWPShopManagement.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPShopManagement.Views
{
    public sealed partial class V_Main : Page
    {
        public VM_Main ViewModel { get; } = Singleton<VM_Main>.Instance;
        public V_Main()
        {
            InitializeComponent();
        }
        public void ExperimentMethon()
        {
           
        }

        private async void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

            //S_HttpConnect connect = Singleton<S_HttpConnect>.Instance;
            //await connect.WebSocketTest();
            //var httpResponse = await connect.ConnectToServer();
            //TestTextBlock.Text = await httpResponse.Content.ReadAsStringAsync();
            //TestA();
            TestBtn.IsEnabled = false;
            await TestB();
            TestBtn.IsEnabled = true;
        }
        private async Task TestA()
        {
            M_ArduinoMarkA m_ArduinoMarkA = S_SampleData.ServerArduinoDemo();
            string str = await H_Json.StringifyAsync(m_ArduinoMarkA);
            Debug.WriteLine("转义后:"+str);
            str = "{ \"name\":\"主料区\",\"BCS\":233,\"ID\":\"MCU1234\",\"ip\":\"192.168.0.1\",\"Port\":\"1000\",\"Shop\":\"一号店\",\"MarkColor\":123,\"Type\":\"ArduinoMega2560\",\"Mills\":\"00:00:00\",\"IsConnect\":false,\"SensorCollection\":[{\"PIN_DT\":53,\"Name\":\"西瓜\",\"PIN_SCK\":0,\"Reading\":0,\"SteadyReading\":0,\"Offset\":0,\"GapValue\":0,\"Delta\":null,\"CheckTimes\":0},{\"PIN_DT\":12,\"Name\":\"苹果\"}]}";
            M_ArduinoMarkA m_Arduino = await H_Json.ToObjectAsync<M_ArduinoMarkA>(str);
            Debug.WriteLine(m_Arduino);
            TestTextBlock.Text = m_Arduino.ToString();
        }
        private async Task TestB()
        {
            
            S_HttpConnect s_HttpConnect = new S_HttpConnect();
            List<M_ArduinoMarkA> arduinoList = await s_HttpConnect.GetAllMCUWithShop("二号店");
            foreach (var item in arduinoList)
            {
                Debug.WriteLine(item.ToString());
                bool actual = item.ID.StartsWith("MCU");
            }
        }
    }
}
