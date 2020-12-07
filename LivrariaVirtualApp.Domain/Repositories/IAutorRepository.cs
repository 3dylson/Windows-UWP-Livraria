using LivrariaVirtualApp.Domain.Models;
using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace LivrariaVirtualApp.Domain.Repositories
{
    public interface IAutorRepository : IRepository<Autor>
    {
        Task<Autor> FindByNameAsync(string nome);
        Task<List<Autor>> FindAllByNameStartWithAsync(string nacionalidade);
    }
}
