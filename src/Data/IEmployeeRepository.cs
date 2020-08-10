using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SEMES.Models;

namespace SEMES.Data
{
    /// <summary>
    /// This class does something.
    /// </summary>
    public interface IEmployeeRepository {
        Task<Employee> GetEmployee(Employee employee);
        Task DeleteEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task AddEmployee(Employee employee);
        Task  SaveAsync();
    }
}