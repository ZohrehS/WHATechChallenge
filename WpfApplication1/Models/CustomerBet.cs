using System.ComponentModel;

namespace WpfApplication1.Models
{
    /// <summary>
    /// Provides a model for customer bets history.
    /// </summary>
    public class CustomerBet : NotificationObject
    {
        #region Fields
        private CustomerBetType _type;
        private int _customerId;
        private int _eventCode;
        private int _participantCode;
        private decimal _stakeAmount;
        private decimal _winAmount;
        private RiskSeverity _riskyUnsettledBetSeverity;

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
                OnPropertyChanged("ParticipantCode");                                
            }
        }

        /// <summary>
        /// Gets or sets the bet amount.
        /// </summary>
        public decimal StakeAmount
        {
            get { return _stakeAmount; }
            set
            {
                _stakeAmount = value;
                OnPropertyChanged("StakeAmount");          
            }
        }

        /// <summary>
        /// Gets or sets the amount to win or the amount won.
        /// </summary>
        public decimal WinAmount
        {
            get { return _winAmount; }
            set
            {
                _winAmount = value;
                OnPropertyChanged("WinAmount");                          
            }
        }

        /// <summary>
        /// Gets or sets the risk level of an unsettled bet.
        /// </summary>
        public RiskSeverity RiskyUnsettledBetSeverity
        {
            get { return _riskyUnsettledBetSeverity; }
            set
            {
                _riskyUnsettledBetSeverity = value;
                OnPropertyChanged("RiskyUnsettledBetSeverity");
            }
        }

        #endregion
    }
}
