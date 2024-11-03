using JWT_Roles_CleanArchitecture.Application.Models;
using JWT_Roles_CleanArchitecture.Core.Entities;
using JWT_Roles_CleanArchitecture.Core.Interfaces;

namespace JWT_Roles_CleanArchitecture.Application.Services
{
    public class AuthService
    {
        private readonly IAuthService _authService;

        public AuthService(IAuthService authService)
        {
            _authService = authService;
        }


        public string Authenticate(AuthRequest request)
        {
            if (_authService.ValidateUser(request.Username, request.Password)) 
            {
                var user = new User { Username = request.Username, Role = request.Username == "admin" ? "Admin" : "User" };
                return _authService.GenerateToken(user);
            }
            return null!;
        }
    }
}
