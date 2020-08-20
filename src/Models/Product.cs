using System;
using System.ComponentModel.DataAnnotations;

namespace SEMES.Models
{
    /// <summary>Product Entity</summary>
    public class Product
    {
        /// <example>57f0f150-ca0c-4c54-9f40-27cc6bf5fd10</example>
        [Required]
        [Key]
        public string ProductId{get;set;}
        /// <example>Water</example>
        [Required]
        public string Name { get; set; }
        /// <example>Water bonafon inported. 0 sodium. 0% clorine</example>
        public string Summary { get; set; }// Todo In the future we might be able to scan the product!
        /// <summary>
        /// This is on the wearhouse currency like dollar, or equatorian peso.
        /// </summary>
        /// <example>12.00</example>
        [Required]
        public double Price {get;set;}
        /// <summary>
        /// Units that the price is made on. Like L, kg, package, etc.
        /// </summary>
        /// <example>mL</example>
        [Required]
        public string Unit {get;set;}
    }
}
