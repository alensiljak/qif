using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using QifApi.Transactions;
using QifApi.Transactions.Fields;

namespace QifApi.Logic
{
    internal static class ClassListLogic
    {
        /// <summary>
        /// Creates a collection of class list transactions
        /// </summary>
        /// <param name="transactionItems">The transaction delimited string</param>
        /// <returns>A collection of bank transactions</returns>
        public static List<ClassListTransaction> Import(string transactionItems)
        {
            List<ClassListTransaction> result = new List<ClassListTransaction>();

            // Create a new bank transaction
            ClassListTransaction clt = new ClassListTransaction();

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
                        case ClassListFields.ClassName:
                            // Set the date value
                            clt.ClassName = sEntry.Substring(1);

                            // Stop processing
                            break;
                        case ClassListFields.Description:
                            // Set the amount value
                            clt.Description = sEntry.Substring(1);

                            // Stop processing
                            break;
                        case AccountInformationFields.EndOfEntry:
                            // Add the bank transaction instance to the collection
                            result.Add(clt);

                            // Call the destructor
                            clt = null;

                            // Create a new bank transaction
                            clt = new ClassListTransaction();

                            // Stop processing
                            break;
                    }
                }
            }

            return result;
        }

        internal static void Export(StreamWriter writer, List<ClassListTransaction> list)
        {
            if ((list != null) && (list.Count > 0))
            {
                writer.WriteLine(Headers.ClassList);

                foreach (ClassListTransaction item in list)
                {
                    if (!string.IsNullOrEmpty(item.ClassName))
                    {
                        writer.WriteLine(ClassListFields.ClassName + item.ClassName);
                    }

                    if (!string.IsNullOrEmpty(item.Description))
                    {
                        writer.WriteLine(ClassListFields.Description + item.Description);
                    }

                    writer.WriteLine(ClassListFields.EndOfEntry);
                }
            }
        }
    }
}
