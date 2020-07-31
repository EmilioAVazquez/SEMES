using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SEMES.Models;

namespace SEMES.Data
{
    class SupplierRepository : ISupplierRepository {
        
        SemesDbContext Context {get;set;}
        public SupplierRepository(SemesDbContext context){
            Context = context;
        }
        public async Task<Supplier> GetSupplier(Supplier supplier){
            return await Context.Supplier.FindAsync(supplier.SupplierId);
        }
        public async Task DeleteSupplier(Supplier supplier){
            var a = await Context.Supplier.FindAsync(supplier.SupplierId);
            Context.Supplier.Remove(a);
        }
        public async Task UpdateSupplier(Supplier supplier){
            var a = await Context.Supplier.FindAsync(supplier.SupplierId);
            Context.Entry(a).CurrentValues.SetValues(supplier);
        }
        public async Task AddSupplier(Supplier supplier){
            supplier.SupplierId = Guid.NewGuid().ToString();
            await Context.Supplier.AddAsync(supplier);
        }

        public async Task SaveAsync(){
            await Context.SaveChangesAsync();
        }
    }

    interface ISupplierRepository {
        Task<Supplier> GetSupplier(Supplier supplier);
        Task DeleteSupplier(Supplier supplier);
        Task UpdateSupplier(Supplier supplier);
        Task AddSupplier(Supplier supplier);
        Task  SaveAsync();
    }
}