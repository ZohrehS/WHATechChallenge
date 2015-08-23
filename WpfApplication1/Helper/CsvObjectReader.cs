using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WpfApplication1.Models;

namespace WpfApplication1.Helper
{
    /// <summary>
    /// Provides a helper to read objects from CSV file. 
    /// </summary>
    public class CsvObjectReader
    {
        /// <summary>
        /// Reads a CSV file and gets a list of customer bets.
        /// </summary>
        /// <param name="filePath">the file path.</param>
        /// <returns>A list of customer bets.</returns>
        public static List<CustomerBet> GetCustomerBets(string filePath)
        {
            var result = new List<CustomerBet>();
            try
            {
                using (var sr = new StreamReader(filePath))
                {
                    // skip the header
                    sr.ReadLine();

                    string currentLine;
                    // currentLine will be null when the StreamReader reaches the end of file
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        var splittedStrings = currentLine.Split(',');
                        if (splittedStrings.Count() >= 5)
                        {
                            int customerId, eventCode, participantCode;
                            decimal stake, win;
                            
                            if (int.TryParse(splittedStrings[0], out customerId) && int.TryParse(splittedStrings[1], out eventCode) &&
                                int.TryParse(splittedStrings[2], out participantCode) && decimal.TryParse(splittedStrings[3], out stake) &&
                                decimal.TryParse(splittedStrings[4], out win))
                            {
                                // if conversion is successful then add the current customer bet
                                var currentCustomerBet = new CustomerBet
                                {
                                    CustomerId = customerId,
                                    EventCode = eventCode,
                                    ParticipantCode = participantCode,
                                    StakeAmount = stake,
                                    WinAmount = win
                                };

                                result.Add(currentCustomerBet);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // ignored
            }

            return result;
        }
    }
}
