using LivrariaVirtualApp.Domain.Models;
using LivrariaVirtualApp.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivrariaVirtualApp.Domain.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> FindByNameAsync(string name);

        Task<List<Book>> FindAllByCategoryStartWithAsync(int category_id, string name);

        Task<List<Book>> FindAllByUserIdAsync(int userId);

        Task<List<Book>> FindAllByUserIdAndWishlistAsync(int userId, int wishlist_id);

        //Task<IList<Book>> GetBooksAsync(DataRequest<Book> request);
    }
}