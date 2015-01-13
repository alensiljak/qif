using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;
using QifApi.Transactions;

namespace QifApi
{
    /// <summary>
    /// The QIF DOM COM interface.
    /// </summary>
    [Guid("8B4FB99B-D6CD-4582-8902-F36BB66D0965")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IQifDomComWrapper
    {
        /// <summary>
        /// Gets or sets the QIF DOM.
        /// </summary>
        /// <value>The QIF DOM.</value>
        [DispId(1)]
        QifDom QifDom
        {
            get;
            set;
        }
        /// <summary>
        /// Imports the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        [DispId(2)]
        void Import(string fileName);
        /// <summary>
        /// Exports the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        [DispId(3)]
        void Export(string fileName);
        /// <summary>
        /// Gets the bank transactions.
        /// </summary>
        /// <value>The bank transactions.</value>
        [DispId(4)]
        ArrayList BankTransactions
        {
            get;
        }
        /// <summary>
        /// Gets the cash transactions.
        /// </summary>
        /// <value>The cash transactions.</value>
        [DispId(5)]
        ArrayList CashTransactions
        {
            get;
        }
        /// <summary>
        /// Gets the credit card transactions.
        /// </summary>
        /// <value>The credit card transactions.</value>
        [DispId(6)]
        ArrayList CreditCardTransactions
        {
            get;
        }
        /// <summary>
        /// Gets the investment transactions.
        /// </summary>
        /// <value>The investment transactions.</value>
        [DispId(7)]
        ArrayList InvestmentTransactions
        {
            get;
        }
        /// <summary>
        /// Gets the asset transactions.
        /// </summary>
        /// <value>The asset transactions.</value>
        [DispId(8)]
        ArrayList AssetTransactions
        {
            get;
        }
        /// <summary>
        /// Gets the liability transactions.
        /// </summary>
        /// <value>The liability transactions.</value>
        [DispId(9)]
        ArrayList LiabilityTransactions
        {
            get;
        }
        /// <summary>
        /// Gets the account list transactions.
        /// </summary>
        /// <value>The account list transactions.</value>
        [DispId(10)]
        ArrayList AccountListTransactions
        {
            get;
        }
        /// <summary>
        /// Gets the category list transactions.
        /// </summary>
        /// <value>The category list transactions.</value>
        [DispId(11)]
        ArrayList CategoryListTransactions
        {
            get;
        }
        /// <summary>
        /// Gets the class list transactions.
        /// </summary>
        /// <value>The class list transactions.</value>
        [DispId(12)]
        ArrayList ClassListTransactions
        {
            get;
        }
        /// <summary>
        /// Gets the memorized transaction list transactions.
        /// </summary>
        /// <value>The memorized transaction list transactions.</value>
        [DispId(13)]
        ArrayList MemorizedTransactionListTransactions
        {
            get;
        }
    }

    /// <summary>
    /// This class is provided for the sole purpose of accessing other parts of this assembly via COM.
    /// </summary>
    [Guid("F30BB5BC-606F-438B-AE06-D0D5638FFAC7")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("QifApi.QifDomComWrapper")]
    public class QifDomComWrapper : IQifDomComWrapper
    {
        private ArrayList _BankTransactions;
        private ArrayList _CashTransactions;
        private ArrayList _CreditCardTransactions;
        private ArrayList _InvestmentTransactions;
        private ArrayList _AssetTransactions;
        private ArrayList _LiabilityTransactions;
        private ArrayList _AccountListTransactions;
        private ArrayList _CategoryListTransactions;
        private ArrayList _ClassListTransactions;
        private ArrayList _MemorizedTransactionListTransactions;

        /// <summary>
        /// Gets or sets the QIF DOM.
        /// </summary>
        /// <value>The QIF DOM.</value>
        [DispId(1)]
        public QifDom QifDom
        {
            get;
            set;
        }

        /// <summary>
        /// Imports the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        [DispId(2)]
        public void Import(string fileName)
        {
            QifDom = QifApi.QifDom.ImportFile(fileName);

            _BankTransactions = new ArrayList(QifDom.BankTransactions);
            _CashTransactions = new ArrayList(QifDom.CashTransactions);
            _CreditCardTransactions = new ArrayList(QifDom.CreditCardTransactions);
            _InvestmentTransactions = new ArrayList(QifDom.InvestmentTransactions);
            _AssetTransactions = new ArrayList(QifDom.AssetTransactions);
            _LiabilityTransactions = new ArrayList(QifDom.LiabilityTransactions);
            _AccountListTransactions = new ArrayList(QifDom.AccountListTransactions);
            _CategoryListTransactions = new ArrayList(QifDom.CategoryListTransactions);
            _ClassListTransactions = new ArrayList(QifDom.ClassListTransactions);
            _MemorizedTransactionListTransactions = new ArrayList(QifDom.MemorizedTransactionListTransactions);
        }

        /// <summary>
        /// Exports the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        [DispId(3)]
        public void Export(string fileName)
        {
            QifDom.BankTransactions = new List<BasicTransaction>(_BankTransactions.Cast<BasicTransaction>());
            QifDom.CashTransactions = new List<BasicTransaction>(_CashTransactions.Cast<BasicTransaction>());
            QifDom.CreditCardTransactions = new List<BasicTransaction>(_CreditCardTransactions.Cast<BasicTransaction>());
            QifDom.InvestmentTransactions = new List<InvestmentTransaction>(_InvestmentTransactions.Cast<InvestmentTransaction>());
            QifDom.AssetTransactions = new List<BasicTransaction>(_AssetTransactions.Cast<BasicTransaction>());
            QifDom.LiabilityTransactions = new List<BasicTransaction>(_LiabilityTransactions.Cast<BasicTransaction>());
            QifDom.AccountListTransactions = new List<AccountListTransaction>(_AccountListTransactions.Cast<AccountListTransaction>());
            QifDom.CategoryListTransactions = new List<CategoryListTransaction>(_CategoryListTransactions.Cast<CategoryListTransaction>());
            QifDom.ClassListTransactions = new List<ClassListTransaction>(_ClassListTransactions.Cast<ClassListTransaction>());
            QifDom.MemorizedTransactionListTransactions = new List<MemorizedTransactionListTransaction>(_MemorizedTransactionListTransactions.Cast<MemorizedTransactionListTransaction>());

            QifDom.Export(fileName);
        }

        /// <summary>
        /// Gets the bank transactions.
        /// </summary>
        /// <value>The bank transactions.</value>
        [DispId(4)]
        public ArrayList BankTransactions
        {
            get
            {
                QifDom.BankTransactions = new List<BasicTransaction>(_BankTransactions.Cast<BasicTransaction>());
                return _BankTransactions;
            }
        }

        /// <summary>
        /// Gets the cash transactions.
        /// </summary>
        /// <value>The cash transactions.</value>
        [DispId(5)]
        public ArrayList CashTransactions
        {
            get
            {
                QifDom.CashTransactions = new List<BasicTransaction>(_CashTransactions.Cast<BasicTransaction>());
                return _CashTransactions;
            }
        }

        /// <summary>
        /// Gets the credit card transactions.
        /// </summary>
        /// <value>The credit card transactions.</value>
        [DispId(6)]
        public ArrayList CreditCardTransactions
        {
            get
            {
                QifDom.CreditCardTransactions = new List<BasicTransaction>(_CreditCardTransactions.Cast<BasicTransaction>());
                return _CreditCardTransactions;
            }
        }

        /// <summary>
        /// Gets the investment transactions.
        /// </summary>
        /// <value>The investment transactions.</value>
        [DispId(7)]
        public ArrayList InvestmentTransactions
        {
            get
            {
                QifDom.InvestmentTransactions = new List<InvestmentTransaction>(_InvestmentTransactions.Cast<InvestmentTransaction>());
                return _InvestmentTransactions;
            }
        }

        /// <summary>
        /// Gets the asset transactions.
        /// </summary>
        /// <value>The asset transactions.</value>
        [DispId(8)]
        public ArrayList AssetTransactions
        {
            get
            {
                QifDom.AssetTransactions = new List<BasicTransaction>(_AssetTransactions.Cast<BasicTransaction>());
                return _AssetTransactions;
            }
        }

        /// <summary>
        /// Gets the liability transactions.
        /// </summary>
        /// <value>The liability transactions.</value>
        [DispId(9)]
        public ArrayList LiabilityTransactions
        {
            get
            {
                QifDom.LiabilityTransactions = new List<BasicTransaction>(_LiabilityTransactions.Cast<BasicTransaction>());
                return _LiabilityTransactions;
            }
        }

        /// <summary>
        /// Gets the account list transactions.
        /// </summary>
        /// <value>The account list transactions.</value>
        [DispId(10)]
        public ArrayList AccountListTransactions
        {
            get
            {
                QifDom.AccountListTransactions = new List<AccountListTransaction>(_AccountListTransactions.Cast<AccountListTransaction>());
                return _AccountListTransactions;
            }
        }

        /// <summary>
        /// Gets the category list transactions.
        /// </summary>
        /// <value>The category list transactions.</value>
        [DispId(11)]
        public ArrayList CategoryListTransactions
        {
            get
            {
                QifDom.CategoryListTransactions = new List<CategoryListTransaction>(_CategoryListTransactions.Cast<CategoryListTransaction>());
                return _CategoryListTransactions;
            }
        }

        /// <summary>
        /// Gets the class list transactions.
        /// </summary>
        /// <value>The class list transactions.</value>
        [DispId(12)]
        public ArrayList ClassListTransactions
        {
            get
            {
                QifDom.ClassListTransactions = new List<ClassListTransaction>(_ClassListTransactions.Cast<ClassListTransaction>());
                return _ClassListTransactions;
            }
        }

        /// <summary>
        /// Gets the memorized transaction list transactions.
        /// </summary>
        /// <value>The memorized transaction list transactions.</value>
        [DispId(13)]
        public ArrayList MemorizedTransactionListTransactions
        {
            get
            {
                QifDom.MemorizedTransactionListTransactions = new List<MemorizedTransactionListTransaction>(_MemorizedTransactionListTransactions.Cast<MemorizedTransactionListTransaction>());
                return _MemorizedTransactionListTransactions;
            }
        }
    }
}
