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
            }
            catch
            {
                return false;
            }
            Arduino.IP = ip;
            Arduino.Port = port;
            return true;
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