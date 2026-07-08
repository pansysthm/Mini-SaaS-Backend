namespace MiniSaaSBackend.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;
    
    public string Email { get; set; } = string.Empty;
    
    public string PasswordHash { get; set; } = string.Empty;
    
    public string Role { get; set; } = "User";
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime? UpdatedAt { get; set; }

    public string? RefreshToken { get; set; }
    
    public DateTime? RefreshTokenExpiryTime { get; set; }

    // Navigation properties
    public ICollection<AppFile> Files { get; set; } = new List<AppFile>();
    public ICollection<AppTask> Tasks { get; set; } = new List<AppTask>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
