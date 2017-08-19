using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.Data.Json;
using System.Diagnostics;
using UWPShopManagement.Helpers;
using UWPShopManagement.Services;
using UWPShopManagement.Models;
using System.Threading.Tasks;
using Windows.System.Threading;

namespace UnitTest.Models
{
    [TestClass]
    public class M_ArduinoMarkATest
    {
        [TestMethod]
        public void MillsConverterTest()
        {
            long mills = 86400000;
            TimeSpan timeSpan = M_ArduinoMarkA.MillsConverter(mills);
            TimeSpan excepted = new TimeSpan(24, 0, 0);
            Assert.AreEqual(timeSpan, excepted);
        }
    }
}
