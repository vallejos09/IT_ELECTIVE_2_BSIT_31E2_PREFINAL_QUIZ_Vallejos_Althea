using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Data;

public class PortfolioContext(DbContextOptions<PortfolioContext> options) : DbContext(options)
{
    public DbSet<Comment> Comments => Set<Comment>();

    protected override void OnModelCreating(ModelBuilder b) =>
        b.Entity<Comment>().HasIndex(c => c.ProjectSlug);
}