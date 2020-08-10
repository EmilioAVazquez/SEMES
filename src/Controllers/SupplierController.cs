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
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class SupplierController : ControllerBase
    {
        public ISupplierRepository supplierRepo {get;set;}

        private readonly ILogger<SupplierController> _logger;

        public SupplierController(ILogger<SupplierController> logger, ISupplierRepository repo)
        {
            _logger = logger;
            supplierRepo = repo;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<Supplier> Get(string id)
        {
            var supplier = new Supplier();
            supplier.SupplierId = id;
            var tsk = await supplierRepo.GetSupplier(supplier);
            return tsk;
        }
        
        [Microsoft.AspNetCore.Mvc.HttpPut]
        public async Task Put(Supplier supplier)
        {
            await supplierRepo.AddSupplier(supplier);
            await supplierRepo.SaveAsync();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task Post(Supplier supplier)
        {
            try{
                await supplierRepo.UpdateSupplier(supplier);
                await supplierRepo.SaveAsync();
            }catch(KeyNotFoundException ){
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            try{
                var supplier = new Supplier();
                supplier.SupplierId = id;
                await supplierRepo.DeleteSupplier(supplier);
                await supplierRepo.SaveAsync();        
            }catch(KeyNotFoundException){
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}