using LivrariaVirtualApp.Domain.Repositories;

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