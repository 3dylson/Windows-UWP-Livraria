using LivrariaVirtualApp.Domain.Models;
using LivrariaVirtualApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaVirtualApp.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(LivrariaVirtualDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Order>> FindAllByUserIdAsync(int user_id)
        {
            return _dbContext.Orders
                .Include(m => m.Cart)
                .ThenInclude(cart => cart.Book)
                .Where(e => e.User_id == user_id)
                .ToListAsync();
        }

        public Task<Order> FindByIdAndUserAsync(int id, string name)
        {
            return _dbContext.Orders
                .SingleOrDefaultAsync(p => p.Id == id
                    && p.UserOrdering == name);
        }

        public override async Task<Order> FindOrCreate(Order e)
        {
            var f = await _dbContext.Orders
                .SingleOrDefaultAsync(i => i.Id == e.Id
                    && i.User_id == e.User_id);

            if (f == null)
            {
                f = await CreateAsync(e);
                await _dbContext.SaveChangesAsync();
            }

            return f;
        }

        public override async Task<IEnumerable<Order>> GetAsync(string search)
        {
            string[] parameters = search.Split(' ');
            return await _dbContext.Orders
                .Include(order => order.User)
                .Include(order => order.Cart)
                .ThenInclude(lineItem => lineItem.Book)
                .Where(order => parameters
                    .Any(parameter =>
                        order.Shipping_address.StartsWith(parameter) ||
                        order.User.Name.StartsWith(parameter) ||                        
                        order.Id.ToString().StartsWith(parameter)))
                .OrderByDescending(order => parameters
                    .Count(parameter =>
                        order.Shipping_address.StartsWith(parameter) ||
                        order.User.Name.StartsWith(parameter) ||
                        order.Id.ToString().StartsWith(parameter)))
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<Order> GetAsync(int id) =>
            await _dbContext.Orders
                .Include(order => order.Cart)
                .ThenInclude(cart => cart.Book)
                .AsNoTracking()
                .FirstOrDefaultAsync(order => order.Id == id);

        public override async Task<IEnumerable<Order>> GetAsync() =>
            await _dbContext.Orders
                .Include(order => order.Cart)
                .ThenInclude(cart => cart.Book)
                .AsNoTracking()
                .ToListAsync();

        public override async Task<Order> UpsertAsync(Order e)
        {
            Order f = null;
            Order existing = await FindByIdAndUserAsync(e.User_id,
                e.UserOrdering);

            if (existing == null)
            {
                if (e.Id == 0)
                {
                    f = await CreateAsync(e);
                }
                else
                {
                    f = await UpdateAsync(e);
                }
            }
            else if (existing.Id == e.Id)
            {
                _dbContext.Entry(existing).State = EntityState.Detached;
                f = await UpdateAsync(e);
            }

            await _dbContext.SaveChangesAsync();
            return f;
        }
    }
}