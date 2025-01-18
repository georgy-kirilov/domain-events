using Microsoft.EntityFrameworkCore;

namespace Sandbox;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Card> Cards => Set<Card>();
    
    public DbSet<Plastic> Plastics => Set<Plastic>();
}
