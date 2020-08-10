using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SEMES.Models;

namespace SEMES.Data
{
    /// <summary>
    /// This class does something.
    /// </summary>
    public interface ITransactionRepository {
        Task<Transaction> GetTransaction(Transaction transaction);
        Task DeleteTransaction(Transaction transaction);
        Task UpdateTransaction(Transaction transaction);
        Task AddTransaction(Transaction transaction);
        Task  SaveAsync();
    }
}