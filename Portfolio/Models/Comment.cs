namespace Portfolio.Models;

public class Comment
{
    public int Id { get; set; }
    public string ProjectSlug { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}