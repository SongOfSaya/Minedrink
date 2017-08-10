
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minedrink_UWP.Model;
namespace UnitTestProjectForSMS
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Class target = new Class();
            //PrivateObject obj = new PrivateObject(target);
            //var retVal = obj.Invoke("PrivateMethod");
            //Assert.AreEqual(retVal);

            Arduino arduino = new Arduino();
            Type t = arduino.GetType();
            
            string str = "{\"ID\":10, \"Mills\" : 1243, \"Mode\" : 1, \"Sensors\" : [{\"ID\":1085, \"Result\" : 123.44}, {\"ID\":1086,\"Result\" : 1234.4 }]}";
            arduino.ReadAllInfo(str);
            Assert.AreEqual(arduino.ID, 10);
        }
    }
}
