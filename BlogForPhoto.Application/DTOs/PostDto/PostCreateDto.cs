using Microsoft.AspNetCore.Http;

namespace BlogForPhoto.Application.DTOs.PostDto;

public class PostCreateDto
{
    public string Title { get; set; } = String.Empty;
    public string Content { get; set; } = String.Empty;
    public string PostAuthor { get; set; } = String.Empty;
    public IFormFile ImageFile { get; set; }
}