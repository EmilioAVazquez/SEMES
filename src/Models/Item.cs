using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEMES.Models
{
    /// <summary>Item Entity</summary>
    public class Item
    {
        /// <example>57f0f150-ca0c-4c54-9f40-27cc6bf5fd10</example>
        [Required]
        [Key]
        public String ItemId{get;set;}
        /// <summary>
        /// Product Associated with Transaction.
        /// </summary>
        /// <example>57f0f150-ca0c-4c54-9f40-27cc6bf5fd10</example>
        [Required]
        [ForeignKey("Product")]
        [Column(Order = 1)]
        public string ProductId { get; set;}
        /// <summary>
        /// Transaction asociated with this item.
        /// </summary>
        /// <example>57f0f150-ca0c-4c54-9f40-27cc6bf5fd10</example>
        [ForeignKey("Transaction")]
        [Column(Order = 1)]
        public string TransactionId { get; set;}
        /// <summary>
        /// Added in the backend.
        /// </summary>
        /// <example>12-01-2020</example>
        public DateTime DateAdded {set;get;} 
        /// <summary>
        /// Wearhouse associated with this transaction.
        /// </summary>
        /// <example>57f0f150-ca0c-4c54-9f40-27cc6bf5fd10</example>
        [ForeignKey("Wearhouse")]
        [Column(Order = 1)]
        public int WearehouseId{set;get;}
        /// <summary>
        /// Number or quantity of a given product.This in the unit of the 
        /// product itself.
        /// </summary>
        /// <example>2</example>
        [Required]
        public double Quantity{get;set;}
    }
}