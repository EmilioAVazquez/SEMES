using SEMES.Models;

namespace SEMES.Services
{
    public interface IJWT{
        string GenerateJSONWebToken(SemesUser user);
        bool ValidateJSONWebToken(string token);
    }
}
