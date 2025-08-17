using BlogForPhoto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogForPhoto.Persistence.Data.PostContext;

public class PostDbContext(DbContextOptions<PostDbContext> options) : DbContext(options)
{
    public DbSet<Post> Posts { get; set; }
}