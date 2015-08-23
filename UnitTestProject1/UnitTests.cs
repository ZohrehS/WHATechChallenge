using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication1.Helper;
using WpfApplication1.ViewModels;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestReadCsvFile()
        {
            var customerBets = CsvObjectReader.GetCustomerBets("../../../Settled.csv");
            Assert.IsNotNull(customerBets);
            Assert.AreEqual(50, customerBets.Count);
        }

        [TestMethod]
        public void TestUnusualSettledBets()
        {
            var viewModel = new UnusualSettledBetsViewModel();
            viewModel.RefreshData();
            Assert.IsNotNull(viewModel.CustomerBets);
            Assert.AreEqual(19, viewModel.CustomerBets.Count);
            Assert.AreEqual(250, viewModel.CustomerBets[0].WinAmount);
            Assert.AreEqual(1000, viewModel.CustomerBets[1].WinAmount);
        }
    }
}
