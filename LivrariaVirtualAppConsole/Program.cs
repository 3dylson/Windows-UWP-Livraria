using LivrariaVirtualApp.Domain;
using LivrariaVirtualApp.Domain.Models;
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
            await ConfigReposAsync();
        }

        private static async Task ConfigReposAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<LivrariaVirtualDbContext>();
            optionsBuilder.UseSqlServer(Program.SqlConnectionString);

            UOW = new UnitOfWork(optionsBuilder.Options);

            Category cat = new Category
            {
                Name = "Romance"
            };

            await UOW.CategoryRepository.CreateAsync(cat);

        }
    }
}