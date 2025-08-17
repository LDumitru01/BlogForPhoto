namespace BlogForPhoto.Application.DTOs.PostDto;

public class PostResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Content { get; set; } = String.Empty;
    public DateTime DateCreated { get; set; }
    public string PostAuthor { get; set; } = String.Empty;
}