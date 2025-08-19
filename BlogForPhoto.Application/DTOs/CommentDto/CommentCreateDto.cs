namespace BlogForPhoto.Application.DTOs.CommentDto;

public class CommentCreateDto
{
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
    public string Content { get; set; }
}