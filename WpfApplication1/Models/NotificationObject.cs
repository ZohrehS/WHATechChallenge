using System.ComponentModel;

namespace WpfApplication1.Models
{
    /// <summary>
    /// Provides a parent class for any notification object.
    /// </summary>
    public class NotificationObject : INotifyPropertyChanged
    {
        #region Fields
        public event PropertyChangedEventHandler PropertyChanged;
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
