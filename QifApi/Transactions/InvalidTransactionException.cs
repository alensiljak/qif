using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace QifApi.Transactions
{
    /// <summary>
    /// Used to describe an invalid transaction.
    /// </summary>
    [Serializable]
    public class InvalidTransactionException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTransactionException"/> class.
        /// </summary>
        public InvalidTransactionException()
            : this(null, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTransactionException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public InvalidTransactionException(string message)
            : this(message, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTransactionException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public InvalidTransactionException(string message, Exception innerException)
            : this(message, innerException, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the System.Exception class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected InvalidTransactionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                foreach (var member in info)
                {
                    if (member.Name == "Transaction")
                    {
                        Transaction = member.Value as TransactionBase;
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTransactionException"/> class.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        public InvalidTransactionException(TransactionBase transaction)
            : this(string.Format(CultureInfo.CurrentCulture, Resources.InvalidBankTransaction, transaction), transaction)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTransactionException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="transaction">The transaction.</param>
        public InvalidTransactionException(string message, TransactionBase transaction)
            : this(message, null, transaction)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTransactionException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="transaction">The transaction.</param>
        public InvalidTransactionException(string message, Exception innerException, TransactionBase transaction)
            : base(message, innerException)
        {
            Transaction = transaction;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("Transaction", Transaction);
        }

        /// <summary>
        /// Gets the transaction.
        /// </summary>
        /// <value>The transaction.</value>
        public TransactionBase Transaction
        {
            get;
            private set;
        }
    }
}
