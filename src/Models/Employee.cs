using System;
using System.ComponentModel.DataAnnotations;

namespace SEMES.Models
{
    public class Employee : Person
    {
        [Key]
        public String EmployeeId {get;set;}
    }
}