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
                .HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(60);
            //Book Entity
            modelBuilder.Entity<Book>()
                .HasIndex(b => b.Name).IsUnique();
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
            //modelBuilder.Entity<Book>()
            //    .Property(b => b.Realease_date)
            //    .IsRequired();
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
                .HasForeignKey(b => b.Category_id)
                .OnDelete(DeleteBehavior.Restrict);
            //Cart Entity
            modelBuilder.Entity<Cart>()
                .Property(c => c.Quantity)
                .IsRequired();       
            modelBuilder.Entity<Cart>()
                .HasKey(x => new { x.BookId, x.OrderId });
            //Order Entity
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
                .Property(o => o.UserOrdering)
                .IsRequired(false);
            modelBuilder.Entity<Order>()
                .Property(o => o.Shipping_address)
                .IsRequired();
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.User_id);
            //Wishlist Entity
            modelBuilder.Entity<Wishlist>()
                .HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Wishlist>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(45);
            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.User)
                .WithMany(u => u.Wishlists)
                .HasForeignKey(o => o.User_id)
                .OnDelete(DeleteBehavior.Restrict);
            //User Entity
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
                .Property(u => u.Phone)
                .IsRequired(false)
                .HasMaxLength(20);
            modelBuilder.Entity<User>()
                .Property(u => u.Address)
                .IsRequired(false)
                .HasMaxLength(256);
            modelBuilder.Entity<User>()
                .Property(u => u.Admin)
                .IsRequired()
                .HasDefaultValue(0);
            //Admin User created on DB building
            modelBuilder.Entity<User>().HasData(new User
            { Id = 1, Name = "admin", Email = "admin@admin.com", Password = "admin", Admin = 1 });


        }

    }
}

