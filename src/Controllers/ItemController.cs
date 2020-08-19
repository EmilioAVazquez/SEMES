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
    public class ItemController : ControllerBase
    {
        public IItemRepository itemRepo {get;set;}

        private readonly ILogger<ItemController> _logger;

        public ItemController(ILogger<ItemController> logger, IItemRepository repo)
        {
            _logger = logger;
            itemRepo = repo;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<Item> Get(string id)
        {
            var item = new Item();
            item.ItemId = id;
            var tsk = await itemRepo.GetItem(item);
            return tsk;
        }
        
        [Microsoft.AspNetCore.Mvc.HttpPut]
        public async Task Put(Item item)
        {
            await itemRepo.AddItem(item);
            await itemRepo.SaveAsync();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task Post(Item item)
        {
            try{
                await itemRepo.UpdateItem(item);
                await itemRepo.SaveAsync();
            }catch(KeyNotFoundException ){
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            try{
                var item = new Item();
                item.ItemId = id;
                await itemRepo.DeleteItem(item);
                await itemRepo.SaveAsync();        
            }catch(KeyNotFoundException){
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}