using System;
using System.ComponentModel.DataAnnotations;

namespace SEMES.Models
{
    public class Person
    {
        /// <summary>
        /// First Name
        /// </summary>
        /// <example>John</example>
        [Required]
        public string FirstName {get;set;}
        /// <summary>
        /// Last Name
        /// </summary>
        /// <example>Lorca</example>
        [Required]
        public string LastName {get;set;}
        /// <summary>
        /// Phone number in integer with no special characters.
        /// Leaving space with 0 for special code.
        /// </summary>
        /// <example> 0014442119013 </example>
        [Required]
        public long PhoneNumber {get;set;}
        /// <example>somthing@something.com</example>
        [Required]
        public string Email {get;set;}
        /// <summary>
        /// Address given by a geolocation string
        /// </summary>
        /// <example>{lat: -34, lng: 151}</example>
        public string Address {get;set;}
    }
}