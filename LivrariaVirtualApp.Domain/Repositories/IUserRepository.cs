using LivrariaVirtualApp.Domain.Models;
using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace LivrariaVirtualApp.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Returns all customers with a data field matching the start of the given string. 
        /// </summary>
        Task<IEnumerable<User>> GetAsync(string search);

        /// <summary>
        /// Returns all Users. 
        /// </summary>
        Task<IEnumerable<User>> GetAsync();

        /// <summary>
        /// Returns the Users with the Admin id. 
        /// </summary>
        Task<User> GetAsync(int admin);

        /// <summary>
        /// Adds a new User if the User does not exist, updates the 
        /// existing User otherwise.
        /// </summary>
        Task<User> UpsertAsync(User user);

        /// <summary>
        /// Deletes a customer.
        /// </summary>
        Task DeleteAsync(int user_id);
    }
}
