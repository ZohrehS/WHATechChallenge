
using System.Collections.Generic;
using System.Linq;
using WpfApplication1.Models;

namespace WpfApplication1.ViewModels
{
    /// <summary>
    /// Provides a view model for risky unsettled bets.
    /// </summary>
    public class RiskyUnsettledBetsViewModel : CustomersBetsViewModel
    {
        #region Properties

        /// <summary>
        /// Gets the type of customer bets.
        /// </summary>
        public override CustomerBetType BetType
        {
            get { return CustomerBetType.Unsettled; }
        }

        /// <summary>
        /// Gets the file path for data source.
        /// </summary>
        public override string DataSourceFilePath
        {
            get { return @"../../../Unsettled.csv"; }
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Refreshes the items source.
        /// </summary>
        public override void RefreshData()
        {
            LoadKeyedCustomersData();
            List<int> customers = (from cb in KeyedCustomersData
                                   let average = cb.Value.Sum(i => i.StakeAmount) / cb.Value.Count
                                   where cb.Value.Any(b => b.WinAmount > 0.6m * b.StakeAmount) ||
                                         cb.Value.Any(b => b.StakeAmount > average) ||
                                         cb.Value.Any(b => b.WinAmount >= 1000m)
                                   select cb.Key).ToList();

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
                List<CustomerBet> customerItems = KeyedCustomersData[SelectedCustomer];

                var average = customerItems.Sum(i => i.StakeAmount) / customerItems.Count;
                customerItems.ForEach(cb =>
                {
                    if (cb.WinAmount > 0.6m * cb.StakeAmount)
                    {
                        cb.RiskyUnsettledBetSeverity = RiskSeverity.Risky;
                    }
                    if (cb.StakeAmount > 10 * average)
                    {
                        cb.RiskyUnsettledBetSeverity = RiskSeverity.Unusual;
                    }
                    if (cb.StakeAmount > 30 * average)
                    {
                        cb.RiskyUnsettledBetSeverity = RiskSeverity.HighlyUnusual;
                    }
                    if (cb.WinAmount >= 1000m)
                    {
                        cb.RiskyUnsettledBetSeverity = RiskSeverity.HighWonAmount;
                    }
                });
                
                List<CustomerBet> riskyCustomerBets = (from cb in customerItems
                                                       where cb.WinAmount > 0.6m * cb.StakeAmount ||
                                                             cb.StakeAmount > 10 * average ||
                                                             cb.StakeAmount > 30 * average ||
                                                             cb.WinAmount >= 1000m
                                                       select cb).ToList();

                riskyCustomerBets.ForEach(CustomerBets.Add);
            }

        }
        #endregion

    }
}
