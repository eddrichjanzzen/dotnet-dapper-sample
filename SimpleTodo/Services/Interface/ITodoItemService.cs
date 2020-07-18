using System;
using System.Threading.Tasks;
using SimpleTodo.Models.TodoItem;
using SimpleTodo.Models.ResponseModels;

namespace SimpleTodo.Services.Interface
{
    public interface ITodoItemService
    {
        Task<PaginatedResponseModel<TodoItem>> GetAllTodoItems(GetAllTodoItemRequestModel request);
        Task<SingleResponseModel<TodoItem>> GetTodoItem(int TodoItemId);
        Task<SingleResponseModel<int>> CreateTodoItem(CreateOrUpdateTodoItemRequestModel request);
        Task<SingleResponseModel<bool>> UpdateTodoItem(int TodoItemId, CreateOrUpdateTodoItemRequestModel request);
        Task<SingleResponseModel<bool>> DeleteTodoItem(int TodoItemId);
    }
}
