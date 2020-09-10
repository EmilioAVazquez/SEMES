using System.ComponentModel.DataAnnotations;

namespace SEMES.Models
{
    /// <summary>Wearhouse Entity</summary>
    public class UserVerification{
        /// <example>5hjk@ckn.com</example>
        public SemesUser user{get;set;}
        /// <example>57f0f150-ca0c-4c54-9f40-27cc6bf5fd10</example>
        public string token {get;set;}
        /// <example>sdhvgjbkhgvjh</example>
        public string password{get;set;}
    }
}