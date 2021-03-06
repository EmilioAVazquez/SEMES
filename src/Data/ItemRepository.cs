using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SEMES.Models;
using System.Web;

namespace SEMES.Data
{
    class ItemRepository : IItemRepository {
        
        SemesDbContext Context {get;set;}
        public ItemRepository(SemesDbContext context){
            Context = context;
        }
        public async Task<Item> GetItem(Item item){
            return await Context.Item.FindAsync(item.ItemId);
        }
        public async Task DeleteItem(Item item){
            var a = await Context.Item.FindAsync(item.ItemId);
            Context.Item.Remove(a);
        }
        public async Task UpdateItem(Item item){
            var a = await Context.Item.FindAsync(item.ItemId);
            Context.Entry(a).CurrentValues.SetValues(item);
        }
        public async Task AddItem(Item item){
            item.ItemId = Guid.NewGuid().ToString();
            await Context.Item.AddAsync(item);
        }

        public async Task SaveAsync(){
            await Context.SaveChangesAsync();
        }
    }
}