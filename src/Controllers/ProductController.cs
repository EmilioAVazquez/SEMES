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
        /// <summary>
        /// Gets a Product entity by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A retrived Product entity.</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<Product> Get(string id)
        {
            var product = new Product();
            product.ProductId = id;
            var tsk = await productRepo.GetProduct(product);
            return tsk;
        }
        /// <summary>
        /// Gets a list of 10 possible Product entities given a key.
        /// For instance key = "aple", will return a list of product
        /// with names similar to "aple" like "apple"
        /// </summary>
        /// <param name="key"></param>
        /// <returns>List of 10 Products with similar names as key</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet("products/{key}")]
        public async Task<List<Product>> GetProducts(string key)
        {
            var tsk = await productRepo.GetProductsByName(key);
            return tsk;
        }
        /// <summary>
        /// Adds a new Product entity with dummy id and returns same Product enity BUT with 
        /// updated id.
        /// </summary>
        /// <param name="admi"></param>
        /// <returns>The same Product enity that was given but with updated id.</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut]
        public async Task Put(Product product)
        {
            await productRepo.AddProduct(product);
            await productRepo.SaveAsync();
        }
        /// <summary>
        /// Updates a given Product entity. Valid productId required.
        /// </summary>
        /// <param name="product"></param>
        /// <returns>A action satisfaction result on the process(200 for OK, else somethign went wrong).</returns>
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
        /// <summary>
        /// Deletes a Product entity by its id. Valid productId required. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A action satisfaction result on the process(200 for OK, else somethign went wrong).</returns>
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