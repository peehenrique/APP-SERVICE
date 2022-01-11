namespace Service.Entities;

public class User : Entity
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
