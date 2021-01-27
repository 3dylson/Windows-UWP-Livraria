using LivrariaVirtualApp.Domain;
using LivrariaVirtualApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LivrariaVirtualAppConsole
{
    internal class Program
    {
        public static string SqlConnectionString = @"Server=tcp:localhost;Initial Catalog=dbLivraria; User ID=userLivraria; Password=Livraria; Connection Timeout = 30;";

        public static IUnitOfWork UOW { get; private set; }

        private static async Task Main(string[] args)
        {
            ConfigReposAsync();
        }

        private static void ConfigReposAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<LivrariaVirtualDbContext>();
            optionsBuilder.UseSqlServer(Program.SqlConnectionString);

            UOW = new UnitOfWork(optionsBuilder.Options);
        }
    }
}