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
    public class WearhouseController : ControllerBase
    {
        public IWearhouseRepository wearhouseRepo {get;set;}

        private readonly ILogger<WearhouseController> _logger;

        public WearhouseController(ILogger<WearhouseController> logger, IWearhouseRepository repo)
        {
            _logger = logger;
            wearhouseRepo = repo;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<Wearhouse> Get(string id)
        {
            var wearhouse = new Wearhouse();
            wearhouse.WearhouseId = id;
            var tsk = await wearhouseRepo.GetWearhouse(wearhouse);
            return tsk;
        }
        
        [Microsoft.AspNetCore.Mvc.HttpPut]
        public async Task Put(Wearhouse wearhouse)
        {
            await wearhouseRepo.AddWearhouse(wearhouse);
            await wearhouseRepo.SaveAsync();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task Post(Wearhouse wearhouse)
        {
            try{
                await wearhouseRepo.UpdateWearhouse(wearhouse);
                await wearhouseRepo.SaveAsync();
            }catch(KeyNotFoundException ){
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            try{
                var wearhouse = new Wearhouse();
                wearhouse.WearhouseId = id;
                await wearhouseRepo.DeleteWearhouse(wearhouse);
                await wearhouseRepo.SaveAsync();        
            }catch(KeyNotFoundException){
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}