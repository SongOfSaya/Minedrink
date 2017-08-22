using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPShopManagement.Models;
using System.IO;
using System.Diagnostics;
using UWPShopManagement.Helpers;
using Windows.System.Threading;
using Windows.Data.Json;
using static UWPShopManagement.Helpers.H_CommandCode;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace UWPShopManagement.Services
{
    public class S_ArduinoLink : Observable
    {
        #region Properties


        public M_ArduinoMarkA Arduino { get; set; }

        public S_ArduinoLink()
        {
            Arduino = new M_ArduinoMarkA
            {
                SensorCollection = new ObservableCollection<M_WeightSensor>()
            };
        }
        public S_ArduinoLink(M_ArduinoMarkA arduinoMarkA)
        {
            Arduino = arduinoMarkA;
        }
        //输出流
        public StreamWriter OutStream { get; private set; }
        //输入流
        public StreamReader InStream { get; private set; }
        private int _tempDelta;
        private int _stableReading;
        #endregion
        /// <summary>
        /// 和远程Arduino的TCPServer建立连接
        /// </summary>
        /// <param name="ip">指定的IP</param>
        /// <param name="port">指定的端口号</param>
        /// <returns></returns>
        public async Task<bool> Connection(string ip, string port)
        {
            try
            {
                Windows.Networking.Sockets.StreamSocket clientSocket = new Windows.Networking.Sockets.StreamSocket();
                Windows.Networking.HostName serverHost = new Windows.Networking.HostName(ip);
                await clientSocket.ConnectAsync(serverHost, port);

                Stream streamOut = clientSocket.OutputStream.AsStreamForWrite();
                OutStream = new StreamWriter(streamOut);

                Stream streamIn = clientSocket.InputStream.AsStreamForRead();
                InStream = new StreamReader(streamIn);
                //启动监听程序
                Arduino.IP = ip;
                Arduino.Port = port;

                Update();
                CheckIsConnect();

                SendCommand(TXCommCode.GetAllInfo);
                return true;
            }
            catch
            {
                return false;
            }

        }
        /// <summary>
        /// 检查链接是否有效
        /// </summary>
        public async void CheckIsConnect()
        {
            if (OutStream != null)
            {
                await OutStream.WriteLineAsync(TXCCodeConverToString(TXCommCode.TcpConn));
                await OutStream.FlushAsync();
            }
            else
            {
                Arduino.IsConnect = false;
            }
        }
        /// <summary>
        /// 连续多次发送验证命令
        /// </summary>
        /// <param name="times">执行次数</param>
        public void CheckIsConnect(int times)
        {
            if (OutStream != null)
            {
                int interval = 50;
                //创建自动发信器
                TimeSpan period = TimeSpan.FromMilliseconds(interval);
                ThreadPoolTimer periodcTimer = null;
                periodcTimer = ThreadPoolTimer.CreatePeriodicTimer(async (source) =>
                {
                    await OutStream.WriteLineAsync(TXCCodeConverToString(TXCommCode.TcpConn));
                    await OutStream.FlushAsync();
                    if (period.TotalMilliseconds > (interval * times))
                    {
                        periodcTimer.Cancel();
                    }
                    //Dispatcher.RunAsync(CoreDispatcherPriority.HIGH, () =>
                    // {
                    //     //UI components can be accessed within this scope.
                    // });
                }, period);
            }
            else
            {
                Arduino.IsConnect = false;
            }

        }
        /// <summary>
        /// 向目标Arduino发送字符串
        /// </summary>
        /// <param name="outStr">发送的字符串</param>
        public async void SendCommand(string outStr)
        {
            if (outStr != null && OutStream != null)
            {
                await OutStream.WriteLineAsync(outStr);
                await OutStream.FlushAsync();
            }
            else
            {
                throw new NullReferenceException("错误调用");
            }
        }
        public async void SendCommand(TXCommCode commCode)
        {
            string outStr = TXCCodeConverToString(commCode);
            SendCommand(outStr);
            await Task.CompletedTask;
        }

        /// <summary>
        /// 监听来自Arduino的信息
        /// </summary>
        private async void Update()
        {
            while (true)
            {
                string str = await InStream.ReadLineAsync();
                if (str.StartsWith("#"))
                {
                    string command = str.Substring(0, 8);
                    string detail = "";
                    if (str.Length > 9)
                        detail = str.Remove(0, 9);
                    RXCommCode code = H_CommandCode.StringConvertToEnum(command);

                    switch (code)
                    {
                        case RXCommCode.ERROR:
                            Debug.WriteLine("错误的指令:" + command);
                            break;
                        case RXCommCode.AllInfo:
                            RespondAllInfo(detail);
                            break;
                        case RXCommCode.TcpDone:
                            RespondTcpDone();
                            break;
                        case RXCommCode.Update:
                            RespondUpdate(detail);
                            break;
                        default:

                            break;
                    }
                }
#if DEBUG
                Debug.WriteLine("IN:" + str);
#endif
            }
        }

        private void RespondTcpDone()
        {
            SendCommand(TXCommCode.GetAllInfo);
        }
        /// <summary>
        /// 响应指令:AllInfo
        /// 无\格式:{"ID":1001,"NM":"名称","MIS":1234567,"MOD":4,"CO":12,"SS":[{"DT:123,"OFF":134,"GV":1,"DT":41,"SCK":43},{"SID":"W02","OFF":12,"GV":44,"DT":1,"SCK":43}]}
        /// </summary>
        /// <param name="detail"></param>
        public void RespondAllInfo(string detail)
        {

            var rootObject = JsonObject.Parse(detail);
            Arduino.ID = (int)(rootObject[H_Json.ID].GetNumber());
            Arduino.Mills = M_ArduinoMarkA.MillsConverter((long)rootObject[H_Json.Mills].GetNumber());
            Arduino.Mode = (int)rootObject[H_Json.Mode].GetNumber();
            Arduino.MarkColor = (int)rootObject[H_Json.Color].GetNumber();
            var sensors = rootObject[H_Json.SenSors].GetArray();
            Arduino.SensorCollection.Clear();

            foreach (var item in sensors)
            {
                JsonObject sensorObject = item.GetObject();
                Arduino.SensorCollection.Add(new M_WeightSensor
                {
                    PIN_DT = (int)sensorObject[H_Json.DT].GetNumber(),
                    PIN_SCK = (int)sensorObject[H_Json.SCK].GetNumber(),
                    Offset = (int)sensorObject[H_Json.Offset].GetNumber(),
                    GapValue = (int)sensorObject[H_Json.GapValue].GetNumber(),
                    Reading = (int)sensorObject[H_Json.Reading].GetNumber()
                });

            }
        }
        /// <summary>
        /// 响应UPDATE指令
        /// #UPDATEX="{\"ID\":1001,\"MIS\":192105,\"MOD\":1,\"SS\":[{\"DT\":43,\"READ\":3}]}"
        /// </summary>
        /// <param name="detail">指令的数据</param>
        private void RespondUpdate(string detail)
        {
#if DEBUG
            Debug.WriteLine("接收到字符串:" + detail);
#endif
            try
            {
                var rootObject = JsonObject.Parse(detail);
                Arduino.Mills = M_ArduinoMarkA.MillsConverter((long)rootObject[H_Json.Mills].GetNumber());
                Arduino.Mode = (int)rootObject[H_Json.Mode].GetNumber();
                var sensors = rootObject[H_Json.SenSors].GetArray();
                foreach (var item in sensors)
                {
                    JsonObject sensorObject = item.GetObject();
                    int DT = (int)sensorObject[H_Json.DT].GetNumber();
                    //是否有匹配的sensor
                    if (Arduino.SensorCollection.Any(p => p.PIN_DT == DT))
                    {
                        M_WeightSensor m_WeightSensor = Arduino.SensorCollection.Single(p => p.PIN_DT == DT);
                        int lastReading = m_WeightSensor.Reading;
                        m_WeightSensor.Reading = (int)sensorObject[H_Json.Reading].GetNumber();
                        //TODO:平稳后取delta
                        int delta = 0;
                        bool isValid = SetDelta(lastReading, m_WeightSensor.Reading, ref delta);
                        if (isValid)
                            m_WeightSensor.Delta = new M_SensorDelta { Timing = DateTime.Now.TimeOfDay, Delta = delta };
                    }
                    else
                    {
                        //TODO:如果没有的话是否要自动新增
                    }

                }
            }
            catch (COMException)
            {
                Debug.WriteLine("无效JSON:" + detail);
            }

        }
        /// <summary>
        /// 确定被拿走了多少
        /// </summary>
        /// <param name="lastReading"></param>
        /// <param name="nowReading"></param>
        /// <param name="delta"></param>
        /// <returns></returns>
        private bool SetDelta(int lastReading, int nowReading, ref int delta)
        {
            int tempDelta = lastReading - nowReading;
            //两次读数接近则视为稳定
            if (Math.Abs(delta) < 5)
            {
                tempDelta = _stableReading - nowReading;
                _stableReading = nowReading;
                //大于阈值才有效
                if (tempDelta > 5)
                {
                    delta = tempDelta;
                    return true;
                }
                else if (delta < 0)
                {
                    Debug.WriteLine("检测到小于0的delta");
                }
            }
            return false;
        }
    }
}
