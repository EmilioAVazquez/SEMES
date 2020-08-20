using System;
using System.ComponentModel.DataAnnotations;

namespace SEMES.Models
{
    /// <summary>Wearhouse Entity</summary>
    public class Wearhouse
    {
        /// <example>57f0f150-ca0c-4c54-9f40-27cc6bf5fd10</example>
        [Key]
        [Required]
        public String WearhouseId{get;set;}
        /// <example>La otra vaina</example>
        [Required]
        public string Name{get;set;}
        /// <summary>
        /// Address given by a geolocation string
        /// </summary>
        /// <example>{lat: -34, lng: 151}</example>
        public string Address{get;set;}
    }
}