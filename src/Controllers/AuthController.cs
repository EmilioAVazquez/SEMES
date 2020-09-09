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
using Microsoft.AspNetCore.Identity;
using SEMES.Models;

namespace SEMES.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    class AuthController : ControllerBase
    {
        public ISemesUserRepository userRepo {get;set;}
        private JWT jwtService ;
        private UserManager<SemesUser>  userManager;

        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger, ISemesUserRepository repo, UserManager<SemesUser> _userManager)
        {
            _logger = logger;
            jwtService = new JWT();
            userRepo = repo;
            userManager = _userManager;
        }
        /// <summary>
        /// Verifies and adds a new user to the platfrom from a registration token.
        /// The registration token is created when the Admi adds the user and sends
        /// a registration link (with the registration token in it) to the user's phone
        /// and/or email.
        /// </summary>
        /// <param name="userVerification"></param>
        /// <returns>Returns a JWT login token if the data is verified.</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost()]
        public async Task<string> VerifyUser(UserVerification userVerification)
        {
            // 1) Check that the userModel has not already signed up
            var user = userRepo.GetSemesUserByEmail(userVerification.user.Email);
            // 2) Verify the registation token 
            if(!jwtService.ValidateJSONWebToken(userVerification.token)){
                throw new HttpResponseException(System.Net.HttpStatusCode.Unauthorized);
            }
            // 3) Verify that the user is not already verified
            if(user != null){
                throw new HttpResponseException(System.Net.HttpStatusCode.Unauthorized);
            }
            // 3) Add the user to the database 
            userRepo.AddSemesUser(userVerification.user);
            await userRepo.SaveAsync();
            await userManager.AddPasswordAsync(await userRepo.GetSemesUserByEmail(userVerification.user.Email),userVerification.password);
            // Create and Return login token
            return jwtService.GenerateJSONWebToken(userVerification.user); 
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
            // 1) Verify user credentials, e.g. password and email
            var user =  userManager.CheckPasswordAsync(await userRepo.GetSemesUserByEmail(userModel.email), userModel.password);
            // 2) Create token 
            var tokenString = jwtService.GenerateJSONWebToken(await userRepo.GetSemesUserByEmail(userModel.email)); 
            await user;
            // 3) Check if credentials are correct
            if(! await user)
                throw new HttpResponseException(System.Net.HttpStatusCode.Unauthorized);
            return tokenString;
        }
    }
}