
using BlogForPhoto.Application.DTOs.UserDto;
using BlogForPhoto.Application.IService;
using BlogForPhoto.Application.Models;
using BlogForPhoto.Application.Services;
using BlogForPhoto.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BlogForPhotos.Controllers;

[Route("Api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("Register")]
    public async Task<ActionResult<User>> Register(UserDto request)
    {
        var user = await authService.RegisterAsync(request);
        if (user is null)
            return BadRequest("Username already exists");
        return Ok(user);
    }

    [HttpPost("Login")]
    public async Task<ActionResult<TokenResponseDto>> Login(UserDto request)
    {
        var result = await authService.LoginAsync(request)!;
        if (result is null)
            return BadRequest("Username or password is incorrect");
        return Ok(result);
    }

    [HttpPost("refresh-token")]
    public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto request)
    {
        var result = await authService.RefreshTokenAsync(request)!;
        if(result is null || result.RefreshToken is null || result.AccesToken is null)
            return Unauthorized("Invalid refresh token");
        
        return Ok(result);
    }

    [Authorize]
    [HttpGet]
    public IActionResult AuthenticatedOnlyEndpoints()
    {
        return Ok("You are authenticated");
    }
}