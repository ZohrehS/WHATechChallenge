using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Models
{
    /// <summary>
    /// Provides an enumeration for risk severity.
    /// </summary>
    public enum RiskSeverity
    {
        /// <summary>
        /// Risky.
        /// </summary>
        Risky = 1,

        /// <summary>
        /// Unusual.
        /// </summary>
        Unusual = 2,

        /// <summary>
        /// Highly Unusual.
        /// </summary>
        HighlyUnusual=3,

        /// <summary>
        /// won amount is more than 1000$.
        /// </summary>
        HighWonAmount = 4
    }
}
