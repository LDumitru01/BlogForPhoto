namespace BlogForPhoto.Domain.Entities;

public class Photo
{
    public Guid Id { get; set; }
    public Guid PostId { get; set; }
    public string? Url { get; set; }
    public string? Caption { get; set; }
    public DateTime DateUploaded { get; set; }
    
}