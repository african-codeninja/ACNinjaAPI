using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACNinjaAPI.Models
{
    /// <summary>
    /// A subset of the Budget table setting up different budget items
    /// </summary>
    public class BudgetItem
    {    
        /// <summary>
        /// Primary Key for this table and objects thereof
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Foregin Key referencing the below named table
        /// </summary>
        public int BudgetId { get; set; }
        /// <summary>
        /// The name of this budget item
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// When this budget item was created
        /// </summary>
        public DateTimeOffset Created { get; set;}
        /// <summary>
        /// Maximum projected allocation in dollars where we don't want to spend beyond
        /// </summary>
        public double Target { get; set; }
    }
}