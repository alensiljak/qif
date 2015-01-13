using QifApi.Transactions;
using QifApi.Transactions.Fields;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace QifApi.Logic
{
    internal static class AssetLogic
    {
        /// <summary>
        /// Creates a collection of asset transactions
        /// </summary>
        /// <param name="transactionItems">The transaction delimited string</param>
        /// <returns>A collection of bank transactions</returns>
        internal static List<BasicTransaction> Import(string transactionItems)
        {
            List<BasicTransaction> result = new List<BasicTransaction>();

            // Create a new bank transaction
            BasicTransaction at = new BasicTransaction();

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
                        case NonInvestmentAccountFields.Date:
                            // Set the date value
                            at.Date = Common.GetDateTime(sEntry.Substring(1));

                            // Stop processing
                            break;
                        case NonInvestmentAccountFields.Amount:
                            // Set the amount value
                            at.Amount = Common.GetDecimal(sEntry.Substring(1));

                            // Stop processing
                            break;
                        case NonInvestmentAccountFields.ClearedStatus:
                            // Set the cleared status value
                            at.ClearedStatus = sEntry.Substring(1);

                            // Stop processing
                            break;
                        case NonInvestmentAccountFields.Number:
                            // Set the number value
                            at.Number = sEntry.Substring(1);

                            // Stop processing
                            break;
                        case NonInvestmentAccountFields.Payee:
                            // Set the payee value
                            at.Payee = sEntry.Substring(1);

                            // Stop processing
                            break;
                        case NonInvestmentAccountFields.Memo:
                            // Set the memo value
                            at.Memo = sEntry.Substring(1);

                            // Stop processing
                            break;
                        case NonInvestmentAccountFields.Category:
                            // Set the category value
                            at.Category = sEntry.Substring(1);

                            // Stop processing
                            break;
                        case NonInvestmentAccountFields.Address:
                            // Add the address line value
                            at.Address.Add(at.Address.Count, sEntry.Substring(1));

                            // Stop processing
                            break;
                        case NonInvestmentAccountFields.SplitCategory:
                            // Add the split category value
                            at.SplitCategories.Add(at.SplitCategories.Count, sEntry.Substring(1));

                            // Stop processing
                            break;
                        case NonInvestmentAccountFields.SplitMemo:
                            // Add the split memo value
                            // NOTE: I use split amount count because memos are optional
                            at.SplitMemos.Add(at.SplitAmounts.Count, sEntry.Substring(1));

                            // Stop processing
                            break;
                        case NonInvestmentAccountFields.SplitAmount:
                            // Add the split amount value
                            at.SplitAmounts.Add(at.SplitAmounts.Count, Common.GetDecimal(sEntry.Substring(1)));

                            // Stop processing
                            break;
                        case NonInvestmentAccountFields.EndOfEntry:
                            // Add the bank transaction instance to the collection
                            result.Add(at);

                            // Call the destructor
                            at = null;

                            // Create a new bank transaction
                            at = new BasicTransaction();

                            // Stop processing
                            break;
                    }
                }
            }

            return result;
        }

        internal static void Export(StreamWriter writer, List<BasicTransaction> list)
        {
            if ((list != null) && (list.Count > 0))
            {
                writer.WriteLine(Headers.Asset);

                foreach (BasicTransaction item in list)
                {
                    writer.WriteLine(NonInvestmentAccountFields.Date + item.Date.ToShortDateString());

                    foreach (int i in item.Address.Keys)
                    {
                        writer.WriteLine(NonInvestmentAccountFields.Address + item.Address[i]);
                    }

                    writer.WriteLine(NonInvestmentAccountFields.Amount + item.Amount.ToString(CultureInfo.CurrentCulture));

                    if (!string.IsNullOrEmpty(item.Category))
                    {
                        writer.WriteLine(NonInvestmentAccountFields.Category + item.Category);
                    }

                    if (!string.IsNullOrEmpty(item.ClearedStatus))
                    {
                        writer.WriteLine(NonInvestmentAccountFields.ClearedStatus + item.ClearedStatus);
                    }

                    if (!string.IsNullOrEmpty(item.Memo))
                    {
                        writer.WriteLine(NonInvestmentAccountFields.Memo + item.Memo);
                    }

                    if (!string.IsNullOrEmpty(item.Number))
                    {
                        writer.WriteLine(NonInvestmentAccountFields.Number + item.Number);
                    }

                    if (!string.IsNullOrEmpty(item.Payee))
                    {
                        writer.WriteLine(NonInvestmentAccountFields.Payee + item.Payee);
                    }

                    foreach (int i in item.SplitCategories.Keys)
                    {
                        writer.WriteLine(NonInvestmentAccountFields.SplitCategory + item.SplitCategories[i]);
                        writer.WriteLine(NonInvestmentAccountFields.SplitAmount + item.SplitAmounts[i]);

                        if (item.SplitMemos.ContainsKey(i))
                        {
                            writer.WriteLine(NonInvestmentAccountFields.SplitMemo + item.SplitMemos[i]);
                        }
                    }

                    writer.WriteLine(NonInvestmentAccountFields.EndOfEntry);
                }
            }
        }
    }
}