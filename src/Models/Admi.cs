using System;
using System.ComponentModel.DataAnnotations;

namespace SEMES.Models
{
    public class Admi : Person
    {
        [Key]
        public String AdmiId {get;set;}
    }
}