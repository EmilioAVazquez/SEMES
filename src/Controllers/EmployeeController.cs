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
        /// <summary>
        /// Gets a Employee entity by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A retrived Employee entity.</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<Employee> Get(string id)
        {
            var employee = new Employee();
            employee.EmployeeId = id;
            var tsk = await employeeRepo.GetEmployee(employee);
            return tsk;
        }
        /// <summary>
        /// Adds a Employee entity by its id.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>A action satisfaction result on the process(200 for OK, else somethign went wrong).</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut]
        public async Task<Employee> Put(Employee employee)
        {
            //var e = await employeeRepo.AddEmployee(employee);
            //await employeeRepo.SaveAsync();

            // Create token
            // Generate email
            // Send email
            return e;
        }
        /// <summary>
        /// Updates a given Employee entity. Valid employeeId required.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>A action satisfaction result on the process(200 for OK, else somethign went wrong).</returns>
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
        /// <summary>
        /// Deletes a Admi entity by its id. Valid employeeId required. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A action satisfaction result on the process(200 for OK, else somethign went wrong).</returns>
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