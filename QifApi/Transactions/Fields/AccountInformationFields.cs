
namespace QifApi.Transactions.Fields
{
    /// <summary>
    /// The account information fields used in transactions.
    /// </summary>
    public static class AccountInformationFields
    {
        /// <summary>
        /// Name
        /// </summary>
        public const string Name = "N";
        /// <summary>
        /// Type of account
        /// </summary>
        public const string AccountType = "T";
        /// <summary>
        /// Description
        /// </summary>
        public const string Description = "D";
        /// <summary>
        /// Only for credit card account
        /// </summary>
        public const string CreditLimit = "L";
        /// <summary>
        /// Statement balance date
        /// </summary>
        public const string StatementBalanceDate = "/";
        /// <summary>
        /// Statement balance
        /// </summary>
        public const string StatementBalance = "$";
        /// <summary>
        /// End of entry
        /// </summary>
        public const string EndOfEntry = "^";
    }
}
