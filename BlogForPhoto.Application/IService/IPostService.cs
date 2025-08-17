using BlogForPhoto.Application.DTOs.PostDto;
using Microsoft.AspNetCore.Http;

namespace BlogForPhoto.Application.IService;

public interface IPostService
{
    Task<PostResponseDto> CreatePostAsync(PostCreateDto dto);
    Task<PostResponseDto?> GetPostByIdAsync(Guid photoId);
    Task<PostResponseDto> UpdatePostAsync(PostUpdateDto dto);
    Task<bool> DeletePostAsync(Guid photoId);
    Task<List<PostResponseDto>> GetAllPostsAsync();
    Task<List<PostResponseDto>> SearchPostByTitleAsync(string title);
    Task<string> UploadPhotoAsync(Guid photoId,IFormFile file);
    
}