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
        public DbSet<Utilizador> Utilizadores { get; set; }

        public LivrariaVirtualDbContext()
        {
        }

        public LivrariaVirtualDbContext(DbContextOptions<LivrariaVirtualDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>().HasIndex(i => i.Nome).IsUnique();
            modelBuilder.Entity<Autor>().Property(i => i.Nome)
                .IsRequired().HasMaxLength(256);

            modelBuilder.Entity<Editora>().HasIndex(i => i.Nome).IsUnique();
            modelBuilder.Entity<Editora>().Property(i => i.Nome)
                .IsRequired().HasMaxLength(256);
        }

    }
}

