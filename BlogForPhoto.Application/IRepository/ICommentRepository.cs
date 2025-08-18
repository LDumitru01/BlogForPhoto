using BlogForPhoto.Application.DTOs.CommentDto;
using BlogForPhoto.Domain.Entities;

namespace BlogForPhoto.Application.IRepository;

public interface ICommentRepository
{
    Task<Comment> GetByIdAsync(Guid id);
    Task AddAsync(Comment comment);
    Task DeleteAsync(Guid id);
    Task UpdateAsync(Comment comment);
    Task<int> SaveChangesAsync();
}