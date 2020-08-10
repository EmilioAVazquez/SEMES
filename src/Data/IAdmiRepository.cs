using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SEMES.Models;

namespace SEMES.Data
{
    /// <summary>
    /// This class does something.
    /// </summary>
    public interface IAdmiRepository {
        Task<Admi> GetAdmi(Admi admi);
        Task DeleteAdmi(Admi admi);
        Task UpdateAdmi(Admi admi);
        Task AddAdmi(Admi admi);
        Task  SaveAsync();
    }
}