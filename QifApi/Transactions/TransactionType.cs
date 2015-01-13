
namespace QifApi.Transactions
{
    /// <summary>
    /// Memorized transaction types.
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// A check transaction type.
        /// </summary>
        Check,
        /// <summary>
        /// A deposit transaction type.
        /// </summary>
        Deposit,
        /// <summary>
        /// A payment transaction type.
        /// </summary>
        Payment,
        /// <summary>
        /// An investment transaction type.
        /// </summary>
        Investment,
        /// <summary>
        /// An electronic payee transaction type.
        /// </summary>
        ElectronicPayee
    }
}
