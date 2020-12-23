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


        public override Task<Order> UpsertAsync(Order e)
        {
            throw new NotImplementedException();
        }

        Task IOrderRepository.DeleteAsync(int order_id)
        {
            throw new NotImplementedException();
        }

        Task<List<Order>> IOrderRepository.FindAllByStatusStartWithAsync(string status)
        {
            throw new NotImplementedException();
        }

        Task<List<Order>> IOrderRepository.FindAllByUserIdAsync(int user_id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Order>> IOrderRepository.GetForUserAsync(int order_id)
        {
            throw new NotImplementedException();
        }

        Task<Order> IOrderRepository.UpsertAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
