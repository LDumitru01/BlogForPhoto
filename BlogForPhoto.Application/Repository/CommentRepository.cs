using BlogForPhoto.Application.IRepository;
using BlogForPhoto.Domain.Entities;
using BlogForPhoto.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogForPhoto.Application.Repository;

public class CommentRepository : ICommentRepository
{
    private readonly BlogDbContext _context;

    public CommentRepository(BlogDbContext context)
    {
        _context = context;
    }


    public async Task<Comment> GetByIdAsync(Guid id)
    {
        return await _context.Comments
            .Include(c => c.User)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(Comment comment)
    {
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var delteComment = await _context.Comments.FindAsync(id);
        if (delteComment != null)
        {
            _context.Comments.Remove(delteComment);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(Comment comment)
    {
        var exsistingComment = await _context.Comments.FindAsync(comment.Id);
        if (exsistingComment != null)
        {
            _context.Entry(exsistingComment).CurrentValues.SetValues(comment);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<int> SaveChangesAsync()
    {
       return await _context.SaveChangesAsync();
    }
}