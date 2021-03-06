﻿using LivrariaVirtualApp.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivrariaVirtualApp.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly LivrariaVirtualDbContext _dbContext;

        public Repository(LivrariaVirtualDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> CreateAsync(T e)
        {
            T entity = _dbContext.Set<T>().Add(e).Entity;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T e)
        {
            T entity = _dbContext.Set<T>().Remove(e).Entity;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> FindAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T e)
        {
            T entity = _dbContext.Set<T>().Update(e).Entity;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public abstract Task<T> FindOrCreate(T e);

        public abstract Task<T> UpsertAsync(T e);

        public abstract Task<IEnumerable<T>> GetAsync(string search);

        public async Task<IEnumerable<T>> GetForUserAsync(T e) =>
            await _dbContext.Set<T>()
            .AsNoTracking()
            .ToListAsync();

        public abstract Task<T> GetAsync(int id);

        public abstract Task<IEnumerable<T>> GetAsync();
    }
}