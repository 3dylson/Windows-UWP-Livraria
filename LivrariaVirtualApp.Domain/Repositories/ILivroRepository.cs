using LivrariaVirtualApp.Domain.Models;
using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace LivrariaVirtualApp.Domain.Repositories
{
    public interface ILivroRepository : IRepository<Livro>
    {
        Task<Livro> FindByNameAsync(string nome);
        Task<List<Livro>> FindAllByNameStartWithAsync(string genero);


    }
}
