using First.Data;
using First.Interfaces;
using First.Models;
using Microsoft.EntityFrameworkCore;

namespace First.Services

{
    public class TodoItemService : ITodoItemService
    {
        private readonly IDbContextFactory<LastDbContext> _contextFactory;

        public TodoItemService(IDbContextFactory<LastDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            var list = await context.TodoItems.Include(t => t.Categories).ToListAsync();
            return list;
        }

        public async Task<TodoItem> GetByIdAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.TodoItems.Include(t => t.Categories).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TodoItem> CreateAsync(TodoItem item)
        {
            using var context = _contextFactory.CreateDbContext();
            context.TodoItems.Add(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<TodoItem> UpdateAsync(TodoItem item)
        {
            using var context = _contextFactory.CreateDbContext();

            // elemek - kategóriá fetchelése
            var existingItem = await context.TodoItems
                .Include(t => t.Categories)
                .FirstOrDefaultAsync(t => t.Id == item.Id);

            if (existingItem == null)
            {
                // Handle item not found scenario
                throw new KeyNotFoundException("TodoItem not found");
            }

            // scalar update
            existingItem.Text = item.Text;
            existingItem.State = item.State;

            // KAtegória update
            existingItem.Categories.Clear();
            if (item.Categories != null)
            {
                foreach (var category in item.Categories)
                {
                    var existingCategory = await context.Categories.FindAsync(category.Id);
                    if (existingCategory != null)
                    {
                        existingItem.Categories.Add(existingCategory);
                    }
                }
            }

            await context.SaveChangesAsync();
            return existingItem;
        }

        public async Task DeleteAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var item = await context.TodoItems.FindAsync(id);
            if (item != null)
            {
                context.TodoItems.Remove(item);
                await context.SaveChangesAsync();
            }
        }
    }
}
