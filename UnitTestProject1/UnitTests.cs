using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication1.Helper;
using WpfApplication1.Models;
using WpfApplication1.ViewModels;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTests
    {
        /// <summary>
        /// Tests whether it is correctly reads a CSV file.
        /// </summary>
        [TestMethod]
        public void TestReadCsvFile()
        {
            var customerBets = CsvObjectReader.GetCustomerBets("../../../Settled.csv");
            Assert.IsNotNull(customerBets);
            Assert.AreEqual(50, customerBets.Count);
        }

        /// <summary>
        /// Tests whether it loads a correct list of unusual settled bets.
        /// </summary>
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

        /// <summary>
        /// Tests whether it loads a correct list of unusual settled bets for a customer.
        /// </summary>
        [TestMethod]
        public void TestCustomerUnusualSettledBets()
        {
            var viewModel = new UnusualSettledBetsViewModel();
            viewModel.RefreshData();
            viewModel.SelectedCustomer = 4;

            Assert.AreEqual(4, viewModel.CustomerBets.Count);
            Assert.AreEqual(1000, viewModel.CustomerBets[0].WinAmount);
            Assert.AreEqual(2000, viewModel.CustomerBets[1].WinAmount);
            Assert.AreEqual(480, viewModel.CustomerBets[2].WinAmount);
            Assert.AreEqual(1600, viewModel.CustomerBets[3].WinAmount);
        }

        /// <summary>
        /// Tests whether it loads a correct list of unusual unsettled bets.
        /// </summary>
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

        /// <summary>
        /// Tests whether it loads a correct severity fot a list of unusual unsettled bets.
        /// </summary>
        [TestMethod]
        public void TestRiskySeverityUnsettledBets()
        {
            var viewModel = new RiskyUnsettledBetsViewModel();
            viewModel.RefreshData();
            Assert.IsNotNull(viewModel.CustomerBets);
            Assert.AreEqual(6, viewModel.Customers.Count);
            Assert.AreEqual(1, viewModel.SelectedCustomer);
            Assert.AreEqual(4, viewModel.CustomerBets.Count);

            Assert.AreEqual(RiskSeverity.Risky, viewModel.CustomerBets[0].RiskyUnsettledBetSeverity);
            Assert.AreEqual(RiskSeverity.HighWonAmount, viewModel.CustomerBets[1].RiskyUnsettledBetSeverity); 
            Assert.AreEqual(RiskSeverity.Risky, viewModel.CustomerBets[2].RiskyUnsettledBetSeverity);
            Assert.AreEqual(RiskSeverity.HighWonAmount, viewModel.CustomerBets[3].RiskyUnsettledBetSeverity);
        }

        /// <summary>
        /// Tests whether it loads a correct list of unusual unsettled bets for a customer.
        /// </summary>
        [TestMethod]
        public void TestCustomerRiskySeverityUnsettledBets()
        {
            var viewModel = new RiskyUnsettledBetsViewModel();
            viewModel.RefreshData();
            viewModel.SelectedCustomer = 4;

            Assert.AreEqual(4, viewModel.CustomerBets.Count);

            Assert.AreEqual(RiskSeverity.HighWonAmount, viewModel.CustomerBets[0].RiskyUnsettledBetSeverity);
            Assert.AreEqual(RiskSeverity.HighWonAmount, viewModel.CustomerBets[1].RiskyUnsettledBetSeverity);
            Assert.AreEqual(RiskSeverity.HighWonAmount, viewModel.CustomerBets[2].RiskyUnsettledBetSeverity);
            Assert.AreEqual(RiskSeverity.Risky, viewModel.CustomerBets[3].RiskyUnsettledBetSeverity);
        }
    }
}
