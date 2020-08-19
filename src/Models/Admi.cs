using System;
using System.ComponentModel.DataAnnotations;

namespace SEMES.Models
{
    /// <summary>My super duper data</summary>
    public class Admi : Person
    {
        /// <summary>The unique identifier</summary>
        [Key]
        public String AdmiId {get;set;}
        
    }
}