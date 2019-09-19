using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACNinjaAPI.Models
{
    public class Household
    {       
        public int Id { get; set; }       
        public string Name { get; set; }        
        public string Greeting { get; set; }
        public bool IsConfigured { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}