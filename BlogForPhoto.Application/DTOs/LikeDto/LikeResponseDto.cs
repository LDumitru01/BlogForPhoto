namespace BlogForPhoto.Application.DTOs.LikeDto;

public class LikeResponseDto
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public DateTime LikedOn { get; set; }
}