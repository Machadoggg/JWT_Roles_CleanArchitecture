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
            //var token = _authService.Authenticate(request);
            //if (token == null)
            //    return Unauthorized();

            //return Ok(new { token });

            var token = _authService.Authenticate(request);
            if (token == null)
            {
                    return Unauthorized();
            }
            
            var userRole = User.IsInRole("Admin") ? "Admin" : "User";

            if (userRole == "Admin")
            {
                return Ok(new { message = "Redirect to admin area", endpoint = "/api/secure/admin" });
            }
            return Ok(new { message = "Redirect to user area", endpoint = "/api/secure/user" });

        }


        [Authorize(Policy = "AdminPolicy")]
        [HttpGet("admin")]
        public IActionResult AdminEndpoint()
        {
            return Ok("Este es un endpoint solo para administradores.");
        }

        [Authorize(Policy = "UserPolicy")]
        [HttpGet("user")]
        public IActionResult UserEndpoint()
        {
            return Ok("Este es un endpoint solo para usuarios.");
        }


    }
}
