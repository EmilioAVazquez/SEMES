namespace SEMES.Models
{
    class UserVerification{
        public SemesUser user{get;set;}
        public string token {get;set;}
        public string password{get;set;}
    }
}