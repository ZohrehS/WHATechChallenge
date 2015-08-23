
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WpfApplication1.Helper;
using WpfApplication1.Models;

namespace WpfApplication1.ViewModels
{
    /// <summary>
    /// Provides a base view model for displaying a list of customers' bets.
    /// </summary>
    public abstract class CustomersBetsViewModel : NotificationObject
    {
        #region Fields
        private ObservableCollection<CustomerBet> _customerBets = new ObservableCollection<CustomerBet>(); 
        #endregion

        #region Properties
        /// <summary>
        /// Gets the type of customer bets.
        /// </summary>
        public abstract CustomerBetType BetType { get; }

        /// <summary>
        /// Gets the file path for data source.
        /// </summary>
        public abstract string DataSourceFilePath { get; }

        /// <summary>
        /// Gets or sets a list of customers' bets.
        /// </summary>
        public ObservableCollection<CustomerBet> CustomerBets
        {
            get { return _customerBets; }
            set
            {
                _customerBets = value;
                OnPropertyChanged("CustomerBets");
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Refreshes the items source.
        /// </summary>
        public abstract void RefreshData();
        #endregion

        #region Protected Methods
         /// <summary>
        /// Gets data from the source file.
        /// </summary>
        protected virtual List<CustomerBet> LoadData()
        {
            var list = CsvObjectReader.GetCustomerBets(DataSourceFilePath);
            return list;
        }
        #endregion
    }
}
