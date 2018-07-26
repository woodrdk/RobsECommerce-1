using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JoesECommerce.Models
{
    /// <summary>
    /// Represents a sellable product
    /// </summary>
    public class Product
    {
        [Key] //Makes the property the PK
        //If PK property is an integer, 
        //it will be an identity column by default
        public int ProductID { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Range(0, 100000)] //Inclusive?
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        //TODO: Add description
    }
}