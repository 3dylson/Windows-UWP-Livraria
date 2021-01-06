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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(LivrariaVirtualDbContext dbContext) : base(dbContext)
        {
        }


        public Task<List<Category>> FindAllByNameStartWithAsync(string name)
        {
            return _dbContext.Categories.Where(c => c.Name.StartsWith(name))
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public Task<Category> FindByNameAsync(string name)
        {
            return _dbContext.Categories.SingleOrDefaultAsync(c => c.Name == name);
        }

        public override async Task<Category> FindOrCreate(Category e)
        {
            var c = await _dbContext.Categories.SingleOrDefaultAsync(i => i.Name == e.Name);
            if (c == null)
            {
                c = await CreateAsync(e);
                await _dbContext.SaveChangesAsync();
            }
            return c;
        }

        public override Task<IEnumerable<Category>> GetAsync(string search)
        {
            throw new NotImplementedException();
        }

        public override async Task<Category> UpsertAsync(Category e)
        {
            Category f = null;
            Category existing = await FindByNameAsync(e.Name);

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

