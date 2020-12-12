using LivrariaVirtualApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaVirtualApp.Domain
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        IUserRepository UserRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IOrderRepository OrderRepository { get; }
        IWishlistRepository WishlistRepository { get; }

    }
}
