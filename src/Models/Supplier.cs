using System;
using System.ComponentModel.DataAnnotations;

namespace SEMES.Models
{
    /// <summary>Supplier Entity</summary>
    public class Supplier: Person
    {
        /// <example>57f0f150-ca0c-4c54-9f40-27cc6bf5fd10</example>
        [Required]
        [Key]
        public String SupplierId {get;set;}
    }
}