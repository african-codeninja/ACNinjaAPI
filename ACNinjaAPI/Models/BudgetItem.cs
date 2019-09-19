using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACNinjaAPI.Models
{
    public class BudgetItem
    {       
        public int Id { get; set; }
        public int BudgetId { get; set; }
        public string ItemName { get; set; }
        public DateTimeOffset Created { get; set;}
        public double Target { get; set; }
    }
}