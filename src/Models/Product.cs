using System;
using System.ComponentModel.DataAnnotations;

namespace SEMES.Models
{
    public class Product
    {
        [Key]
        public String ProductId{get;set;}
        public string Name { get; set; }
        public string Summary { get; set; }
    }
}
