using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SEMES.Models;

namespace SEMES.Data
{
    /// <summary>
    /// This class does something.
    /// </summary>
    public interface IProductRepository {
        Task<Product> GetProduct(Product product);
        Task DeleteProduct(Product product);
        Task UpdateProduct(Product product);
        Task AddProduct(Product product);
        Task  SaveAsync();
    }
}