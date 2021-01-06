using LivrariaVirtualApp.Domain.Models;
using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace LivrariaVirtualApp.Domain.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> FindByNameAsync(string name);
        Task<List<Book>> FindAllByCategoryStartWithAsync(int category_id, string name);

    }
}
