
using System.Collections.Generic;
using System.Linq;
using WpfApplication1.Models;

namespace WpfApplication1.ViewModels
{
    /// <summary>
    /// Provides a view model for unusual settled bets.
    /// </summary>
    public class UnusualSettledBetsViewModel : CustomersBetsViewModel
    {
        #region Properties

        /// <summary>
        /// Gets the type of customer bets.
        /// </summary>
        public override CustomerBetType BetType
        {
            get { return CustomerBetType.Settled; }
        }

        /// <summary>
        /// Gets the file path for data source.
        /// </summary>
        public override string DataSourceFilePath
        {
            get { return @"../../../Settled.csv"; }
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Refreshes the items source.
        /// </summary>
        public override void RefreshData()
        {
            LoadKeyedCustomersData();
            List<int> customers = KeyedCustomersData.Where(cb => cb.Value.Any(b => b.WinAmount > 0.6m * b.StakeAmount)).Select(c => c.Key).ToList();

            Customers.Clear();
            customers.ForEach(Customers.Add);
            SelectedCustomer = customers.FirstOrDefault();
        }

        /// <summary>
        /// Runs when selected customer is changed.
        /// </summary>
        protected override void OnSelectedCustomerChanged()
        {
            CustomerBets.Clear();

            if (KeyedCustomersData.ContainsKey(SelectedCustomer))
            {
                List<CustomerBet> unususalCustomerBets = KeyedCustomersData[SelectedCustomer].Where(b => b.WinAmount > 0.6m * b.StakeAmount).ToList();
                unususalCustomerBets.ForEach(CustomerBets.Add);
            }
        }
        #endregion

    }
}
