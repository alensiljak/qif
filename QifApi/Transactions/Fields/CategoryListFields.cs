
namespace QifApi.Transactions.Fields
{
    /// <summary>
    /// The category list fields used in transactions.
    /// </summary>
    public static class CategoryListFields
    {
        /// <summary>
        /// Category name:subcategory name
        /// </summary>
        public const string CategoryName = "N";
        /// <summary>
        /// Description
        /// </summary>
        public const string Description = "D";
        /// <summary>
        /// Tax related if included, not tax related if omitted
        /// </summary>
        public const string TaxRelated = "T";
        /// <summary>
        /// Income category
        /// </summary>
        public const string IncomeCategory = "I";
        /// <summary>
        /// If category is unspecified, assume expense type
        /// </summary>
        public const string ExpenseCategory = "E";
        /// <summary>
        /// Only in a Budget Amounts QIF file
        /// </summary>
        public const string BudgetAmount = "B";
        /// <summary>
        /// Tax schedule information
        /// </summary>
        public const string TaxSchedule = "R";
        /// <summary>
        /// End of entry
        /// </summary>
        public const string EndOfEntry = "^";
    }
}
