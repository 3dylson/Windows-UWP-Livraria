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
        Task<List<Order>> FindAllByStatusStartWithAsync(string status);

        /// <summary>
        /// Returns all the given customer's orders. 
        /// </summary>
        Task<IEnumerable<Order>> GetForUserAsync(int order_id);

        /// <summary>
        /// Adds a new order if the order does not exist, updates the 
        /// existing order otherwise.
        /// </summary>
        Task<Order> UpsertAsync(Order order);

        /// <summary>
        /// Deletes an order.
        /// </summary>
        Task DeleteAsync(int order_id);
    }
}
