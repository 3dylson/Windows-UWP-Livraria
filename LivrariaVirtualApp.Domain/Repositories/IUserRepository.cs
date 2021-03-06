﻿using LivrariaVirtualApp.Domain.Models;
using LivrariaVirtualApp.Domain.SeedWork;
using System.Threading.Tasks;

namespace LivrariaVirtualApp.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByEmail(string email);

        Task<User> FindByEmailAndPassword(string email, string password);
    }
}