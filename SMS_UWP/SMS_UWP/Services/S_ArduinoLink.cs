using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS_UWP.Models;
using System.IO;
using System.Diagnostics;
using static SMS_UWP.Helpers.H_CommandCode;
using SMS_UWP.Helpers;
using Windows.System.Threading;
using Windows.Data.Json;

namespace SMS_UWP.Services
{
    public class S_ArduinoLink
    {
        public M_ArduinoMarkA Arduino { get; private set; }
        public int ID
        {
            get { return Arduino.ID; }
            set { Arduino.ID = value; }
        }
        public string Name
        {
            get { return Arduino.Name; }
            set { Arduino.Name = value; }
        }
        public S_ArduinoLink()
        {
            Arduino = new M_ArduinoMarkA();
        }
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
                StreamWriter write = new StreamWriter(streamOut);

                Stream streamIn = clientSocket.InputStream.AsStreamForRead();
                StreamReader reader = new StreamReader(streamIn);
                //启动监听程序
                Update(reader);
                CheckIsConnect();

            }
            catch
            {
                return false;
            }
            Arduino.IP = ip;
            Arduino.Port = port;
            return true;
        }
        /// <summary>
        /// 检查链接是否有效
        /// </summary>
        public async void CheckIsConnect()
        {
            if (Arduino.OutStream != null)
            {
                await Arduino.OutStream.WriteLineAsync(TXCCodeConverToString(TXCommCode.TcpConn));
                await Arduino.OutStream.FlushAsync();
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
            if (Arduino.OutStream != null)
            {
                int interval = 50;
                //创建自动发信器
                TimeSpan period = TimeSpan.FromMilliseconds(interval);
                ThreadPoolTimer periodcTimer = null;
                periodcTimer = ThreadPoolTimer.CreatePeriodicTimer(async (source) =>
                {
                    await Arduino.OutStream.WriteLineAsync(TXCCodeConverToString(TXCommCode.TcpConn));
                    await Arduino.OutStream.FlushAsync();
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
            if (outStr != null && Arduino.OutStream != null)
            {
                await Arduino.OutStream.WriteLineAsync(outStr);
                await Arduino.OutStream.FlushAsync();
            }
            else
            {
                throw new NullReferenceException("错误调用");
            }
        }

        /// <summary>
        /// 监听来自Arduino的信息
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="sr"></param>
        private async void Update(StreamReader sr)
        {
            while (true)
            {
                string str = await sr.ReadLineAsync();
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
                Debug.WriteLine("UPDATE:" + str);
            }
        }

        private void RespondTcpDone()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 响应指令:AllInfo
        /// 无\格式:{"ID":1001,"NM":"名称","MIS":1234567,"MOD":4,"CO":12,"SS":[{"DT:123,"OFF":134,"GV":1,"DT":41,"SCK":43},{"SID":"W02","OFF":12,"GV":44,"DT":1,"SCK":43}]}
        /// </summary>
        /// <param name="detail"></param>
        private void RespondAllInfo(string detail)
        {
            var rootObject = JsonObject.Parse(detail);
            Arduino.ID = (int)(rootObject[H_Json.ID].GetNumber());
            Arduino.Mills = (long)rootObject[H_Json.Mills].GetNumber();
            Arduino.Mode = (int)rootObject[H_Json.Mode].GetNumber();
            Arduino.MarkColor = (int)rootObject[H_Json.Color].GetNumber();
            var sensors = rootObject[H_Json.SenSors].GetArray();
            foreach (var item in sensors)
            {
                //Arduino.SensorColeection.Add(new M_WeightSensor{ PIN_DT = item.GET});
            }

            Debug.WriteLine(rootObject["ID"]);
        }

        private void RespondUpdate(string detail)
        {
            throw new NotImplementedException();
        }
    }
}
//string inStr = "";
//string outStr = "#TCPCONN";
//;
//                bool tcpDone = false;
//                while (!tcpDone)
//                {
//                    if (outStr!=null)
//                    {
//                        await write.WriteLineAsync(outStr);
//await write.FlushAsync();
//                    }


//                    inStr = await reader.ReadLineAsync();
//Debug.WriteLine("IN:" + inStr);
//                    if (inStr.StartsWith("#"))
//                    {
//                        string codeStr = inStr.Substring(0, 8);
//RXCommCode code = CommHandle.StringConvertToEnum(codeStr);

//                        switch (code)
//                        {
//                            case RXCommCode.TcpDone:
//                                Arduino arduino = new Arduino(clientSocket, write, reader);
//ConfigPage.Current.Ardu inos.Add(arduino);
//                                tcpDone = true;
//                                break;
//                            case RXCommCode.ERROR:
//                                Debug.WriteLine("错误的指令:" + codeStr);
//                                break;
//                            default:
//                                break;
//                        }
//                    }
//                }
