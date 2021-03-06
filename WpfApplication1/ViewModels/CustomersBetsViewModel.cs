﻿
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
        private readonly ObservableCollection<CustomerBet> _customerBets = new ObservableCollection<CustomerBet>();
        private readonly ObservableCollection<int> _customers = new ObservableCollection<int>();
        private Dictionary<int, List<CustomerBet>> _keyedCustomersData = new Dictionary<int, List<CustomerBet>>();
        private int _selectedCustomer;
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
        /// Gets a list of customers' bets.
        /// </summary>
        public ObservableCollection<CustomerBet> CustomerBets
        {
            get { return _customerBets; }
        }

        /// <summary>
        /// Gets a list of customer IDs.
        /// </summary>
        public ObservableCollection<int> Customers
        {
            get { return _customers; }
        }

        /// <summary>
        /// Gets or sets the selected customer ID.
        /// </summary>
        public int SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged("SelectedCustomer");
                OnSelectedCustomerChanged();
            }
        }
        #endregion

        #region Protected Members

        protected Dictionary<int, List<CustomerBet>> KeyedCustomersData
        {
            get { return _keyedCustomersData; }
            private set { _keyedCustomersData = value; }
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
        /// Runs when selected customer is changed.
        /// </summary>
        protected abstract void OnSelectedCustomerChanged();

        /// <summary>
        /// Loads keyed customers data from the source file.
        /// </summary>
        protected virtual void LoadKeyedCustomersData()
        {
            List<CustomerBet> list = CsvObjectReader.GetCustomerBets(DataSourceFilePath);
            KeyedCustomersData = list.OrderBy(i => i.CustomerId).GroupBy(i => i.CustomerId).ToDictionary(i => i.Key, i => i.ToList());
        }
        #endregion
    }
}
