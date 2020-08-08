using System;
using System.ComponentModel.DataAnnotations;

namespace SEMES.Models
{
    public class Wearhouse
    {
        [Key]
        public String WearhouseId{get;set;}
        public string Name{get;set;}
        public string Address{get;set;}
    }
}