using BlogForPhoto.Application.Models;
using BlogForPhoto.Domain.Entities;
using Microsoft.AspNetCore.Identity.Service;

namespace BlogForPhoto.Application.Services;

public interface IAuthService
{
    Task<User?> RegisterAsync(UserDto request);
    Task<TokenResponseDto?>? LoginAsync(UserDto request);
    Task<TokenResponseDto?>? RefreshTokenAsync(RefreshTokenRequestDto request);
}