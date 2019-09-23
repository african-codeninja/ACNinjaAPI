using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACNinjaAPI.Models
{
    /// <summary>
    /// This class is modelled against all Transactions
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// The Primary Key of this table
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Foreign Key of the bank account table
        /// </summary>
        public int? BankAccountId { get; set; }
        /// <summary>
        /// The Foreign Key from the bank BUdget Item table
        /// </summary>
        public int? BudgetItemId { get; set; }
        /// <summary>
        /// The Foreign Key from the bank Transaction Type table
        /// </summary>
        public int? TransactionTypeId { get; set; }
        /// <summary>
        /// The Foreign Key from the User Identity Table
        /// </summary>
        public string EnteredById { get; set; }  
        /// <summary>
        /// Amount of the transaction
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// Who was paid from this transaction
        /// </summary>
        public string Payee { get; set; }
        /// <summary>
        /// The description of this transaction
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// When this transaction took place
        /// </summary>
        public DateTimeOffset Created { get; set; }
        /// <summary>
        /// Used to determine down the road if this transaction consolidates with bank account
        /// </summary>
        public bool Reconciled { get; set; }
        /// <summary>
        /// When reconsiliations took place
        /// </summary>
        public DateTimeOffset? ReconciledDate { get; set; }       
    }
}