using LivrariaVirtualApp.Domain.Models;
using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaVirtualApp.Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> FindByNameAsync(string name);
        Task<List<Category>> FindAllByNameStartWithAsync(string name);
        Task<Category> FindOrCreate(Category e);
        Task<Category> UpsertAsync(Category e);

    }
}
