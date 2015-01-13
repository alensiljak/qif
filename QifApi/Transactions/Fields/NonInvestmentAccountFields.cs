
namespace QifApi.Transactions.Fields
{
    /// <summary>
    /// The non-investment account fields used in transactions.
    /// </summary>
    public static class NonInvestmentAccountFields
    {
        /// <summary>
        /// Date
        /// </summary>
        public const string Date = "D";
        /// <summary>
        /// Amount
        /// </summary>
        public const string Amount = "T";
        /// <summary>
        /// Cleared status
        /// </summary>
        public const string ClearedStatus = "C";
        /// <summary>
        /// Check, reference number, or transaction type
        /// </summary>
        public const string Number = "N";
        /// <summary>
        /// Payee
        /// </summary>
        public const string Payee = "P";
        /// <summary>
        /// Memo
        /// </summary>
        public const string Memo = "M";
        /// <summary>
        /// Up to five lines; the sixth line is an optional message
        /// </summary>
        public const string Address = "A";
        /// <summary>
        /// Category/Subcategory/Transfer/Class
        /// </summary>
        public const string Category = "L";
        /// <summary>
        /// Category/Transfer/Class
        /// </summary>
        public const string SplitCategory = "S";
        /// <summary>
        /// Memo in split
        /// </summary>
        public const string SplitMemo = "E";
        /// <summary>
        /// Dollar amount of split
        /// </summary>
        public const string SplitAmount = "$";
        /// <summary>
        /// End of entry
        /// </summary>
        public const string EndOfEntry = "^";
    }
}
