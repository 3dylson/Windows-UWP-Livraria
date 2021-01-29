using LivrariaVirtualApp.Domain.Models;
using LivrariaVirtualApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaVirtualApp.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LivrariaVirtualDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Book>> FindAllByCategoryStartWithAsync(int category_id, string name)
        {
            return await _dbContext.Books.Where(c => c.Name.StartsWith(name)
                && (category_id == 0 || c.Category_id == category_id))
                .OrderBy(c => c.Name).ToListAsync();
        }

        public Task<List<Book>> FindAllByUserIdAndWishlistAsync(int userId, int wishlist_id)
        {
            throw new NotImplementedException();
        }

        /// ///
        public Task<List<Book>> FindAllByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        /// ///
        public async Task<Book> FindByNameAsync(string name)
        {
            return await _dbContext.Books.SingleOrDefaultAsync(p => p.Name == name);
        }

        public override async Task<Book> FindOrCreate(Book e)
        {
            var c = await _dbContext.Books.SingleOrDefaultAsync(i => i.Name == e.Name);
            if (c == null)
            {
                c = await CreateAsync(e);
                await _dbContext.SaveChangesAsync();
            }
            return c;
        }

        /// ///
        public override async Task<IEnumerable<Book>> GetAsync(string search)
        {
            return await _dbContext.Books.Where(book =>
                book.Name.StartsWith(search) ||
                book.ISBN.StartsWith(search))
            .AsNoTracking()
            .ToListAsync();
        }

        public override Task<Book> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Book>> GetAsync()
        {
            throw new NotImplementedException();
        }

        //public Task<IList<Book>> GetBooksAsync(DataRequest<Book> request)
        //{
        //    throw new NotImplementedException();
        //}

        /// ///

        public override async Task<Book> UpsertAsync(Book e)
        {
            Book f = null;
            Book existing = await FindByNameAsync(e.Name);

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
    }
}