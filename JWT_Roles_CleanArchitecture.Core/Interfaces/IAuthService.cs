using JWT_Roles_CleanArchitecture.Core.Entities;

namespace JWT_Roles_CleanArchitecture.Core.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(User user);
        bool ValidateUser(string username, string password);
    }
}
