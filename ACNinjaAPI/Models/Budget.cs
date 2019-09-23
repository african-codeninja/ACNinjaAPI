using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACNinjaAPI.Models
{
    /// <summary>
    /// The budget name of the particular household e.g. Bill and a Budgetitem of Electricity
    /// </summary>
    public class Budget
    {
        /// <summary>
        /// The primary key for this category
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The foreign key referencing the Household
        /// </summary>
        public int HouseholdId { get; set; }
        /// <summary>
        /// The particular name of this budget
        /// </summary>
        public string BudgetName { get; set; }
        /// <summary>
        /// the target of this budget
        /// </summary>
        public double TargetAmount { get; set; }      
    }
}