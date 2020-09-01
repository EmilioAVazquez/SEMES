using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SEMES.Data;
using SEMES.Models;
using System.Web.Http;

namespace SEMES.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public IAdmiRepository admiRepo {get;set;}

        private readonly ILogger<AdmiController> _logger;

        public AuthController(ILogger<AuthController> logger, IEmployeeRepository repo)
        {
            _logger = logger;
            admiRepo = repo;
        }
        /// <summary>
        /// Creates a verified employee from the Token and an Employee model.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A retrived Admi entity.</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost()]
        public async Task<string> VerifyUser(UserVerification userVerification)
        {
            // Verify user token
            if(ValidateJSONWebToken(userVerification.token)){
                throw new HttpResponseException(System.Net.HttpStatusCode.Unauthorized);
            }
            // Add the employee to the database 
            // return sign-in token
            var tokenString = GenerateJSONWebToken(user); 
            return tokenString;
        }

        /// <summary>
        /// Gets a Admi entity by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A retrived Admi entity.</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost()]
        public async Task<string> Login(UserModel userModel)
        {
            // Verify user credentials
            var user = AuthenticateUser(userModel);
            if(user == null)
                 throw new HttpResponseException(System.Net.HttpStatusCode.Unauthorized);
            // return sign-in token
            var tokenString = GenerateJSONWebToken(user); 
            return tokenString;
        }

        private UserModel AuthenticateUser(UserModel login)    
        {    
            UserModel user = null;    
    
            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (login.username == "Jignesh")    
            {    
                user = new UserModel { Username = "Jignesh Trivedi", EmailAddress = "test.btest@gmail.com" };    
            } else{
                return null;
            } 
            return user;    
        }

        class UserVerification{
            Person user{get;set;}
            string token {get;set;}
        }

        class UserModel{
            string email{get;set;}
            string password{get;set;}
        }
    }
}