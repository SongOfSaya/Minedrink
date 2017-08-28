using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UWPShopManagement.Helpers;
using UWPShopManagement.Models;
using Windows.Data.Json;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Windows.Web.Http;

namespace UWPShopManagement.Services
{
    public class S_HttpConnect
    {
        public readonly static string GetAllArduinoWithShop = "https://functionapp833.azurewebsites.net/api/AllMCU?code=Z460UD6vHsOBulWskYlb3noK9mWiZAj3Lhqq2qyEbZzxSOFetxEBQg==";
        /// <summary>
        /// 根据给定uri进行GET请求并返回回复消息
        /// </summary>
        /// <param name="requestUri">制定的Uri地址</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> ConnectToServer(Uri requestUri)
        {
            HttpClient httpClient = new HttpClient();
            var headers = httpClient.DefaultRequestHeaders;
            string header = "ie";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }
            header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64;  Trident/6.0)";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            //发送GET请求
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            //string httpResponseBody = "";
            try
            {
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                //string httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                return httpResponse;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                httpClient.Dispose();
            }
        }
        public async Task<JsonArray> GETToJsonAsync(Uri requestUri)
        {
            var httpResponse = await this.ConnectToServer(requestUri);
            string str = await httpResponse.Content.ReadAsStringAsync();
            Debug.WriteLine("获取的字符串:" + str);
            //string newstr = str.Replace(@"\", string.Empty);

            //string newStr = str.Replace("\\r", string.Empty).Replace("\\n", string.Empty);
            JsonArray jsonArray;
            if (JsonArray.TryParse(str,out jsonArray))
            {
                Debug.WriteLine("转为JSON成功");
            }
            else
            {
                Debug.WriteLine("转为JSON失败");
            }
            return jsonArray;
            
        }
        public async Task<List<M_ArduinoMarkA>> GetAllMCUWithShop(string shop)
        {
            string str = GetAllArduinoWithShop + "&Shop=" + shop;
            Uri uri = new Uri(str);
            JsonArray jsonArray = await GETToJsonAsync(uri);
            List<M_ArduinoMarkA> arduinos = new List<M_ArduinoMarkA>();
            foreach (var item in jsonArray)
            {
                arduinos.Add(await H_Json.ToObjectAsync<M_ArduinoMarkA>(item.Stringify()));
            }
            return arduinos;
        }
        /// <summary>
        /// HTTP实验用方法
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> ConnectToServer()
        {
            HttpClient httpClient = new HttpClient();
            var headers = httpClient.DefaultRequestHeaders;
            string header = "ie";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }
            header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }
            Uri requesetUri = new Uri("https://functionapp833.azurewebsites.net/api/QueryDocumentWithID?code=FaJ3rd9999CAj8EZi3Sx/oyFpgNO5Ylj41TxAoTLERQw9HilasSEMg==&id=12353");
            //发送GET请求
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            //string httpResponseBody = "";
            try
            {
                httpResponse = await httpClient.GetAsync(requesetUri);
                httpResponse.EnsureSuccessStatusCode();
                //string httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                return httpResponse;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                httpClient.Dispose();
            }

        }
        public async Task WebSocketTest()
        {
            MessageWebSocket webSock = new MessageWebSocket();

            //In this case we will be sending/receiving a string so we need to set the MessageType to Utf8.
            webSock.Control.MessageType = SocketMessageType.Utf8;

            //Add the MessageReceived event handler.
            webSock.MessageReceived += WebSock_MessageReceived;

            //Add the Closed event handler.
            webSock.Closed += WebSock_Closed;

            Uri serverUri = new Uri("https://functionapp833.azurewebsites.net/api/QueryDocumentWithID?code=FaJ3rd9999CAj8EZi3Sx/oyFpgNO5Ylj41TxAoTLERQw9HilasSEMg==&id=12353");

            try
            {
                //Connect to the server.
                await webSock.ConnectAsync(serverUri);

                //Send a message to the server.
                await WebSock_SendMessage(webSock, "Hello, world!");
            }
            catch (Exception)
            {
                //Add code here to handle any exceptions
            }
        }
        //The MessageReceived event handler.
        private void WebSock_MessageReceived(MessageWebSocket sender, MessageWebSocketMessageReceivedEventArgs args)
        {
            DataReader messageReader = args.GetDataReader();
            messageReader.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
            string messageString = messageReader.ReadString(messageReader.UnconsumedBufferLength);
            Debug.WriteLine("WebSocket:" + messageString);
            //Add code here to do something with the string that is received.
        }
        //The Closed event handler
        private void WebSock_Closed(IWebSocket sender, WebSocketClosedEventArgs args)
        {
            //Add code here to do something when the connection is closed locally or by the server
        }
        //Send a message to the server.
        private async Task WebSock_SendMessage(MessageWebSocket webSock, string message)
        {
            DataWriter messageWriter = new DataWriter(webSock.OutputStream);
            messageWriter.WriteString(message);
            await messageWriter.StoreAsync();
        }
    }
}
