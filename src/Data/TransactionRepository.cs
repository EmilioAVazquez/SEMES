using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SEMES.Models;
using System.Web;

namespace SEMES.Data
{
    class TransactionRepository : ITransactionRepository {
        
        SemesDbContext Context {get;set;}
        public TransactionRepository(SemesDbContext context){
            Context = context;
        }
        public async Task<Transaction> GetTransaction(Transaction transaction){
            return await Context.Transaction.FindAsync(transaction.TransactionId);
        }
        public async Task DeleteTransaction(Transaction transaction){
            var a = await Context.Transaction.FindAsync(transaction.TransactionId);
            Context.Transaction.Remove(a);
        }
        public async Task UpdateTransaction(Transaction transaction){
            var a = await Context.Transaction.FindAsync(transaction.TransactionId);
            Context.Entry(a).CurrentValues.SetValues(transaction);
        }
        public async Task AddTransaction(Transaction transaction){
            transaction.TransactionId = Guid.NewGuid().ToString();
            await Context.Transaction.AddAsync(transaction);
        }

        public async Task SaveAsync(){
            await Context.SaveChangesAsync();
        }
    }
}