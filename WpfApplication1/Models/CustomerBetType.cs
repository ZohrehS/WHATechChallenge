using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Models
{
    /// <summary>
    /// Provides an enumeration for the type of customer bet history.
    /// </summary>
    public enum CustomerBetType
    {
        /// <summary>
        /// Settled bets.
        /// </summary>
        Settled = 0,

        /// <summary>
        /// Unsettled bets.
        /// </summary>
        Unsettled = 1
    }
}
