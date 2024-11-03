using JWT_Roles_CleanArchitecture.Application.Models;
using JWT_Roles_CleanArchitecture.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Roles_CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthRequest request)
        {
            var token = _authService.Authenticate(request);
            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }


        

    }
}
