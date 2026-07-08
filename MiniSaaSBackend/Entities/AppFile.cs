namespace MiniSaaSBackend.Entities;

public class AppFile
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public Guid UserId { get; set; }
    public User? User { get; set; } // tránh lazy loading nên không dùng virtual
    
    public string FileName { get; set; } = string.Empty;
    
    public string FilePath { get; set; } = string.Empty;
    
    public long FileSize { get; set; }
    
    public string ContentType { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
