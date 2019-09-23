using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACNinjaAPI.Models
{
    /// <summary>
    /// The Bank account that user will create to show various transaction: e.g. Deposit, Withdrawal... e.t.c.
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// The primary key assoiciated with this table
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The foreign key associated with the Household
        /// </summary>
        public int HouseholdId { get; set; }
        /// <summary>
        /// The foreign key associated with who owns the bank account
        /// </summary>
        public string OwnerUserId { get; set; }
        /// <summary>
        /// The foreign key associated with which bank account are transactions done
        /// </summary>
        public int? AccountTypeId { get; set; }
        /// <summary>
        /// The name of the bank account
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The decristion of the bank account
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The name of the bank account
        /// </summary>
        public string Address1 { get; set; }
        /// <summary>
        ///does the bank address reside a a Building NO, Court No.,
        /// </summary>
        public string Address2 { get; set; }
        /// <summary>
        /// The City of the bank account
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// The Zip of the bank account
        /// </summary>
        public string Zip { get; set; }
        /// <summary>
        /// Starting balance of this bank account balance
        /// </summary>
        public double StartingBalance { get; set; }
        /// <summary>
        /// Low balance of this bank account balance that should trigger a message to user
        /// </summary>
        public double LowBalance { get; set; }
        /// <summary>
        /// Current blalance that should be == to Starting balance
        /// </summary>
        public double CurrentBalance { get; set; }       
    }
}