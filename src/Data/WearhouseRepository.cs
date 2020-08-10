using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SEMES.Models;
using System.Web;

namespace SEMES.Data
{
    class WearhouseRepository : IWearhouseRepository {
        
        SemesDbContext Context {get;set;}
        public WearhouseRepository(SemesDbContext context){
            Context = context;
        }
        public async Task<Wearhouse> GetWearhouse(Wearhouse wearhouse){
            return await Context.Wearhouse.FindAsync(wearhouse.WearhouseId);
        }
        public async Task DeleteWearhouse(Wearhouse wearhouse){
            var a = await Context.Wearhouse.FindAsync(wearhouse.WearhouseId);
            Context.Wearhouse.Remove(a);
        }
        public async Task UpdateWearhouse(Wearhouse wearhouse){
            var a = await Context.Wearhouse.FindAsync(wearhouse.WearhouseId);
            Context.Entry(a).CurrentValues.SetValues(wearhouse);
        }
        public async Task AddWearhouse(Wearhouse wearhouse){
            wearhouse.WearhouseId = Guid.NewGuid().ToString();
            await Context.Wearhouse.AddAsync(wearhouse);
        }

        public async Task SaveAsync(){
            await Context.SaveChangesAsync();
        }
    }

    interface IWearhouseRepository {
        Task<Wearhouse> GetWearhouse(Wearhouse wearhouse);
        Task DeleteWearhouse(Wearhouse wearhouse);
        Task UpdateWearhouse(Wearhouse wearhouse);
        Task AddWearhouse(Wearhouse wearhouse);
        Task  SaveAsync();
    }
}