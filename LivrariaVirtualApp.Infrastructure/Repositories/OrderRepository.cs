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

        public override Task<int> CountAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> FindAllByStatusStartWithAsync(string status)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> FindAllByUserIdAsync(int user_id)
        {
            throw new NotImplementedException();
        }

        public override Task<Order> FindOrCreate(Order e)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<Order> UpsertAsync(Order e)
        {
            throw new NotImplementedException();
        }
    }
}
