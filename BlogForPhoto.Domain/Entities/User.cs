using System.ComponentModel.DataAnnotations;
using BlogForPhoto.Domain.Enums;

namespace BlogForPhoto.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.User;
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiry { get; set; }
}