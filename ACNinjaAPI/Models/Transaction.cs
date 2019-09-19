using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACNinjaAPI.Models
{
    public class Transaction
    {
        //Primary Key
        public int Id { get; set; }

        //Foreign Key
        public int? BankAccountId { get; set; }
        public int? BudgetItemId { get; set; }
        public int? TransactionTypeId { get; set; }
        public string EnteredById { get; set; }     
        public double Amount { get; set; }
        public string Payee { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Created { get; set; }
        public bool Reconciled { get; set; }
        public DateTimeOffset? ReconciledDate { get; set; }       
    }
}