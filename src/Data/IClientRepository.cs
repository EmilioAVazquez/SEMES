using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SEMES.Models;

namespace SEMES.Data
{
    /// <summary>
    /// This class does something.
    /// </summary>
    public interface IClientRepository {
        Task<Client> GetClient(Client client);
        Task DeleteClient(Client client);
        Task UpdateClient(Client client);
        Task AddClient(Client client);
        Task  SaveAsync();
    }
}