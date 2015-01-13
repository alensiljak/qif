
namespace QifApi.Transactions.Fields
{
    /// <summary>
    /// The investment account fields used in transactions.
    /// </summary>
    public static class InvestmentAccountFields
    {
        /// <summary>
        /// Date
        /// </summary>
        public const string Date = "D";
        /// <summary>
        /// Action
        /// </summary>
        public const string Action = "N";
        /// <summary>
        /// Security
        /// </summary>
        public const string Security = "Y";
        /// <summary>
        /// Price
        /// </summary>
        public const string Price = "I";
        /// <summary>
        /// Number of shares or split ratio
        /// </summary>
        public const string Quantity = "Q";
        /// <summary>
        /// Transaction amount
        /// </summary>
        public const string TransactionAmount = "T";
        /// <summary>
        /// Cleared status
        /// </summary>
        public const string ClearedStatus = "C";
        /// <summary>
        /// Text in the first line for transfers and reminders
        /// </summary>
        public const string TextFirstLine = "P";
        /// <summary>
        /// Memo
        /// </summary>
        public const string Memo = "M";
        /// <summary>
        /// Commission
        /// </summary>
        public const string Commission = "O";
        /// <summary>
        /// Account for the transfer
        /// </summary>
        public const string AccountForTransfer = "L";
        /// <summary>
        /// Amount transferred
        /// </summary>
        public const string AmountTransferred = "$";
        /// <summary>
        /// End of entry
        /// </summary>
        public const string EndOfEntry = "^";
    }
}
