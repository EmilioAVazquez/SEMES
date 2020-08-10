using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SEMES.Models;

namespace SEMES.Data
{
    /// <summary>
    /// This class does something.
    /// </summary>
    public interface IItemRepository {
        Task<Item> GetItem(Item item);
        Task DeleteItem(Item item);
        Task UpdateItem(Item item);
        Task AddItem(Item item);
        Task  SaveAsync();
    }
}