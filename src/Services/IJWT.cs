using SEMES.Models;

namespace SEMES.Services
{
    interface IJWT{
        string GenerateJSONWebToken(SemesUser user);
        bool ValidateJSONWebToken(string token);
    }
}
