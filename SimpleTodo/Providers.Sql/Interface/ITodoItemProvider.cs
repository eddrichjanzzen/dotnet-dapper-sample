using System;
using System.Threading.Tasks;
using SimpleTodo.Models.TodoItem;
using SimpleTodo.Models.ResponseModels;

namespace SimpleTodo.Providers.Sql.Interface
{
    public interface ITodoItemProvider
    {
        public Task<PaginationMetaModel<TodoItem>> GetAllTodoItemsAsync(GetAllTodoItemRequestModel request);
        public Task<TodoItem> GetTodoItemAsync(int TodoItemId);
        public Task<int> CreateTodoItemAsync(CreateOrUpdateTodoItemRequestModel request);
        public Task<bool> UpdateTodoItemAysnc(int TodoItemId, CreateOrUpdateTodoItemRequestModel request);
        public Task<bool> DeleteTodoItemAysnc(int TodoItemId);
    }
}
