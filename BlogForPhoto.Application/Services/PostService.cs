using BlogForPhoto.Application.DTOs.PostDto;
using BlogForPhoto.Application.IRepository;
using BlogForPhoto.Application.IService;
using BlogForPhoto.Domain.Entities;

namespace BlogForPhoto.Application.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;

    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<PostCreateDto> CreatePostAsync(PostCreateDto dto)
    {
        var post = new Post
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Content = dto.Content,
            ImageUrl = dto.ImageUrl
            
        };
       await  _postRepository.AddPostAsync(post);

        return new PostCreateDto
        {
            Title = post.Title,
            Content = post.Content,
            ImageUrl = post.ImageUrl,
            PostAuthor = post.PostAuthor
        };
        
        

    }

    public async Task<PostResponseDto?> GetPostByIdAsync(Guid id)
    {
        var post = await _postRepository.GetPostById(id);
        if (post is  null)
            return null;
        
        return new PostResponseDto
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            DateCreated = post.DateCreated,
            PostAuthor = post.PostAuthor
        };
    }

    public async Task<PostUpdateDto> UpdatePostAsync(PostUpdateDto dto)
    {
        var existingPost = await _postRepository.GetPostById(dto.Id);
        if (existingPost is null)
            return null;
        
        existingPost.Title = dto.Title;
        existingPost.Content = dto.Content;
        
        await _postRepository.UpdatePost(existingPost);

        return new PostUpdateDto
        {
            Id = existingPost.Id,
            Title = existingPost.Title,
            Content = existingPost.Content,
        };
    }

    public async Task<bool> DeletePostAsync(Guid id)
    {
        var deletePost = await _postRepository.DeletePost(id);
        
        return deletePost;
    }

    public async Task<List<PostResponseDto>> GetAllPostsAsync()
    {
        var posts = await _postRepository.GetAllPosts();
        var response = posts.Select(p => new PostResponseDto
        {
            Id = p.Id,
            Title = p.Title,
            Content = p.Content,
            DateCreated = p.DateCreated,
            PostAuthor = p.PostAuthor
          
        }).ToList();

        return response;
    }

    public async Task<List<PostResponseDto>> SearchPostByTitleAsync(string title)
    {
        var posts = await _postRepository.SearchPostByTitle(title);

        return posts.Select(post => new PostResponseDto
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            DateCreated = post.DateCreated,
            PostAuthor = post.PostAuthor
        }).ToList();
    }
}