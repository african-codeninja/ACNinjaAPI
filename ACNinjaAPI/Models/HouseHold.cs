using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ACNinjaAPI.Models
{
    /// <summary>
    /// The Household Class Models the data shaped from the the information returned fromthe SQL Database
    /// </summary>
    public class Household
    {
        /// <summary>
        /// Primary key of the Househole Record
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The Name Assigned to this Household
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The Default Greeting associated with this Household
        /// </summary>
        public string Greeting { get; set; }
        /// <summary>
        /// The switch indicated is this house is configured to a partcular Head of house
        /// </summary>
        public bool IsConfigured { get; set; }
        /// <summary>
        /// Showing information of when this Household was created
        /// </summary>
        public DateTimeOffset Created { get; set; }
    }
}