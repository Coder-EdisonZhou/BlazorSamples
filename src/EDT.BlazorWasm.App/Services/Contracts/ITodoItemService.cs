using EDT.BlazorWasm.App.Models;

namespace EDT.BlazorWasm.App.Services.Contracts;

public interface ITodoItemService
{
    Task<IList<TodoItem>> GetTodoItemsAsync();
    Task<TodoItem> GetTodoItemAsync(string id);
    Task<TodoItem> AddTodoItemAsync(TodoItem todoItem);
    Task<TodoItem> UpdateTodoItemAsync(TodoItem todoItem);
    Task<TodoItem> DeleteTodoItemAsync(TodoItem todoItem);
}
