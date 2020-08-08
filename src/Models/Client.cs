using System;
using System.ComponentModel.DataAnnotations;

namespace SEMES.Models
{
    public class Client: Person
    {
        [Key]
        public String ClientId {get;set;}
    }
}