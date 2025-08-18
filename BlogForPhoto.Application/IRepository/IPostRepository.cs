using BlogForPhoto.Domain.Entities;

namespace BlogForPhoto.Application.IRepository;

public interface IPostRepository
{
    Task<List<Post>> GetAllPosts();
    Task<Post> GetPostById(Guid id);
    Task AddPostAsync(Post post);
    Task<Post> UpdatePost(Post post);
    Task<bool> DeletePost(Guid id);
    Task<List<Post>> SearchPostByTitle(string title);
}