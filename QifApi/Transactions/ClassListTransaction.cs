
namespace QifApi.Transactions
{
    /// <summary>
    /// A class list transaction.
    /// </summary>
    public class ClassListTransaction : TransactionBase
    {
        /// <summary>
        /// Gets or sets the name of the class.
        /// </summary>
        /// <value>The name of the class.</value>
        public string ClassName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassListTransaction"/> class.
        /// </summary>
        public ClassListTransaction()
        {
            ClassName = "";
            Description = "";
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return this.ClassName;
        }
    }
}
