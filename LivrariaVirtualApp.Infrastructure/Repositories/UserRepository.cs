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
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(LivrariaVirtualDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<User> FindOrCreate(User e)
        {
            var c = await _dbContext.Users.SingleOrDefaultAsync(i => i.Email == e.Email);
            if (c == null)
            {
                c = await CreateAsync(e);
                await _dbContext.SaveChangesAsync();
            }
            return c;
        }

  
        public override async Task<User> UpsertAsync(User e)
        {
            User f = null;
            User existing = await FindByEmail(e.Email);

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

        public async Task<User> FindByEmailAndPassword(string email, string password)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(e => e.Email == email
                    && e.Password == password);
        }
        
        public async Task<User> FindByEmail(string email)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(e => e.Email == email);
        }

        public async Task DeleteAsync(int user_id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(_user => _user.Id == user_id);
            
            if(null != user) 
            {
                var orders = await _dbContext.Orders.Where(order => order.User_id == user_id).ToListAsync();
                _dbContext.Orders.RemoveRange(orders);
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }

        Task<IEnumerable<User>> IUserRepository.GetAsync(string search)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<User>> IUserRepository.GetAsync()
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.GetAsync(int admin)
        {
            throw new NotImplementedException();
        }
        
        public override Task<int> CountAll()
        {
            throw new NotImplementedException();
        }
        
        public override Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
