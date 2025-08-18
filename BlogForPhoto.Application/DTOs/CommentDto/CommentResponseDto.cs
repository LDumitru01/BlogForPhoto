namespace BlogForPhoto.Application.DTOs.CommentDto;

public class CommentResponseDto
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public string UserName { get; set; }
    public DateTime DateCreated { get; set; }
}