using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //new HamsterMap(modelBuilder.Entity<Hamster>());
            //modelBuilder.Entity<Battle>()
            //    .HasOne(r => r.WinnerHamster)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Battle>()
            //    .HasOne(r => r.LoserHamster)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.Restrict);

        }

        public DbSet<Hamster> Hamster { get; set; }
        public DbSet<Battle> Battle { get; set; }
    }
}


