using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {         
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new HamsterMap(modelBuilder.Entity<Hamster>());
        new BattleMap(modelBuilder.Entity<Battle>());
    }

    public DbSet<Hamster> Hamster { get; set; }
    public DbSet<Battle> Battle { get; set; }
}


