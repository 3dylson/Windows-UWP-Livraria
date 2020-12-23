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
        Task<List<Book>> FindAllByUserIdAsync(int user_id);
        Task<Book> FindByNameAsync(string name);
        Task<List<Book>> FindAllByCategoryStartWithAsync(int category_id, string name);
        Task<List<Book>> FindAllByCartStartWithAsync(int cart_id, string quantity);
        Task<List<Book>> FindAllByWishlistStartWithAsync(int wishlist_id, string name_wishlist);
       
        /// <summary>
        /// Returns all products with a data field matching the start of the given string. 
        /// </summary>
        Task<IEnumerable<Book>> GetAsync(string search);
    }
}
