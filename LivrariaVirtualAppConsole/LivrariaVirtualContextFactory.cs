using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using LivrariaVirtualApp.Infrastructure;

namespace LivrariaVirtualAppConsole 
{
    class LivrariaVirtualContextFactory : IDesignTimeDbContextFactory<LivrariaVirtualDbContext>
    {
        public LivrariaVirtualDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LivrariaVirtualDbContext>();
            builder.UseSqlServer(Program.SqlConnectionString);
            return new LivrariaVirtualDbContext(builder.Options);
        }



    }
}
