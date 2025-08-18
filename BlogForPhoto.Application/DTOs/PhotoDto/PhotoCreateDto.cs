namespace BlogForPhoto.Application.DTOs.PhotoDto;

public class PhotoCreateDto
{
    public Guid PostId { get; set; }
    public string Url { get; set; }
    public string Caption { get; set; }
}