using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SEMES.Models;
using System.Web;

namespace SEMES.Data
{
    class ProductRepository : IProductRepository {
        
        SemesDbContext Context {get;set;}
        public ProductRepository(SemesDbContext context){
            Context = context;
        }
        public async Task<Product> GetProduct(Product product){
            return await Context.Product.FindAsync(product.ProductId);
        }
        public async Task DeleteProduct(Product product){
            var a = await Context.Product.FindAsync(product.ProductId);
            Context.Product.Remove(a);
        }
        public async Task UpdateProduct(Product product){
            var a = await Context.Product.FindAsync(product.ProductId);
            Context.Entry(a).CurrentValues.SetValues(product);
        }
        public async Task AddProduct(Product product){
            product.ProductId = Guid.NewGuid().ToString();
            await Context.Product.AddAsync(product);
        }

        public async Task SaveAsync(){
            await Context.SaveChangesAsync();
        }
    }

    interface IProductRepository {
        Task<Product> GetProduct(Product product);
        Task DeleteProduct(Product product);
        Task UpdateProduct(Product product);
        Task AddProduct(Product product);
        Task  SaveAsync();
    }
}