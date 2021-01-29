using LivrariaVirtualApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivrariaVirtualApp.Domain.Repositories
{
    public interface ICartRepository
    {
        Task<List<Cart>> FindAllByUserIdAsync(int userId);
    }
}