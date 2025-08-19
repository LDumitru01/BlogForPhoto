using BlogForPhoto.Application.DTOs.CommentDto;
using BlogForPhoto.Application.IService;
using Microsoft.AspNetCore.Mvc;

namespace BlogForPhotos.Controllers;

[ApiController]
[Route("[controller]")]

public class CommentController : ControllerBase
{
    public readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CommentResponseDto>> GetComment(Guid id)
    {
        var comment = _commentService.GetCommentByIdAsync(id);
        if (comment == null) return BadRequest();
        return Ok(await comment);
    }
    
    [HttpPost]
    public async Task<ActionResult<CommentResponseDto>> CreateComment(CommentCreateDto dto)
    {
        var created = await _commentService.CreateCommentAsync(dto);
        return CreatedAtAction(nameof(GetComment), new { id = created.Id }, created);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<CommentResponseDto?>> UpdateComment(Guid id, CommentUpdateDto dto)
    {
        var updated = await _commentService.UpdateCommentAsync(id, dto);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<CommentResponseDto?>> DeleteComment(Guid id)
    {
        var deleted = await _commentService.DeleteCommentAsync(id);
        if (deleted == null) return NotFound();
        return Ok(deleted);
    }
    
}