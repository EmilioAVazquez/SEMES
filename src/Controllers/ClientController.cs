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
        
        /// <summary>
        /// Gets a Client entity by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A retrived Client entity.</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<Client> Get(string id)
        {
            var client = new Client();
            client.ClientId = id;
            var tsk = await clientRepo.GetClient(client);
            return tsk;
        }
        /// <summary>
        /// Gets a List of possible Clients by phone number string or a firstName_Lastname string
        /// </summary>
        /// <param name="key"></param>
        /// <returns>A list of possible Clients.</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet("clients/{key}")]
        public async Task<List<Client>> GetClients(string key)
        {
            try{
                var phone = Convert.ToInt32(key);
                var tsk = await clientRepo.GetClientsByPhone(phone);
                return tsk;
            }catch(FormatException){
                var tsk = await clientRepo.GetClientsByName(key);
                return tsk;
            }
        }
                /// <summary>
        /// Gets a list of the most frequently used products by Employee.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of the products of the usser</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet("employee/{id}")]
        public async Task<List<Client>> GetClientsByEmployee(string id)
        {
            var tsk = await clientRepo.GetClientsByEmployee( id);
            return tsk;
        }
        /// <summary>
        /// Adds a new Client entity with dummy id and returns same Client enity BUT with 
        /// updated id.
        /// </summary>
        /// <param name="client"></param>
        /// <returns>The same Admi enity that was given but with updated id.</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut]
        public async Task Put(Client client)
        {
            await clientRepo.AddClient(client);
            await clientRepo.SaveAsync();
        }

        /// <summary>
        /// Updates a given Client entity. Valid clientId required.
        /// </summary>
        /// <param name="client"></param>
        /// <returns>A action satisfaction result on the process(200 for OK, else somethign went wrong).</returns>
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
        /// <summary>
        /// Deletes a Client entity by its id. Valid clientId required. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A action satisfaction result on the process(200 for OK, else somethign went wrong).</returns>
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