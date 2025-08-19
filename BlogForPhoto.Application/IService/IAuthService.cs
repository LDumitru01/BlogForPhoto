using BlogForPhoto.Application.DTOs.UserDto;
using BlogForPhoto.Application.Models;
using BlogForPhoto.Domain.Entities;

namespace BlogForPhoto.Application.IService;

public interface IAuthService
{
    Task<User> RegisterAsync(UserDto request);
    Task<TokenResponseDto> LoginAsync(UserDto request);
    Task<TokenResponseDto> RefreshTokenAsync(RefreshTokenRequestDto request);
}