using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SEMES.Data;
using SEMES.Models;
using System.Web.Http;
using SEMES.Services;

namespace SEMES.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public IEmployeeRepository employeeRepo {get;set;}
        private JWT jwtService ;
        private UserManager userManager;

        private readonly ILogger<AdmiController> _logger;

        public AuthController(ILogger<AuthController> logger, IEmployeeRepository repo, UserManager<IdentityUser> _userManager)
        {
            _logger = logger;
            jwtService = new JWT();
            employeeRepo = repo;
            userManager = _userManager;
        }
        /// <summary>
        /// Given a registration token and a user filled model, this endpoint verifies the tokeb and adds the 
        /// USer model top the database and activates the user's account.
        /// </summary>
        /// <param name="userVerification"></param>
        /// <returns>Returns a JWT token if the data is verified.</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost()]
        public async Task<string> VerifyUser(UserVerification userVerification)
        {
            // Verify user token
            if(jwtService.ValidateJSONWebToken(userVerification.token)){
                throw new HttpResponseException(System.Net.HttpStatusCode.Unauthorized);
            }
            // Add the employee to the database 
            employeeRepo.AddEmployee(userVerification.user);
            await employeeRepo.SaveAsync();
            // Return sign-in token
            var tokenString = GenerateJSONWebToken(user); 
            return tokenString;
        }

        /// <summary>
        /// Given the User's username (email) and their password, this endpoints verifies these credentials and 
        /// returns a vlid token.
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns>Rerurns a JWT token. </returns>
        [Microsoft.AspNetCore.Mvc.HttpPost()]
        public async Task<string> Login(UserModel userModel)
        {
            // Verify user credentials
            var flag =  userManager.CheckPassword(employeeRepo.GetEmployee(new Employee(){Email=userModel.email}), userModel.password);
            // return sign-in token
            var tokenString = jwtService.GenerateJSONWebToken(user); 
            await flag;
            if(flagh)
                return tokenString;
            throw new HttpResponseException(System.Net.HttpStatusCode.Unauthorized);
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
            string password{get;set;}
        }

        class UserModel{
            string email{get;set;}
            string password{get;set;}
        }
    }
}