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
        /// Gets a Admi entity by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A retrived Admi entity.</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<Admi> Get(string id)
        {
            var admi = new Admi();
            admi.AdmiId = id;
            var tsk = await admiRepo.GetAdmi(admi);
            return tsk;
        }

        /// <summary>
        /// Adds a new Admi entity with dummy id and returns same Admi enity BUT with 
        /// updated id.
        /// </summary>
        /// <param name="admi"></param>
        /// <returns>The same Admi enity that was given but with updated id.</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut]
        public async Task<Admi> Put(Admi admi)
        {
            var a = await admiRepo.AddAdmi(admi);
            await admiRepo.SaveAsync();
            return a;
        }

        /// <summary>
        /// Updates a given Admi entity. Valid admiId required.
        /// </summary>
        /// <param name="admi"></param>
        /// <returns>A action satisfaction result on the process(200 for OK, else somethign went wrong).</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task Post(Admi admi)
        {
            try{
                await admiRepo.UpdateAdmi(admi);
                await admiRepo.SaveAsync();
            }catch(KeyNotFoundException ){
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Deletes a Admi entity by its id. Valid employeeId required. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A action satisfaction result on the process(200 for OK, else somethign went wrong).</returns>
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            try{
                var admi = new Admi();
                admi.AdmiId = id;
                await admiRepo.DeleteAdmi(admi);
                await admiRepo.SaveAsync();        
            }catch(KeyNotFoundException){
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}