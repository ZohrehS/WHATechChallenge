using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Annotations;

namespace WpfApplication1.Models
{
    /// <summary>
    /// Provides a model for customer bets history.
    /// </summary>
    public class CustomerBet :INotifyPropertyChanged
    {
        #region Fields
        public event PropertyChangedEventHandler PropertyChanged;
        private CustomerBetType _type;
        private int _customerId;
        private int _eventCode;
        private int _participantCode;

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the type of bet history.
        /// </summary>
        public CustomerBetType Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged("Type");

            }
        }
        
        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        public int CustomerId
        {
            get { return _customerId; }
            set
            {
                _customerId = value;
                OnPropertyChanged("CustomerId");

            }
        }

        /// <summary>
        /// Gets or sets the event code. 
        /// </summary>
        public int EventCode
        {
            get { return _eventCode; }
            set
            {
                _eventCode = value;
                OnPropertyChanged("EventCode");                
            }
        }

        /// <summary>
        /// Gets or sets the participant code.
        /// </summary>
        public int ParticipantCode
        {
            get { return _participantCode; }
            set
            {
                _participantCode = value;
                OnPropertyChanged("EventCode");                                
            }
        }

        /// <summary>
        /// Gets or sets the bet amount.
        /// </summary>
        public decimal StakeAmount { get; set; }
        
        /// <summary>
        /// Gets or sets the amount to win or the amount won.
        /// </summary>
        public decimal WinAmount { get; set; }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Runs when a property is changed.
        /// </summary>
        /// <param name="propertyName">The name of property.</param>
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
