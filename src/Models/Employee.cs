using System;
using System.ComponentModel.DataAnnotations;

namespace SEMES.Models
{
    /// <summary>Employee Entity</summary>
    public class Employee : Person
    {
        /// <example>57f0f150-ca0c-4c54-9f40-27cc6bf5fd10</example>
        [Required]
        [Key]
        public String EmployeeId {get;set;}
    }
}