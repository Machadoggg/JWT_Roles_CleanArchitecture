﻿namespace JWT_Roles_CleanArchitecture.Application.Models
{
    public class AuthRequest
    {
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
