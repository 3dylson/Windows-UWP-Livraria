using System;
using Microsoft.EntityFrameworkCore;
using LivrariaVirtualApp.Domain;
using LivrariaVirtualApp.Infrastructure;
using LivrariaVirtualApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivrariaVirtualAppConsole
{
    class Program
    {
        public static string SqlConnectionString = @"Server=localhost; User Id=userLivraria; Password=Livraria; Initial Catalog=LivrariaVirtualApp; Connect Timeout = 30";


        public static IUnitOfWork UOW { get; private set; }

        static async Task Main(string[] args)
        {
            ConfigReposAsync();
        }

        static void ConfigReposAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<LivrariaVirtualDbContext>();
            optionsBuilder.UseSqlServer(Program.SqlConnectionString);

            UOW = new UnitOfWork(optionsBuilder.Options);
        }
    }
}
