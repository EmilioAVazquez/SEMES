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
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<Admi> Get(string id)
        {
            var admi = new Admi();
            admi.AdmiId = id;
            var tsk = await admiRepo.GetAdmi(admi);
            return tsk;
        }
        
        [Microsoft.AspNetCore.Mvc.HttpPut]
        public async Task Put(Admi admi)
        {
            await admiRepo.AddAdmi(admi);
            await admiRepo.SaveAsync();
        }

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