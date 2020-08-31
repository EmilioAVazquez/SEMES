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
    public class AdmiController : ControllerBase
    {
        public IAdmiRepository admiRepo {get;set;}

        private readonly ILogger<AdmiController> _logger;

        public AdmiController(ILogger<AdmiController> logger, IAdmiRepository repo)
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
        public async Task<Person> VerifyUser(UserVerification userVerification)
        {
            // Verify user token
            // Add the employee to the database 
            // 
        }

        /// <summary>
        /// Gets a Admi entity by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A retrived Admi entity.</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost()]
        public async Task<Admi> Login(UserModel userVerification)
        {
            // Verify user credentials
            // Retun Token
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