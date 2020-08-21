using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SEMES.Models;
using System.Collections.Generic;

namespace SEMES.Data
{
    /// <summary>
    /// This class does something.
    /// </summary>
    public interface IProductRepository {
        Task<Product> GetProduct(Product product);
        Task<List<Product>> GetProductsByName(string name);
        Task<List<Product>> GetProductsByEmployee(string id);
        Task DeleteProduct(Product product);
        Task UpdateProduct(Product product);
        Task<Product> AddProduct(Product product);
        Task  SaveAsync();
    }
}