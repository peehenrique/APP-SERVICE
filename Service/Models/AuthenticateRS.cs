using Service.Entities;

namespace Service.Models;

public class AuthenticateRS
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Token { get; set; }

    public AuthenticateRS(User user, string token)
    {
        Id = user.Id;
        Name = user.Name;
        Username = user.Username;
        Token = token;
    }
}
