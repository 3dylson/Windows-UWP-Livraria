using LivrariaVirtualApp.Domain.Models;
using LivrariaVirtualApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaVirtualApp.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        protected readonly LivrariaVirtualDbContext _dbContext;

        public CartRepository(LivrariaVirtualDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Cart>> FindAllByUserIdAsync(int userId)

        {
            return _dbContext.Carts
                  .Where(e => e.UserId == userId).ToListAsync();
        }
    }
}