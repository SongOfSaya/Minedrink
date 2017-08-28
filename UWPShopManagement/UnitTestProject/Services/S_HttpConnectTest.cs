using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UWPShopManagement.Services;
using UWPShopManagement.Models;

namespace UnitTestProject.Services
{
    [TestClass]
    public class S_HttpConnectTest
    {
        [TestMethod]
        public void GetAllMCUTest()
        {
            S_HttpConnect s_HttpConnect = new S_HttpConnect();
            List<M_ArduinoMarkA> arduinoList = s_HttpConnect.GetAllMCUWithShop("一号店").Result;
            foreach (var item in arduinoList)
            {
                Assert.AreEqual(item.Shop, "一号店");
                bool actual = item.ID.StartsWith("MCU");
                Assert.IsTrue(actual);
            }
        }
    }
}
