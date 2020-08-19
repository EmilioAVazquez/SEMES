using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SEMES.Models;
using System.Collections.Generic;
using Microsoft.FeatureManagement;

namespace SEMES.Data
{
    /// <summary>
    /// This class does something.
    /// </summary>
    class AdmiRepository : IAdmiRepository {
        
        SemesDbContext Context {get;set;}
        public AdmiRepository(SemesDbContext context, IFeatureManager featureManager){
            Context = context;
        }
        public async Task<Admi> GetAdmi(Admi admi){
            return await Context.Admi.FindAsync(admi.AdmiId);
        }
        public async Task DeleteAdmi(Admi admi){
            var a = await Context.Admi.FindAsync(admi.AdmiId);
            if(a==null)
                throw new KeyNotFoundException();
            Context.Admi.Remove(a);
        }
         public async Task UpdateAdmi(Admi admi){
            var a = await Context.Admi.FindAsync(admi.AdmiId);
            if(a==null)
                throw new KeyNotFoundException();
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
}