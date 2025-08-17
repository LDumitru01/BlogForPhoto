using System.ComponentModel.DataAnnotations;

namespace BlogForPhoto.Domain.Entities;

public class Post
{
    public Guid Id { get; set; }
    [StringLength(50)]
    public string Title { get; set; } = string.Empty;
    [StringLength(564)]
    public string Content { get; set; } = string.Empty;
    public int UserId { get; set; }
    public DateTime DateCreated { get; set; }
    [StringLength(256)]
    public string ImageUrl { get; set; } = string.Empty;
    
    [StringLength(50)]
    public string PostAuthor { get; set; } = string.Empty;
}