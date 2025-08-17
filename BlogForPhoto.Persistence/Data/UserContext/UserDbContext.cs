using BlogForPhoto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogForPhoto.Persistence.Data.UserContext;

public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}