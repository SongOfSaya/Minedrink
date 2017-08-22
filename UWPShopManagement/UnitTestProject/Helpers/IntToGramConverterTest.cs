using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPShopManagement.Helpers;

namespace UnitTestProject.Helpers
{
    [TestClass]
    public class IntToGramConverterTest
    {
        [TestMethod]
        public void MyTestMethod()
        {
            int before = 123456;
            IntToGarmConverter converter = new IntToGarmConverter();
            string after = converter.Convert(before, null, null, null).ToString();
            string expectd = "123456g";
            Assert.AreEqual(after, expectd);
        }
    }
}
