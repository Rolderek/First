using First.Models;

namespace First.Interfaces
{
    public interface ITodoApiService
    {
        Task<Category?> CreateCategoryAsync(Category category);
        Task<TodoItem?> CreateTodoItemAsync(TodoItem todoItem);
        Task DeleteCategoryAsync(int id);
        Task DeleteTodoItemAsync(int id);
        Task<List<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<TodoItem?> GetTodoItemByIdAsync(int id);
        Task<List<TodoItem>> GetTodoItemsAsync();
        Task UpdateCategoryAsync(Category category);
        Task UpdateTodoItemAsync(TodoItem todoItem);
    }
}
