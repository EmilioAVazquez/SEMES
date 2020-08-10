using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SEMES.Models;

namespace SEMES.Data
{
    /// <summary>
    /// This class does something.
    /// </summary>
    public interface ISupplierRepository {
        Task<Supplier> GetSupplier(Supplier supplier);
        Task DeleteSupplier(Supplier supplier);
        Task UpdateSupplier(Supplier supplier);
        Task AddSupplier(Supplier supplier);
        Task  SaveAsync();
    }
}