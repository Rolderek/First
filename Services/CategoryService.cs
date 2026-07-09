using First.Data;
using First.Interfaces;
using First.Models;
using Microsoft.EntityFrameworkCore;

namespace First.Services
{
    public class CategoryService : ITodoCategoryService
    {
        private readonly IDbContextFactory<LastDbContext> _contextFactory;

        public CategoryService(IDbContextFactory<LastDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            var list = await context.Categories.Include(c => c.TodoItems).ToListAsync();
            return list;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Categories.Include(c => c.TodoItems).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> CreateAsync(Category category)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Categories.Add(category);
            await context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Categories.Update(category);
            await context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var category = await context.Categories.FindAsync(id);
            if (category != null)
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
            }
        }
    }
}
