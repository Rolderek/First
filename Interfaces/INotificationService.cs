using First.Models;

namespace First.Interfaces
{
    public interface INotificationService
    {
        event Action<TodoItem>? TodoChanged;
        Task SendNotificationAsync(TodoItem item);
    }
}
