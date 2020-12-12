using LivrariaVirtualApp.Domain.Models;
using LivrariaVirtualApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaVirtualApp.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {

        public BookRepository(LivrariaVirtualDbContext dbContext) : base(dbContext)
        {
        }

        public override Task<int> CountAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAll(string name_wishlist)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> FindAllByCartStartWithAsync(int cart_id, string quantity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> FindAllByCategoryStartWithAsync(int category_id, string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> FindAllByUserIdAsync(int user_id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> FindAllByWishlistStartWithAsync(int wishlist_id, string name_wishlist)
        {
            throw new NotImplementedException();
        }

        public Task<Book> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public override Task<Book> FindOrCreate(Book e)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Book>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<Book> UpsertAsync(Book e)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Book>> IBookRepository.GetAsync(string search)
        {
            throw new NotImplementedException();
        }
    }
}
