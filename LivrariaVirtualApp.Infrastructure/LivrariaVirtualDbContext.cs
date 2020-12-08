using Microsoft.EntityFrameworkCore;
using LivrariaVirtualApp.Domain.Models;
using System;

namespace LivrariaVirtualApp.Infrastructure
{
    public class LivrariaVirtualDbContext : DbContext
    {
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Livraria> Livrarias { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Parceiro> Parceiros { get; set; }
        public DbSet<User> Utilizadores { get; set; }

        public LivrariaVirtualDbContext()
        {
        }

        public LivrariaVirtualDbContext(DbContextOptions<LivrariaVirtualDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>()
                .HasIndex(a => a.ID)
                .IsUnique();
            
                
            modelBuilder.Entity<Editora>()
                .HasIndex(e => e.ID)
                .IsUnique();


            modelBuilder.Entity<Livraria>()
                .HasIndex(l => l.ID)
                .IsUnique();

            modelBuilder.Entity<Livro>()
                .HasIndex(l => l.ID)
                .IsUnique();
            


        }

    }
}

