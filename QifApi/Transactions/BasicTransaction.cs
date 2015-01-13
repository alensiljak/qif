using System;
using System.Collections.Generic;
using System.Globalization;

namespace QifApi.Transactions
{
    /// <summary>
    /// A basic transaction. It is used to describe non-investment transactions.
    /// </summary>
    public class BasicTransaction : TransactionBase
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
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal Amount
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
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        public string Number
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the payee.
        /// </summary>
        /// <value>The payee.</value>
        public string Payee
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
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        public string Category
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public SortedList<int, string> Address
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the split categories.
        /// </summary>
        /// <value>The split categories.</value>
        public SortedList<int, string> SplitCategories
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the split memos.
        /// </summary>
        /// <value>The split memos.</value>
        public SortedList<int, string> SplitMemos
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the split amounts.
        /// </summary>
        /// <value>The split amounts.</value>
        public SortedList<int, decimal> SplitAmounts
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicTransaction"/> class.
        /// </summary>
        public BasicTransaction()
        {
            ClearedStatus = "";
            Number = "";
            Payee = "";
            Memo = "";
            Category = "";
            Address = new SortedList<int, string>();
            SplitCategories = new SortedList<int, string>();
            SplitMemos = new SortedList<int, string>();
            SplitAmounts = new SortedList<int, decimal>();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format(Resources.Culture, Resources.BasicTransactionDisplay, this.Date.ToString("d", CultureInfo.CurrentCulture), this.Payee, this.Amount.ToString("C2", CultureInfo.CurrentCulture));
        }
    }
}