using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.Data.Json;
using System.Diagnostics;
using UWPShopManagement.Helpers;
using UWPShopManagement.Services;
using System.Threading.Tasks;

namespace UnitTest.Services
{
    [TestClass]
    public class S_ArduinoLinkTest
    {
        [TestMethod]
        public void AllInfoTest()
        {
            S_ArduinoLink arduinolink = new S_ArduinoLink();
            string testStr = "{\"ID\":1001,\"MIS\":2510,\"MOD\":2,\"CO\":12,\"SS\":[{\"DT\":43,\"SCK\":41,\"OFF\":8422741.00,\"GV\":430.00,\"RES\":0.00}]}";
            JsonObject jo = JsonObject.Parse(testStr);
            Debug.WriteLine(jo);
            var actual = (int)jo[H_Json.ID].GetNumber();
            Assert.AreEqual(1001, actual);
            
        }
        [TestMethod]
        public void RespondAllInfoTest()
        {
            S_ArduinoLink arduinoLink = new S_ArduinoLink();
            //bool isSuccess = await arduinoLink.Connection("192.168.2.109","1000");
            //Assert.AreEqual(isSuccess, true, "连接成功");
            string testStr = "{\"ID\":1001,\"MIS\":2510,\"MOD\":2,\"CO\":12,\"SS\":[{\"DT\":43,\"SCK\":41,\"OFF\":8422741.00,\"GV\":430.00,\"RES\":0.00}]}";
            arduinoLink.RespondAllInfo(testStr);
            Assert.AreEqual(arduinoLink.Arduino.ID, 1001, "ID正确");
            Assert.AreEqual(arduinoLink.Arduino.Mills, 2510, "Mills正确");
            Assert.AreEqual(arduinoLink.Arduino.SensorCollection[0].PIN_DT, 43, "DT正确");
        }
        [TestMethod]
        public async Task CanLink()
        {
            S_ArduinoLink arduinoLink = new S_ArduinoLink();
            bool except = await arduinoLink.Connection("192.168.2.109", "1000");
            Assert.AreEqual(except, true,"连接是否成功");
        }
    }
}
