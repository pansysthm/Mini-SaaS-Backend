namespace MiniSaaSBackend.Entities;

public class AppTask
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public Guid UserId { get; set; }
    public User? User { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Status { get; set; } = "Pending";
    
    public string? Result { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime? RunAt { get; set; }
    
    public DateTime? CompletedAt { get; set; }
}
