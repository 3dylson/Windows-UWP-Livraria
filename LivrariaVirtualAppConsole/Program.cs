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

            Category cat = new Category();
            cat.Id = 1;
            cat.Name = "Romance";
            Category cat1 = new Category();
            cat1.Name = "Drama";
            Category cat2 = new Category();
            cat2.Name = "Ficção";
            await UOW.CategoryRepository.CreateAsync(cat);
            await UOW.CategoryRepository.CreateAsync(cat1);
            await UOW.CategoryRepository.CreateAsync(cat2);

            Book bk = new Book();
            bk.Name = "A promised Land";
            bk.ISBN = "21354631";
            bk.Parental_guide = "+12";
            bk.Language = "EN";
            bk.Price = 19;
            bk.Publisher = "Editora";
            bk.Pages = null;
            bk.Overview = "Lorem Ipsum";
            bk.Image = null;
            bk.Category_id = 1;
            await UOW.BookRepository.CreateAsync(bk);

        }
    }
}