using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SEMES.Models;
using System.Web;
using System.Linq;

namespace SEMES.Data
{
    class SemesUserRepository : ISemesUserRepository {
        
        SemesDbContext Context {get;set;}
        public SemesUserRepository(SemesDbContext context){
            Context = context;
        }
        public async Task<SemesUser> GetSemesUserByEmail(string email){
            return Context.SemesUser.Where(
                    user => user.Email == email)
                    .FirstOrDefault<SemesUser>();
        }
        public async Task<SemesUser> AddSemesUser(SemesUser user){
            await Context.SemesUser.AddAsync(user);
            return user;
        }
        public async Task SaveAsync(){
            await Context.SaveChangesAsync();
        }
    }
}