using BlogForPhoto.Application.DTOs.PostDto;
using BlogForPhoto.Application.IRepository;
using BlogForPhoto.Application.IService;
using BlogForPhoto.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace BlogForPhoto.Application.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public PostService(IPostRepository postRepository, IWebHostEnvironment webHostEnvironment)
    {
        _postRepository = postRepository;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<PostResponseDto> CreatePostAsync(PostCreateDto dto)
    {
        var post = new Post
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Content = dto.Content,
            PostAuthor = dto.PostAuthor,
        };
        if (dto.ImageFile == null || dto.ImageFile.Length == 0)
            throw new ArgumentException("File is null or empty", nameof(dto.ImageFile));

        var uploadsFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "uploads");

        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(dto.ImageFile.FileName)}";
        var filePath = Path.Combine(uploadsFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await dto.ImageFile.CopyToAsync(stream);
        }

        post.ImageUrl =  $"/uploads/{fileName}";
        
       await  _postRepository.AddPostAsync(post);

        return new PostResponseDto()
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            ImageUrl = post.ImageUrl,
            PostAuthor = post.PostAuthor
        };
    }

    public async Task<PostResponseDto?> GetPostByIdAsync(Guid photoId)
    {
        var post = await _postRepository.GetPostById(photoId);
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

    public async Task<PostResponseDto> UpdatePostAsync(PostUpdateDto dto)
    {
        var existingPost = await _postRepository.GetPostById(dto.Id);
        if (existingPost is null)
            return null;
        
        existingPost.Title = dto.Title;
        existingPost.Content = dto.Content;
        existingPost.ImageUrl = dto.ImageUrl;

        await _postRepository.UpdatePost(existingPost);

        return new PostResponseDto()
        {
            Id = existingPost.Id,
            Title = existingPost.Title,
            Content = existingPost.Content,
        };
    }

    public async Task<bool> DeletePostAsync(Guid photoId)
    {
        var deletePost = await _postRepository.DeletePost(photoId);
        
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

    public async Task<string> UploadPhotoAsync(Guid postId, IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("File is null or empty", nameof(file));

        var uploadsFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "uploads");

        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(uploadsFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return $"/uploads/{fileName}";
    }

}