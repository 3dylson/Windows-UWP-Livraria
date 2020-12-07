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

        public IAutorRepository AutorRepository => new AutorRepository(new LivrariaVirtualDbContext(Options));

        public IEditoraRepository EditoraRepository => new EditoraRepository(new LivrariaVirtualDbContext(Options));
        public ILivrariaRepository LivrariaRepository => new LivrariaRepository(new LivrariaVirtualDbContext(Options));
        public ILivroRepository LivroRepository => new LivroRepository(new LivrariaVirtualDbContext(Options));
        public IParceirosRepository ParceirosRepository => new ParceirosRepository(new LivrariaVirtualDbContext(Options));
        public IUtilizadorRepository UtilizadorRepository => new UtilizadorRepository(new LivrariaVirtualDbContext(Options));

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

