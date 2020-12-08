using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LivrariaVirtualApp.Domain.Models;
using LivrariaVirtualApp.Domain.Repositories;
using System.Threading.Tasks;
using System.Linq;

namespace LivrariaVirtualApp.Infrastructure.Repositories
{
    public class WishlistRepository : Repository<Wishlist>, IWishlistRepository
    {
        public WishlistRepository(LivrariaVirtualDbContext dbContext) : base(dbContext)
        {
        }

        public override Task<int> CountAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Wishlist>> FindAllByNameStartWithAsync(string name_wishlist)
        {
            throw new NotImplementedException();
        }

        public Task<Wishlist> FindByNameAsync(string name_wishlist)
        {
            throw new NotImplementedException();
        }

        public override Task<Wishlist> FindOrCreate(Wishlist e)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Wishlist>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<Wishlist> UpsertAsync(Wishlist e)
        {
            throw new NotImplementedException();
        }
    }
}
