using System;
using System.ComponentModel.DataAnnotations;

namespace SEMES.Models
{
    public class Supplier: Person
    {
        [Key]
        public String SupplierId {get;set;}
    }
}