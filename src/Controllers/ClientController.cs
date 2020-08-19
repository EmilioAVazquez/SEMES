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
    public class ClientController : ControllerBase
    {
        public IClientRepository clientRepo {get;set;}

        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger, IClientRepository repo)
        {
            _logger = logger;
            clientRepo = repo;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<Client> Get(string id)
        {
            var client = new Client();
            client.ClientId = id;
            var tsk = await clientRepo.GetClient(client);
            return tsk;
        }
        
        [Microsoft.AspNetCore.Mvc.HttpPut]
        public async Task Put(Client client)
        {
            await clientRepo.AddClient(client);
            await clientRepo.SaveAsync();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task Post(Client client)
        {
            try{
                await clientRepo.UpdateClient(client);
                await clientRepo.SaveAsync();
            }catch(KeyNotFoundException ){
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            try{
                var client = new Client();
                client.ClientId = id;
                await clientRepo.DeleteClient(client);
                await clientRepo.SaveAsync();        
            }catch(KeyNotFoundException){
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}