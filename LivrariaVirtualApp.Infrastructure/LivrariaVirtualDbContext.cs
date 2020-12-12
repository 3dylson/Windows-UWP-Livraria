using Microsoft.EntityFrameworkCore;
using LivrariaVirtualApp.Domain.Models;
using System;

namespace LivrariaVirtualApp.Infrastructure
{
    public class LivrariaVirtualDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        

        public LivrariaVirtualDbContext()
        {
        }

        public LivrariaVirtualDbContext(DbContextOptions<LivrariaVirtualDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Category Entity
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(45);
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Books)
                .WithOne();
            //Book Entity
            modelBuilder.Entity<Book>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<Book>()
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(80);
            modelBuilder.Entity<Book>()
                .Property(b => b.ISBN)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Entity<Book>()
                .Property(b => b.Parental_guide)
                .HasMaxLength(3);
            modelBuilder.Entity<Book>()
                .Property(b => b.Language)
                .IsRequired()
                .HasMaxLength(45);
            modelBuilder.Entity<Book>()
                .Property(b => b.Price)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(b => b.Available)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(b => b.Realease_date)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(b => b.Publisher)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Book>()
                .Property(b => b.Pages)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Entity<Book>()
                .Property(b => b.Overview)
                .IsRequired()
                .HasMaxLength(256);
            modelBuilder.Entity<Book>()
                .Property(b => b.Image)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.Category_id);
            //Cart Entity
            modelBuilder.Entity<Cart>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Cart>()
                .Property(c => c.Quantity)
                .IsRequired();
            modelBuilder.Entity<Cart>()
                .Property(c => c.Subtotal)
                .IsRequired();
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithOne(c => c.Cart)
                .HasForeignKey<User>(u => u.Id );
            //Order Entity
            modelBuilder.Entity<Order>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Order>()
                .Property(o => o.Total)
                .IsRequired();
            modelBuilder.Entity<Order>()
                .Property(o => o.Date_created)
                .IsRequired();
            modelBuilder.Entity<Order>()
                .Property(o => o.Status)
                .IsRequired();
            modelBuilder.Entity<Order>()
                .Property(o => o.Shipping_address)
                .IsRequired();
            //Wishlist Entity
            modelBuilder.Entity<Wishlist>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Wishlist>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(45);
            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.User)
                .WithMany(u => u.Wishlists)
                .HasForeignKey(w => w.User_id);
            //User Entity
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired(false)
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired(false)
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired(false)
                .HasMaxLength(45);
            modelBuilder.Entity<User>()
                .Property(u => u.Birth_date)
                .IsRequired(false);
            modelBuilder.Entity<User>()
                .Property(u => u.Phone)
                .IsRequired(false)
                .HasMaxLength(20);
            modelBuilder.Entity<User>()
                .Property(u => u.Admin)
                .IsRequired()
                .HasDefaultValue(0);



        }

    }
}

