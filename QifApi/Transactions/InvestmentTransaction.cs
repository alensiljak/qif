using System;
using System.Globalization;

namespace QifApi.Transactions
{
    /// <summary>
    /// An investment transaction.
    /// </summary>
    public class InvestmentTransaction : TransactionBase
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public DateTime Date
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>The action.</value>
        public string Action
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the security.
        /// </summary>
        /// <value>The security.</value>
        public string Security
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public decimal Price
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public decimal Quantity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the transaction amount.
        /// </summary>
        /// <value>The transaction amount.</value>
        public decimal TransactionAmount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the cleared status.
        /// </summary>
        /// <value>The cleared status.</value>
        public string ClearedStatus
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the text first line.
        /// </summary>
        /// <value>The text first line.</value>
        public string TextFirstLine
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the memo.
        /// </summary>
        /// <value>The memo.</value>
        public string Memo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the commission.
        /// </summary>
        /// <value>The commission.</value>
        public decimal Commission
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the account for transfer.
        /// </summary>
        /// <value>The account for transfer.</value>
        public string AccountForTransfer
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the amount transferred.
        /// </summary>
        /// <value>The amount transferred.</value>
        public decimal AmountTransferred
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvestmentTransaction"/> class.
        /// </summary>
        public InvestmentTransaction()
        {
            Action = "";
            Security = "";
            ClearedStatus = "";
            TextFirstLine = "";
            Memo = "";
            AccountForTransfer = "";
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format(Resources.Culture, Resources.InvestmentTransactionDisplay, this.Date.ToString("d", CultureInfo.CurrentCulture), this.TextFirstLine, this.TransactionAmount.ToString("C2", CultureInfo.CurrentCulture));
        }
    }
}
