using BlogForPhoto.Application.IRepository;
using BlogForPhoto.Domain.Entities;
using BlogForPhoto.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogForPhoto.Application.Repository;

public class PostRepository : IPostRepository
{
    private readonly BlogDbContext _postContext;

    public PostRepository(BlogDbContext context)
    {
        _postContext = context;
    }

    public async Task<List<Post>> GetAllPosts()
    {
        return await _postContext.Posts.ToListAsync();
    }

    public async Task<Post> GetPostById(Guid id)
    {
        var post = await _postContext.Posts.FirstOrDefaultAsync(p => p.Id == id);
        if (post is null)
            return null;
        return post;
    }

    public async Task AddPostAsync(Post post)
    {
        _postContext.Posts.Add(post);
        await _postContext.SaveChangesAsync();
    }
    
    public async Task<Post> UpdatePost(Post post)
    {
        _postContext.Posts.Update(post);
        await _postContext.SaveChangesAsync();
        return post;
    }

    public async Task<bool> DeletePost(Guid id)
    {
        var post = _postContext.Posts.Find(id);
        if (post is null)
        {
            return false;
        }
        _postContext.Posts.Remove(post);
        await _postContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<Post>> SearchPostByTitle(string title)
    {
        return await _postContext.Posts.Where(p => p.Title == title.ToLower()).ToListAsync();
    }
}