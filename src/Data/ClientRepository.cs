using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SEMES.Models;
using System.Web;
using System.Collections.Generic;
using System.Linq;

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
        public async Task<List<Client>> GetClientsByEmployee(string id){
            // Get list of most the 10 frequen used products given a employee
            return Context.Client.ToList();
        }
        public async Task<List<Client>> GetClientsByName(string name){
            var names = name.Split(null);
            return  Context.Client.Where(
                    c => 
                        EF.Functions.Like(c.FirstName, names[0]) && EF.Functions.Like(c.LastName, names[1])
                ).Take(10).ToList();
        }
        public async Task<List<Client>> GetClientsByPhone(int phone){
            return Context.Client.Where(
                    c => 
                        c.PhoneNumber == phone
                ).Take(10).ToList();
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