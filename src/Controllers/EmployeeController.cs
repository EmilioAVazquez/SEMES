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
    public class EmployeeController : ControllerBase
    {
        public IEmployeeRepository employeeRepo {get;set;}

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepository repo)
        {
            _logger = logger;
            employeeRepo = repo;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<Employee> Get(string id)
        {
            var employee = new Employee();
            employee.EmployeeId = id;
            var tsk = await employeeRepo.GetEmployee(employee);
            return tsk;
        }
        
        [Microsoft.AspNetCore.Mvc.HttpPut]
        public async Task Put(Employee employee)
        {
            await employeeRepo.AddEmployee(employee);
            await employeeRepo.SaveAsync();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task Post(Employee employee)
        {
            try{
                await employeeRepo.UpdateEmployee(employee);
                await employeeRepo.SaveAsync();
            }catch(KeyNotFoundException ){
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            try{
                var employee = new Employee();
                employee.EmployeeId = id;
                await employeeRepo.DeleteEmployee(employee);
                await employeeRepo.SaveAsync();        
            }catch(KeyNotFoundException){
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}