using BlogForPhoto.Application.DTOs.CommentDto;
using BlogForPhoto.Application.IRepository;
using BlogForPhoto.Application.IService;
using BlogForPhoto.Domain.Entities;

namespace BlogForPhoto.Application.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<CommentResponseDto> GetCommentByIdAsync(Guid id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        if (comment == null)
            return null;

        return new CommentResponseDto()
        {
            Id = comment.Id,
            Content = comment.Content,
            UserName = comment.User!.Username,
            DateCreated = comment.DateCreated
        };
    }

    public async Task<CommentResponseDto> CreateCommentAsync(CommentCreateDto commentCreateDto)
    {
        var createComment = new Comment
        {
            Id = Guid.NewGuid(),
            PostId = commentCreateDto.PostId,
            UserId = commentCreateDto.UserId,
            Content = commentCreateDto.Content,
            DateCreated = DateTime.UtcNow
        };
        
        await _commentRepository.AddAsync(createComment);

        return new CommentResponseDto
        {
            Id = createComment.Id,
            Content = createComment.Content,
            UserName = createComment.User!.Username,
            DateCreated = createComment.DateCreated
        };


    }

    public async Task<CommentResponseDto> UpdateCommentAsync(Guid id, CommentUpdateDto commentUpdateDto)
    {
        var existingComment = await _commentRepository.GetByIdAsync(id);
        if(existingComment == null)
            return null;
        
        existingComment.Content = commentUpdateDto.Content;
        await _commentRepository.UpdateAsync(existingComment);

        return new CommentResponseDto
        {
            Id = existingComment.Id,
            Content = existingComment.Content,
            UserName = existingComment.User!.Username,
            DateCreated = existingComment.DateCreated
        };
    }

    public async Task<CommentResponseDto> DeleteCommentAsync(Guid id)
    {
        var deletedComment = await _commentRepository.GetByIdAsync(id);
        
        if(deletedComment == null)
            return null;
        
        await _commentRepository.DeleteAsync(id);

        return new CommentResponseDto
        {
            Id = deletedComment.Id,
            Content = deletedComment.Content,
            UserName = deletedComment.User!.Username,
            DateCreated = deletedComment.DateCreated
        };
    }
}