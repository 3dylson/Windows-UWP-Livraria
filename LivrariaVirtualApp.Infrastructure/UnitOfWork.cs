﻿using LivrariaVirtualApp.Domain;
using LivrariaVirtualApp.Domain.Repositories;
using LivrariaVirtualApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LivrariaVirtualApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContextOptions<LivrariaVirtualDbContext> Options { get; }

        public ICategoryRepository CategoryRepository => new CategoryRepository(new LivrariaVirtualDbContext(Options));
        public IBookRepository BookRepository => new BookRepository(new LivrariaVirtualDbContext(Options));
        public IOrderRepository OrderRepository => new OrderRepository(new LivrariaVirtualDbContext(Options));
        public IWishlistRepository WishlistRepository => new WishlistRepository(new LivrariaVirtualDbContext(Options));
        public IUserRepository UserRepository => new UserRepository(new LivrariaVirtualDbContext(Options));
        public ICartRepository CartRepository => new CartRepository(new LivrariaVirtualDbContext(Options));

        public UnitOfWork(DbContextOptions<LivrariaVirtualDbContext> options)
        {
            Options = options;

            using (var _dbContext = new LivrariaVirtualDbContext(options))
            {
                _dbContext.Database.Migrate();
            }
        }
    }
}