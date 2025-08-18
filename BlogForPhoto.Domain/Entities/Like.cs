namespace BlogForPhoto.Domain.Entities;

public class Like
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid PostId { get; set; }
    public DateTime DateCreated { get; set; }
}