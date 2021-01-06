using LivrariaVirtualApp.Domain.Models;
using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace LivrariaVirtualApp.Domain.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> FindAllByUserIdAsync(int user_id);

        Task<Order> FindByIdAndUserAsync(int id, string name);

    }
}
