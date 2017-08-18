using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPShopManagement.ViewModels;

namespace UnitTestProject.ViewModels
{
    [TestClass]
    public class VM_ArduinoManagementTest
    {
        [TestMethod]
        public void RefreshBenCommandTest()
        {
            VM_ArduinoManagement viewModel = new VM_ArduinoManagement();
            int num = viewModel.ArduinoLinkItems.Count;
            viewModel.RefreshBtnCommand.Execute(null);
            int actual = viewModel.ArduinoLinkItems.Count;
            Assert.AreEqual(num + 1, actual);
        }
    }
}
