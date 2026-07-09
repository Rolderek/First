using First.Models;

namespace First.Interfaces;


public interface ITodoItemService
{
    Task<IEnumerable<TodoItem>> GetAllAsync();
    Task<TodoItem> GetByIdAsync(int id);
    Task<TodoItem> CreateAsync(TodoItem item);
    Task<TodoItem> UpdateAsync(TodoItem item);
    Task DeleteAsync(int id);
}

