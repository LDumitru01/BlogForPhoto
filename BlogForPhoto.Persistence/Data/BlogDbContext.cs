using BlogForPhoto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogForPhoto.Persistence.Data;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> options)
        : base(options)
    {
    }

    public DbSet<Comment> Comments { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<User> Users { get; set; }
}