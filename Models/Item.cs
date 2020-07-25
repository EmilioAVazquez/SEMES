using System;

namespace SEMES
{
    public class Item
    {
        public int ItemId{get;set;}
        public int ProductId { get; set;}
        /*Holds the Product that this item is.*/
        public DateTime DateAdded {set;get;} 
        /*Holds the date when tiem was added.*/
        public int WearehouseId{set;get;}
    }
}