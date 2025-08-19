using BlogForPhoto.Application.DTOs.CommentDto;

namespace BlogForPhoto.Application.IService;

public interface ICommentService
{
    Task<CommentResponseDto> GetCommentByIdAsync(Guid id);  
    Task<CommentResponseDto> CreateCommentAsync(CommentCreateDto commentCreateDto);
    Task<CommentResponseDto> UpdateCommentAsync(Guid id, CommentUpdateDto commentUpdateDto);
    Task<CommentResponseDto> DeleteCommentAsync(Guid id);
}