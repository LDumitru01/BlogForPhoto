using BlogForPhoto.Application.DTOs.PostDto;
using BlogForPhoto.Domain.Entities;

namespace BlogForPhoto.Application.IService;

public interface IPostService
{
    Task<PostCreateDto> CreatePostAsync(PostCreateDto dto);
    Task<PostResponseDto?> GetPostByIdAsync(Guid id);
    Task<PostUpdateDto> UpdatePostAsync(PostUpdateDto dto);
    Task<bool> DeletePostAsync(Guid id);
    Task<List<PostResponseDto>> GetAllPostsAsync();
    Task<List<PostResponseDto>> SearchPostByTitleAsync(string title);
    
}