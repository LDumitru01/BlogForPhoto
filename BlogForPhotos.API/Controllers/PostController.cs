using BlogForPhoto.Application.DTOs.PostDto;
using BlogForPhoto.Application.IService;
using BlogForPhoto.Domain.Entities;
using BlogForPhoto.Persistence.Data.PostContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogForPhotos.Controllers;

[Route("Api/[controller]")]
[ApiController]

public class PostController(IPostService postService, PostDbContext postDbcontext) : ControllerBase
{
    private readonly PostDbContext _postDbcontext = postDbcontext;
    private readonly IPostService _postService = postService;

    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost(PostCreateDto request)
    {
        var post = await _postService.CreatePostAsync(request);
        return Ok(post);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PostResponseDto>> GetPostById(Guid id)
    {
        var post = await _postService.GetPostByIdAsync(id);

        if (post == null)
            return NotFound("Post not found.");

        return Ok(post);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchByTitle([FromQuery] string title)
    {
        var post = await _postDbcontext.Posts
            .FirstOrDefaultAsync(p => p.Title.ToLower().Contains(title.ToLower()));

        if (post == null)
            return NotFound("No post found with this title.");

        return Ok(post);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<PostUpdateDto>> UpdatePost(Guid id, [FromBody] PostUpdateDto request)
    {
        if (id != request.Id)
            return BadRequest("Id not found");

        var updatedPost = await _postService.UpdatePostAsync(request);

        return Ok(updatedPost);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(Guid id)
    {
        var result = await _postService.DeletePostAsync(id);
        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPosts()
    {
        var posts = await _postService.GetAllPostsAsync();
        return Ok(posts);
    }
}
