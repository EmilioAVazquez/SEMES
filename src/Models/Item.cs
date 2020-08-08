using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEMES.Models
{
    public class Item
    {
        [Key]
        public String ItemId{get;set;}
        [ForeignKey("Product")]
        [Column(Order = 1)]
        public int ProductId { get; set;}
        /*Holds the Product that this item is.*/
        public DateTime DateAdded {set;get;} 
        /*Holds the date when tiem was added.*/
        [ForeignKey("Wearhouse")]
        [Column(Order = 1)]
        public int WearehouseId{set;get;}
    }
}