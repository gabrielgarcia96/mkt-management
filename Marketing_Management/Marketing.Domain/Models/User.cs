using Marketing.Domain.Enums;
using MongoDB.Bson;

namespace Marketing.Domain.Models;

public class User
{
    public string Id = ObjectId.GenerateNewId().ToString();
    public string Username { get; set; } 
    public string Email { get; set;} 
    public string Password { get; set; } 
    public Role Role { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(-3);
}
