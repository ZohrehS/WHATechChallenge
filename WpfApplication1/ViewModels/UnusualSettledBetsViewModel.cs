
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
            List<CustomerBet> allCustomerBets = LoadData();
            List<CustomerBet> unususalCustomerBets = allCustomerBets.Where(b => b.WinAmount > 0.6m*b.StakeAmount).ToList();
            CustomerBets.Clear();
            unususalCustomerBets.ForEach(CustomerBets.Add);
        }
        #endregion

    }
}
