using QifApi.Transactions;
using QifApi.Transactions.Fields;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace QifApi.Logic
{
    internal static class MemorizedTransactionListLogic
    {
        /// <summary>
        /// Creates a collection of memorized transaction list transactions
        /// </summary>
        /// <param name="transactionItems">The transaction delimited string</param>
        /// <returns>A collection of bank transactions</returns>
        public static List<MemorizedTransactionListTransaction> Import(string transactionItems)
        {
            List<MemorizedTransactionListTransaction> result = new List<MemorizedTransactionListTransaction>();

            // Create a new bank transaction
            MemorizedTransactionListTransaction mtlt = new MemorizedTransactionListTransaction();

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
                        case MemorizedTransactionListFields.Address:
                            // Set the date value
                            mtlt.Address.Add(mtlt.Address.Count, sEntry.Substring(1));

                            // Stop processing
                            break;
                        case MemorizedTransactionListFields.AmortizationCurrentLoanBalance:
                            // Set the amount value
                            mtlt.AmortizationCurrentLoanBalance = Common.GetDecimal(sEntry.Substring(1));

                            // Stop processing
                            break;
                        case MemorizedTransactionListFields.AmortizationFirstPaymentDate:
                            // Set the date value
                            mtlt.AmortizationFirstPaymentDate = Common.GetDateTime(sEntry.Substring(1));

                            // Stop processing
                            break;
                        case MemorizedTransactionListFields.AmortizationInterestRate:
                            // Set the amount value
                            mtlt.AmortizationInterestRate = Common.GetDecimal(sEntry.Substring(1));

                            // Stop processing
                            break;
                        case MemorizedTransactionListFields.AmortizationNumberOfPaymentsAlreadyMade:
                            // Set the date value
                            mtlt.AmortizationNumberOfPaymentsAlreadyMade = Common.GetDecimal(sEntry.Substring(1));

                            // Stop processing
                            break;
                        case MemorizedTransactionListFields.AmortizationNumberOfPeriodsPerYear:
                            // Set the amount value
                            mtlt.AmortizationNumberOfPeriodsPerYear = Common.GetDecimal(sEntry.Substring(1));

                            // Stop processing
                            break;
                        case MemorizedTransactionListFields.AmortizationOriginalLoanAmount:
                            // Set the date value
                            mtlt.AmortizationOriginalLoanAmount = Common.GetDecimal(sEntry.Substring(1));

                            // Stop processing
                            break;
                        case MemorizedTransactionListFields.AmortizationTotalYearsForLoan:
                            // Set the amount value
                            mtlt.AmortizationTotalYearsForLoan = Common.GetDecimal(sEntry.Substring(1));

                            // Stop processing
                            break;
                        case MemorizedTransactionListFields.Amount:
                            // Set the date value
                            mtlt.Amount = Common.GetDecimal(sEntry.Substring(1));

                            // Stop processing
                            break;
                        case MemorizedTransactionListFields.Category:
                            // Set the amount value
                            mtlt.Category = sEntry.Substring(1);

                            // Stop processing
                            break;
                        case MemorizedTransactionListFields.CheckTransaction:
                            // Set the date value
                            mtlt.Type = TransactionType.Check;

                            // Stop processing
                            break;
                        case MemorizedTransactionListFields.ClearedStatus:
                            // Set the amount value
                            mtlt.ClearedStatus = sEntry.Substring(1);

                            // Stop processing
                            break;
                        case MemorizedTransactionListFields.DepositTransaction:
                            // Set the date value
                            mtlt.Type = TransactionType.Deposit;

                            // Stop processing
                            break;
                        case MemorizedTransactionListFields.ElectronicPayeeTransaction:
                            // Set the amount value
                            mtlt.Type = TransactionType.ElectronicPayee;

                            // Stop processing
                            break;
                        case MemorizedTransactionListFields.InvestmentTransaction:
                            // Set the date value
                            mtlt.Type = TransactionType.Investment;

                            // Stop processing
                            break;
                        case MemorizedTransactionListFields.Memo:
                            // Set the amount value
                            mtlt.Memo = sEntry.Substring(1);

                            // Stop processing
                            break;
                        case MemorizedTransactionListFields.Payee:
                            // Set the date value
                            mtlt.Payee = sEntry.Substring(1);

                            // Stop processing
                            break;
                        case MemorizedTransactionListFields.PaymentTransaction:
                            // Set the amount value
                            mtlt.Type = TransactionType.Payment;

                            // Stop processing
                            break;
                        case MemorizedTransactionListFields.SplitAmount:
                            // Set the date value
                            mtlt.SplitAmounts.Add(mtlt.SplitAmounts.Count, Common.GetDecimal(sEntry.Substring(1)));

                            // Stop processing
                            break;
                        case MemorizedTransactionListFields.SplitCategory:
                            // Set the amount value
                            mtlt.SplitCategories.Add(mtlt.SplitCategories.Count, sEntry.Substring(1));

                            // Stop processing
                            break;
                        case MemorizedTransactionListFields.SplitMemo:
                            // Set the amount value
                            // NOTE: Using split amount count because memo is optional
                            mtlt.SplitMemos.Add(mtlt.SplitAmounts.Count, sEntry.Substring(1));

                            // Stop processing
                            break;
                        case AccountInformationFields.EndOfEntry:
                            // Add the bank transaction instance to the collection
                            result.Add(mtlt);

                            // Call the destructor
                            mtlt = null;

                            // Create a new bank transaction
                            mtlt = new MemorizedTransactionListTransaction();

                            // Stop processing
                            break;
                    }
                }
            }

            return result;
        }

        internal static void Export(StreamWriter writer, List<MemorizedTransactionListTransaction> list)
        {
            if ((list != null) && (list.Count > 0))
            {
                writer.WriteLine(Headers.MemorizedTransactionList);

                foreach (MemorizedTransactionListTransaction item in list)
                {
                    foreach (int i in item.Address.Keys)
                    {
                        writer.WriteLine(MemorizedTransactionListFields.Address + item.Address[i]);
                    }

                    writer.WriteLine(MemorizedTransactionListFields.AmortizationCurrentLoanBalance + item.AmortizationCurrentLoanBalance.ToString(CultureInfo.CurrentCulture));

                    writer.WriteLine(MemorizedTransactionListFields.AmortizationFirstPaymentDate + item.AmortizationFirstPaymentDate.ToShortDateString());

                    writer.WriteLine(MemorizedTransactionListFields.AmortizationInterestRate + item.AmortizationInterestRate.ToString(CultureInfo.CurrentCulture));

                    writer.WriteLine(MemorizedTransactionListFields.AmortizationNumberOfPaymentsAlreadyMade + item.AmortizationNumberOfPaymentsAlreadyMade.ToString(CultureInfo.CurrentCulture));

                    writer.WriteLine(MemorizedTransactionListFields.AmortizationNumberOfPeriodsPerYear + item.AmortizationNumberOfPeriodsPerYear.ToString(CultureInfo.CurrentCulture));

                    writer.WriteLine(MemorizedTransactionListFields.AmortizationOriginalLoanAmount + item.AmortizationOriginalLoanAmount.ToString(CultureInfo.CurrentCulture));

                    writer.WriteLine(MemorizedTransactionListFields.AmortizationTotalYearsForLoan + item.AmortizationTotalYearsForLoan.ToString(CultureInfo.CurrentCulture));

                    writer.WriteLine(MemorizedTransactionListFields.Amount + item.Amount.ToString(CultureInfo.CurrentCulture));

                    if (!string.IsNullOrEmpty(item.Category))
                    {
                        writer.WriteLine(MemorizedTransactionListFields.Category + item.Category);
                    }

                    if (!string.IsNullOrEmpty(item.ClearedStatus))
                    {
                        writer.WriteLine(MemorizedTransactionListFields.ClearedStatus + item.ClearedStatus);
                    }

                    if (!string.IsNullOrEmpty(item.Memo))
                    {
                        writer.WriteLine(MemorizedTransactionListFields.Memo + item.Memo);
                    }

                    if (!string.IsNullOrEmpty(item.Payee))
                    {
                        writer.WriteLine(MemorizedTransactionListFields.Payee + item.Payee);
                    }

                    foreach (int i in item.SplitCategories.Keys)
                    {
                        writer.WriteLine(MemorizedTransactionListFields.SplitCategory + item.SplitCategories[i]);
                        writer.WriteLine(MemorizedTransactionListFields.SplitAmount + item.SplitAmounts[i]);

                        if (item.SplitMemos.ContainsKey(i))
                        {
                            writer.WriteLine(MemorizedTransactionListFields.SplitMemo + item.SplitMemos[i]);
                        }
                    }

                    switch (item.Type)
                    {
                        case TransactionType.Check:
                            writer.WriteLine(MemorizedTransactionListFields.CheckTransaction);
                            break;
                        case TransactionType.Deposit:
                            writer.WriteLine(MemorizedTransactionListFields.DepositTransaction);
                            break;
                        case TransactionType.ElectronicPayee:
                            writer.WriteLine(MemorizedTransactionListFields.ElectronicPayeeTransaction);
                            break;
                        case TransactionType.Investment:
                            writer.WriteLine(MemorizedTransactionListFields.InvestmentTransaction);
                            break;
                        case TransactionType.Payment:
                            writer.WriteLine(MemorizedTransactionListFields.PaymentTransaction);
                            break;
                    }
                }
            }
        }
    }
}