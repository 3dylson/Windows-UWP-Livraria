using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaVirtualApp.Domain.SeedWork
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> CreateAsync(T e);
        Task<T> UpdateAsync(T e);

        /// <summary>
        /// Changes or insert a new entity. 
        /// Unique index must be used to detect equality
        /// </summary>
        /// <param name="e">Entity with all members filled </param>
        /// <returns>Tracking entity</returns>
        Task<T> UpsertAsync(T e);
        Task<T> FindOrCreate(T e);
        Task<T> DeleteAsync(T e);
        Task<T> FindByIdAsync(int id);
        Task<List<T>> FindAllAsync();
        
        /// <summary>
        /// Returns all "T" with a data field matching the start of the given string. 
        /// </summary>
        Task<IEnumerable<T>> GetAsync(string search);
        
        /// <summary>
        /// Returns all the given user's "T". 
        /// </summary>
        Task<IEnumerable<T>> GetForUserAsync(T e);
    }
}

