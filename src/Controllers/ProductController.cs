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
    public class ProductController : ControllerBase
    {
        public IProductRepository productRepo {get;set;}

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, IProductRepository repo)
        {
            _logger = logger;
            productRepo = repo;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<Product> Get(string id)
        {
            var product = new Product();
            product.ProductId = id;
            var tsk = await productRepo.GetProduct(product);
            return tsk;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("products/{key}")]
        public async Task<List<Product>> GetProducts(string key)
        {
            var tsk = await productRepo.GetProductsByName(key);
            return tsk;
        }
        
        [Microsoft.AspNetCore.Mvc.HttpPut]
        public async Task Put(Product product)
        {
            await productRepo.AddProduct(product);
            await productRepo.SaveAsync();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task Post(Product product)
        {
            try{
                await productRepo.UpdateProduct(product);
                await productRepo.SaveAsync();
            }catch(KeyNotFoundException ){
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            try{
                var product = new Product();
                product.ProductId = id;
                await productRepo.DeleteProduct(product);
                await productRepo.SaveAsync();        
            }catch(KeyNotFoundException){
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}