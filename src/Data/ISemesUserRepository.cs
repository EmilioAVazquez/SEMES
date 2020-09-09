using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SEMES.Models;
using System.Collections.Generic;

namespace SEMES.Data
{
    /// <summary>
    /// This class does something.
    /// </summary>
    public interface ISemesUserRepository {
        Task<SemesUser> GetSemesUserByEmail(string email);
        Task<SemesUser> AddSemesUser(SemesUser user);
        Task  SaveAsync();
    }
}