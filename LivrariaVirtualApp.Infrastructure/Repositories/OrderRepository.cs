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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(LivrariaVirtualDbContext dbContext) : base(dbContext)
        {
        }


        public Task<List<Order>> FindAll()
        {
            return _dbContext.Orders.AsNoTracking.ToListAsync();
        }

        public async Task<List<Order>> FindAllByUserIdAsync(int user_id)
        {
            return await _dbContext.Orders.SingleOrDefaultAsync(e => e.User_id == user_id);
        }


        public override async Task<Order> UpsertAsync(Order e)
        {
            Order f = null;
            Order existing = await FindByIdAsync(e.User_id);

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

        public async Task<Order> DeleteAsync(int order_id)
        {
            Order entity = _dbContext.Orders.Remove(order_id).Entity;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public Task<List<Order>> FindAllByStatusStartWithAsync(string status)
        {
            return _dbContext.Orders.Where(c => c.Status.StartsWith(status))
                .OrderBy(c => c.User_id)
                .ToListAsync();
        }

        public Task<List<Order>> FindAllByUserIdAsync(int user_id)
        {
            return _dbContext.Orders.Where(c => c.User_id.StartsWith(user_id))
                .OrderBy(c => c.User_id)
                .ToListAsync();
        }

        Task<IEnumerable<Order>> GetForUserAsync(int order_id)
        {
            throw new NotImplementedException();
        }

        public override async Task<Order> UpsertAsync(Order order)
        {
            Order f = null;
            Order existing = await FindAllByUserIdAsync(f.User_id);

            if (existing == null)
            {
                if (order.Id == 0)
                {
                    order = await CreateAsync(order);
                }
                else
                {
                    f = await UpdateAsync(order);
                }
            }
            else if (existing.Id == order.Id)
            {
                _dbContext.Entry(existing).State = EntityState.Detached;
                f = await UpdateAsync(order);
            }
            await _dbContext.SaveChangesAsync();

            return f;
        }
    }
    }
}
