using QifApi.Transactions;
using QifApi.Transactions.Fields;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace QifApi.Logic
{
    internal static class InvestmentLogic
    {
        /// <summary>
        /// Creates a collection of investment transactions
        /// </summary>
        /// <param name="transactionItems">The transaction delimited string</param>
        /// <returns>A collection of bank transactions</returns>
        public static List<InvestmentTransaction> Import(string transactionItems)
        {
            List<InvestmentTransaction> result = new List<InvestmentTransaction>();

            // Create a new bank transaction
            InvestmentTransaction it = new InvestmentTransaction();

            // Split the string by new lines
            string[] sEntries = Regex.Split(transactionItems, "$", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);

            // Iterate over the array
            for (int i = 0; i < sEntries.Length; i++)
            {
                // Extract a line entry
                string sEntry = sEntries[i].Replace("\r", "").Replace("\n", "");

                // If the string has a value
                if (sEntry.Length > 0)
                {
                    // Test the first value of the string
                    switch (sEntry[0].ToString())
                    {
                        case InvestmentAccountFields.Action:
                            // Set the date value
                            it.Action = sEntry.Substring(1);

                            // Stop processing
                            break;
                        case InvestmentAccountFields.ClearedStatus:
                            // Set the amount value
                            it.ClearedStatus = sEntry.Substring(1);

                            // Stop processing
                            break;
                        case InvestmentAccountFields.Commission:
                            // Set the cleared status value
                            it.Commission = Common.GetDecimal(sEntry.Substring(1));

                            // Stop processing
                            break;
                        case InvestmentAccountFields.Date:
                            // Set the number value
                            it.Date = Common.GetDateTime(sEntry.Substring(1));

                            // Stop processing
                            break;
                        case InvestmentAccountFields.Memo:
                            // Set the payee value
                            it.Memo = sEntry.Substring(1);

                            // Stop processing
                            break;
                        case InvestmentAccountFields.Price:
                            // Set the memo value
                            it.Price = Common.GetDecimal(sEntry.Substring(1));

                            // Stop processing
                            break;
                        case InvestmentAccountFields.Quantity:
                            // Set the memo value
                            it.Quantity = Common.GetDecimal(sEntry.Substring(1));

                            // Stop processing
                            break;
                        case InvestmentAccountFields.Security:
                            // Set the memo value
                            it.Security = sEntry.Substring(1);

                            // Stop processing
                            break;
                        case InvestmentAccountFields.TextFirstLine:
                            // Set the memo value
                            it.TextFirstLine = sEntry.Substring(1);

                            // Stop processing
                            break;
                        case InvestmentAccountFields.TransactionAmount:
                            // Set the memo value
                            it.TransactionAmount = Common.GetDecimal(sEntry.Substring(1));

                            // Stop processing
                            break;
                        case InvestmentAccountFields.AccountForTransfer:
                            // Set the memo value
                            it.AccountForTransfer = sEntry.Substring(1);

                            // Stop processing
                            break;
                        case InvestmentAccountFields.AmountTransferred:
                            // Set the memo value
                            it.AmountTransferred = Common.GetDecimal(sEntry.Substring(1));

                            // Stop processing
                            break;
                        case AccountInformationFields.EndOfEntry:
                            // Add the bank transaction instance to the collection
                            result.Add(it);

                            // Call the destructor
                            it = null;

                            // Create a new bank transaction
                            it = new InvestmentTransaction();

                            // Stop processing
                            break;
                    }
                }
            }

            return result;
        }

        internal static void Export(StreamWriter writer, List<InvestmentTransaction> list)
        {
            if ((list != null) && (list.Count > 0))
            {
                writer.WriteLine(Headers.Investment);

                foreach (InvestmentTransaction item in list)
                {
                    if (!string.IsNullOrEmpty(item.AccountForTransfer))
                    {
                        writer.WriteLine(InvestmentAccountFields.AccountForTransfer + item.AccountForTransfer);
                    }

                    if (!string.IsNullOrEmpty(item.Action))
                    {
                        writer.WriteLine(InvestmentAccountFields.Action + item.Action);
                    }

                    writer.WriteLine(InvestmentAccountFields.AmountTransferred + item.AmountTransferred.ToString(CultureInfo.CurrentCulture));

                    if (!string.IsNullOrEmpty(item.ClearedStatus))
                    {
                        writer.WriteLine(InvestmentAccountFields.ClearedStatus + item.ClearedStatus);
                    }

                    writer.WriteLine(InvestmentAccountFields.Commission + item.Commission.ToString(CultureInfo.CurrentCulture));

                    writer.WriteLine(InvestmentAccountFields.Date + item.Date.ToShortDateString());

                    if (!string.IsNullOrEmpty(item.Memo))
                    {
                        writer.WriteLine(InvestmentAccountFields.Memo + item.Memo);
                    }
                    writer.WriteLine(InvestmentAccountFields.Price + item.Price.ToString(CultureInfo.CurrentCulture));

                    writer.WriteLine(InvestmentAccountFields.Quantity + item.Quantity.ToString(CultureInfo.CurrentCulture));

                    if (!string.IsNullOrEmpty(item.Security))
                    {
                        writer.WriteLine(InvestmentAccountFields.Security + item.Security);
                    }

                    if (!string.IsNullOrEmpty(item.TextFirstLine))
                    {
                        writer.WriteLine(InvestmentAccountFields.TextFirstLine + item.TextFirstLine);
                    }

                    writer.WriteLine(InvestmentAccountFields.TransactionAmount + item.TransactionAmount.ToString(CultureInfo.CurrentCulture));

                    writer.WriteLine(InvestmentAccountFields.EndOfEntry);
                }
            }
        }
    }
}