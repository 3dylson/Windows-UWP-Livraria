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

        public override Task<int> CountAll()
        {
            throw new NotImplementedException();
        }

        public override Task<User> FindOrCreate(User e)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<User> UpsertAsync(User e)
        {
            throw new NotImplementedException();
        }

        Task IUserRepository.DeleteAsync(int user_id)
        {
            throw new NotImplementedException();
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
    }
}
