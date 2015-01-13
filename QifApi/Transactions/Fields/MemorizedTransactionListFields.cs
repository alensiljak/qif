
namespace QifApi.Transactions.Fields
{
    /// <summary>
    /// The memorized transaction list fields used in transactions.
    /// </summary>
    public static class MemorizedTransactionListFields
    {
        /// <summary>
        /// Check transaction
        /// </summary>
        public const string CheckTransaction = "KC";
        /// <summary>
        /// Deposit transaction
        /// </summary>
        public const string DepositTransaction = "KD";
        /// <summary>
        /// Payment transaction
        /// </summary>
        public const string PaymentTransaction = "KP";
        /// <summary>
        /// Investment transaction
        /// </summary>
        public const string InvestmentTransaction = "KI";
        /// <summary>
        /// Electronic payee transaction
        /// </summary>
        public const string ElectronicPayeeTransaction = "KE";
        /// <summary>
        /// Amount
        /// </summary>
        public const string Amount = "T";
        /// <summary>
        /// Cleared status
        /// </summary>
        public const string ClearedStatus = "C";
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
        /// Category or Transfer/Class
        /// </summary>
        public const string Category = "L";
        /// <summary>
        /// Category/class in split
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
        /// Amortization: First payment date
        /// </summary>
        public const string AmortizationFirstPaymentDate = "1";
        /// <summary>
        /// Amortization: Total years for loan
        /// </summary>
        public const string AmortizationTotalYearsForLoan = "2";
        /// <summary>
        /// Amortization: Number of payments already made
        /// </summary>
        public const string AmortizationNumberOfPaymentsAlreadyMade = "3";
        /// <summary>
        /// Amortization: Number of periods per year
        /// </summary>
        public const string AmortizationNumberOfPeriodsPerYear = "4";
        /// <summary>
        /// Amortization: Interest rate
        /// </summary>
        public const string AmortizationInterestRate = "5";
        /// <summary>
        /// Amortization: Current loan balance
        /// </summary>
        public const string AmortizationCurrentLoanBalance = "6";
        /// <summary>
        /// Amortization: Original loan amount
        /// </summary>
        public const string AmortizationOriginalLoanAmount = "7";
        /// <summary>
        /// End of entry
        /// </summary>
        public const string EndOfEntry = "^";
    }
}
