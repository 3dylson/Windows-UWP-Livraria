using LivrariaVirtualApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LivrariaVirtualAppConsole
{
    internal class LivrariaVirtualContextFactory : IDesignTimeDbContextFactory<LivrariaVirtualDbContext>
    {
        public LivrariaVirtualDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LivrariaVirtualDbContext>();
            builder.UseSqlServer(Program.SqlConnectionString);
            return new LivrariaVirtualDbContext(builder.Options);
        }
    }
}