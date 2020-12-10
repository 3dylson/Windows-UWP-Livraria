using Microsoft.EntityFrameworkCore;
using LivrariaVirtualApp.Domain;
using LivrariaVirtualApp.Domain.Repositories;
using LivrariaVirtualApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaVirtualApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContextOptions<LivrariaVirtualDbContext> Options { get; }

        

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

