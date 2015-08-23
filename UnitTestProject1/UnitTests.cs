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
            Assert.AreEqual(6, viewModel.Customers.Count);
            Assert.AreEqual(1, viewModel.SelectedCustomer);
            Assert.AreEqual(7, viewModel.CustomerBets.Count);
            Assert.AreEqual(250, viewModel.CustomerBets[0].WinAmount);
            Assert.AreEqual(60, viewModel.CustomerBets[1].WinAmount);
        } 
        
        [TestMethod]
        public void TestRiskyUnsettledBets()
        {
            var viewModel = new RiskyUnsettledBetsViewModel();
            viewModel.RefreshData();
            Assert.IsNotNull(viewModel.CustomerBets);
            Assert.AreEqual(6, viewModel.Customers.Count);
            Assert.AreEqual(1, viewModel.SelectedCustomer);
            Assert.AreEqual(4, viewModel.CustomerBets.Count);
            Assert.AreEqual(500, viewModel.CustomerBets[0].WinAmount);
            Assert.AreEqual(5000, viewModel.CustomerBets[1].WinAmount);
        }
    }
}
