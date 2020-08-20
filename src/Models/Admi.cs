using System;
using System.ComponentModel.DataAnnotations;

namespace SEMES.Models
{
    /// <summary>Admi Entity</summary>
    public class Admi : Person
    {
        /// <example>57f0f150-ca0c-4c54-9f40-27cc6bf5fd10</example>
        [Required]
        [Key]
        public String AdmiId {get;set;}
        
    }
}