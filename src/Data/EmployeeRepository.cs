using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SEMES.Models;
using System.Web;

namespace SEMES.Data
{
    class EmployeeRepository : IEmployeeRepository {
        
        SemesDbContext Context {get;set;}
        public EmployeeRepository(SemesDbContext context){
            Context = context;
        }
        public async Task<Employee> GetEmployee(Employee employee){
            return await Context.Employee.FindAsync(employee.EmployeeId);
        }
        public async Task DeleteEmployee(Employee employee){
            var a = await Context.Employee.FindAsync(employee.EmployeeId);
            Context.Employee.Remove(a);
        }
        public async Task UpdateEmployee(Employee employee){
            var a = await Context.Employee.FindAsync(employee.EmployeeId);
            Context.Entry(a).CurrentValues.SetValues(employee);
        }
        public async Task<Employee> AddEmployee(Employee employee){
            employee.EmployeeId = Guid.NewGuid().ToString();
            await Context.Employee.AddAsync(employee);
            return employee;
        }

        public async Task SaveAsync(){
            await Context.SaveChangesAsync();
        }
    }
}