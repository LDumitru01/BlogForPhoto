namespace BlogForPhoto.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; }
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public string? Content { get; set; }
    public DateTime DateCreated { get; set; }
}