using Microsoft.EntityFrameworkCore;
using LivrariaVirtualApp.Domain.Models;
using System;

namespace LivrariaVirtualApp.Infrastructure
{
    public class LivrariaVirtualDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        

        public LivrariaVirtualDbContext()
        {
        }

        public LivrariaVirtualDbContext(DbContextOptions<LivrariaVirtualDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(45);
                









        }

    }
}

