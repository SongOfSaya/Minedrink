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
                Update(write, reader);
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
        private async void Update(StreamWriter sw, StreamReader sr)
        {
            while (true)
            {
                string response = await sr.ReadLineAsync();
                if (response.StartsWith("#"))
                {
                    string codeStr = response.Substring(0, 8);
                    RXCommCode code = H_CommandCode.StringConvertToEnum(codeStr);

                    switch (code)
                    {
                        case RXCommCode.ERROR:
                            Debug.WriteLine("错误的指令:" + codeStr);
                            break;
                        case RXCommCode.AllInfo:
                            string json = response.Remove(0, 9);
                            //if (CheckJson())
                            //{
                            //    ReadAllInfo(json);
                            //}
                            break;
                        case RXCommCode.TcpDone:
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