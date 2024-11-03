namespace JWT_Roles_CleanArchitecture.Core.Entities
{
    public class User
    {
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Role { get; set; } = default!;
    }
}
