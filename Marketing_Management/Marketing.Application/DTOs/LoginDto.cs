using Marketing.Domain.Enums;

public class LoginDto
{
    public string Token { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Role Roles { get; set; }
}
