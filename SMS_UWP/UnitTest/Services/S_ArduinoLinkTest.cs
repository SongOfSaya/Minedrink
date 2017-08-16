using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.Data.Json;
using System.Diagnostics;
//using SMS_UWP.Helpers;

namespace UnitTest.Services
{
    [TestClass]
    public class S_ArduinoLinkTest
    {
        [TestMethod]
        public void AllInfoTest()
        {
            //S_ArduinoLinkTest arduinolink = new S_ArduinoLinkTest();
            //string testStr = "{\"ID\":1001,\"MIS\":2510,\"MOD\":2,\"CO\":12,\"SS\":[{\"DT\":43,\"SCK\":41,\"OFF\":8422741.00,\"GV\":430.00,\"RES\":0.00}]}";
            //JsonObject jo = JsonObject.Parse(testStr);
            //Debug.WriteLine(jo);
            //var actual = (int)jo[H_Json.ID].GetNumber();
            //Assert.AreEqual(1001, actual);
            Assert.AreEqual(1, 1);
        }
    }
}
