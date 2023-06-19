using EDT.BlazorServer.App.Models;

namespace EDT.BlazorServer.App.Service.Contracts
{
    public interface ITodoItemService
    {
        Task<IList<TodoItem>> GetTodoItemsAsync();
        Task<TodoItem> GetTodoItemAsync(string id);
        Task<TodoItem> AddTodoItemAsync(TodoItem todoItem);
        Task<TodoItem> UpdateTodoItemAsync(TodoItem todoItem);
        Task<TodoItem> DeleteTodoItemAsync(TodoItem todoItem);
    }
}
