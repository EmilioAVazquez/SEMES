using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SEMES.Models;

namespace SEMES.Data
{
    /// <summary>
    /// This class does something.
    /// </summary>
    class AdmiRepository : IAdmiRepository {
        
        SemesDbContext Context {get;set;}
        public AdmiRepository(SemesDbContext context){
            Context = context;
        }
        public async Task<Admi> GetAdmi(Admi admi){
            return await Context.Admi.FindAsync(admi.AdmiId);
        }
        public async Task DeleteAdmi(Admi admi){
            var a = await Context.Admi.FindAsync(admi.AdmiId);
            Context.Admi.Remove(a);
        }
        public async Task UpdateAdmi(Admi admi){
            var a = await Context.Admi.FindAsync(admi.AdmiId);
            Context.Entry(a).CurrentValues.SetValues(admi);
        }
        public async Task AddAdmi(Admi admi){
            admi.AdmiId = Guid.NewGuid().ToString();
            await Context.Admi.AddAsync(admi);
        }

        public async Task SaveAsync(){
            await Context.SaveChangesAsync();
        }
    }
    /// <summary>
    /// This class does something.
    /// </summary>
    interface IAdmiRepository {
        Task<Admi> GetAdmi(Admi admi);
        Task DeleteAdmi(Admi admi);
        Task UpdateAdmi(Admi admi);
        Task AddAdmi(Admi admi);
        Task  SaveAsync();
    }
}