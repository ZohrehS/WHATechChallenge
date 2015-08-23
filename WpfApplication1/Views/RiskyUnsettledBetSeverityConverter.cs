using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using WpfApplication1.Models;

namespace WpfApplication1.Views
{
    public class RiskyUnsettledBetSeverityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            RiskSeverity severity;
            if (value != null && Enum.TryParse(value.ToString(), out severity))
            {
                switch (severity)
                {
                    case RiskSeverity.Risky:
                        return new SolidColorBrush(Colors.DarkOrange);
                    case RiskSeverity.Unusual:
                        return new SolidColorBrush(Colors.Yellow);
                    case RiskSeverity.HighlyUnusual:
                        return new SolidColorBrush(Colors.DarkRed);
                    case RiskSeverity.HighWonAmount:
                        return new SolidColorBrush(Colors.DarkSalmon);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
