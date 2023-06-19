using EDT.BlazorServer.App.Models;
using EDT.BlazorServer.App.Service.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EDT.BlazorServer.App.Service
{
    public class TodoItemService : ITodoItemService
    {
        private readonly TodoContext _todoContext;


        public TodoItemService(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public async Task<TodoItem> AddTodoItemAsync(TodoItem todoItem)
        {
            todoItem.Id = Guid.NewGuid().ToString();
            todoItem.IsComplete = false;

            _todoContext.TodoItems.Add(todoItem);
            await _todoContext.SaveChangesAsync();

            return todoItem;
        }

        public async Task<TodoItem> DeleteTodoItemAsync(TodoItem todoItem)
        {
            _todoContext.TodoItems.Remove(todoItem);
            await _todoContext.SaveChangesAsync();

            return todoItem;
        }

        public async Task<TodoItem> GetTodoItemAsync(string id)
        {
            return await _todoContext.TodoItems.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IList<TodoItem>> GetTodoItemsAsync()
        {
            return await _todoContext.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> UpdateTodoItemAsync(TodoItem todoItem)
        {
            _todoContext.TodoItems.Update(todoItem);
            await _todoContext.SaveChangesAsync();

            return todoItem;
        }
    }
}
