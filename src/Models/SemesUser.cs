using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SEMES.Models
{
    /// <summary>Admi Entity</summary>
    public class SemesUser: IdentityUser
    {
        public enum Role 
        {
            Admi,
            Employee,
        }   

        public Role SemesRole {get;set;}
    }

}