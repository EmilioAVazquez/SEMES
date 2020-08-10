using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SEMES.Models;
using System.Web;

namespace SEMES.Data
{
    class ClientRepository : IClientRepository {
        
        SemesDbContext Context {get;set;}
        public ClientRepository(SemesDbContext context){
            Context = context;
        }
        public async Task<Client> GetClient(Client client){
            return await Context.Client.FindAsync(client.ClientId);
        }
        public async Task DeleteClient(Client client){
            var a = await Context.Client.FindAsync(client.ClientId);
            Context.Client.Remove(a);
        }
        public async Task UpdateClient(Client client){
            var a = await Context.Client.FindAsync(client.ClientId);
            Context.Entry(a).CurrentValues.SetValues(client);
        }
        public async Task AddClient(Client client){
            client.ClientId = Guid.NewGuid().ToString();
            await Context.Client.AddAsync(client);
        }

        public async Task SaveAsync(){
            await Context.SaveChangesAsync();
        }
    }
}