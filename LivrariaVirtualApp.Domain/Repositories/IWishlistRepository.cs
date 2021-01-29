using LivrariaVirtualApp.Domain.Models;
using LivrariaVirtualApp.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivrariaVirtualApp.Domain.Repositories
{
    public interface IWishlistRepository : IRepository<Wishlist>
    {
        Task<Wishlist> FindByNameAsync(string name_wishlist);

        Task<List<Wishlist>> FindAllByNameStartWithAsync(string name_wishlist);

        Task<List<Wishlist>> FindAllByUserIdAsync(int userId);
    }
}