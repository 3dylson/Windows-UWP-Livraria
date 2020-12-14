﻿// <auto-generated />
using System;
using LivrariaVirtualApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LivrariaVirtualApp.Infrastructure.Migrations
{
    [DbContext(typeof(LivrariaVirtualDbContext))]
    [Migration("20201208135622_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LivrariaVirtualApp.Domain.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Available")
                        .HasColumnType("int");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("Category_id")
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("Overview")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Pages")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Parental_guide")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("Realease_date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WishlistId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("Category_id");

                    b.HasIndex("WishlistId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LivrariaVirtualApp.Domain.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("User_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("User_id")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("LivrariaVirtualApp.Domain.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("LivrariaVirtualApp.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("Book_id")
                        .HasColumnType("int");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("Cart_id")
                        .HasColumnType("int");

                    b.Property<int>("Date_created")
                        .HasColumnType("int");

                    b.Property<string>("Shipping_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("User_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("Book_id");

                    b.HasIndex("CartId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("LivrariaVirtualApp.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Admin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Birth_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LivrariaVirtualApp.Domain.Models.Wishlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Book_id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<int>("User_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("User_id");

                    b.ToTable("Wishlists");
                });

            modelBuilder.Entity("LivrariaVirtualApp.Domain.Models.Book", b =>
                {
                    b.HasOne("LivrariaVirtualApp.Domain.Models.Cart", null)
                        .WithMany("Books")
                        .HasForeignKey("CartId");

                    b.HasOne("LivrariaVirtualApp.Domain.Models.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("Category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LivrariaVirtualApp.Domain.Models.Wishlist", null)
                        .WithMany("Books")
                        .HasForeignKey("WishlistId");
                });

            modelBuilder.Entity("LivrariaVirtualApp.Domain.Models.Cart", b =>
                {
                    b.HasOne("LivrariaVirtualApp.Domain.Models.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("LivrariaVirtualApp.Domain.Models.Cart", "User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LivrariaVirtualApp.Domain.Models.Order", b =>
                {
                    b.HasOne("LivrariaVirtualApp.Domain.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("LivrariaVirtualApp.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Book_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LivrariaVirtualApp.Domain.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId");
                });

            modelBuilder.Entity("LivrariaVirtualApp.Domain.Models.Wishlist", b =>
                {
                    b.HasOne("LivrariaVirtualApp.Domain.Models.User", "User")
                        .WithMany("Wishlists")
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
