using LivrariaVirtualApp.Domain.Models;
using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaVirtualApp.Domain.Repositories
{
    public interface IEditoraRepository : IRepository<Editora>
    {
        Task<Editora> FindByNameAsync(string nome);
        Task<List<Editora>> FindAllByNameStartWithAsync(string distrito);
    }
}
