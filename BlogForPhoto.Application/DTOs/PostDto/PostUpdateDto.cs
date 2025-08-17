using Microsoft.AspNetCore.Http;

namespace BlogForPhoto.Application.DTOs.PostDto;

public class PostUpdateDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string ImageUrl { get; set; }
}