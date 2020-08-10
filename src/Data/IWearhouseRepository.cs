using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SEMES.Models;

namespace SEMES.Data
{
    /// <summary>
    /// This class does something.
    /// </summary>
    public interface IWearhouseRepository {
        Task<Wearhouse> GetWearhouse(Wearhouse wearhouse);
        Task DeleteWearhouse(Wearhouse wearhouse);
        Task UpdateWearhouse(Wearhouse wearhouse);
        Task AddWearhouse(Wearhouse wearhouse);
        Task  SaveAsync();
    }
}