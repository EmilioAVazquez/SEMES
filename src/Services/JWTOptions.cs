using Microsoft.Extensions.Configuration;

namespace SEMES.Services
{
    public class JWTOptions{
        public string audience{get;set;}
        public string issuer{get;set;}
        public string key{get;set;}
    }
}