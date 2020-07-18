using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleTodo.Models.ResponseModels;
using SimpleTodo.Models.TodoItem;
using SimpleTodo.Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleTodo.Controllers
{
    [Route("api/[controller]")]
    public class TodoItemController : Controller
    {

        private readonly ITodoItemService _todoItemService;

        public TodoItemController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet]
        public async Task<PaginatedResponseModel<TodoItem>> GetAllTodoItems([FromQuery] GetAllTodoItemRequestModel request)
        {
            return await _todoItemService.GetAllTodoItems(request);
        }

        [HttpGet("{id}")]
        public async Task<SingleResponseModel<TodoItem>> GetTodoItem(int id)
        {
            return await _todoItemService.GetTodoItem(id);
        }

        [HttpPost]
        public async Task<SingleResponseModel<int>> CreateTodoItem([FromBody] CreateOrUpdateTodoItemRequestModel request)
        {
            return await _todoItemService.CreateTodoItem(request);
        }

        [HttpPut("{id}")]
        public async Task<SingleResponseModel<bool>> UpdateTodoItem(int id, [FromBody] CreateOrUpdateTodoItemRequestModel request)
        {
            return await _todoItemService.UpdateTodoItem(id, request);
        }

        [HttpDelete("{id}")]
        public async Task<SingleResponseModel<bool>> DeleteTodoItem(int id)
        {
            return await _todoItemService.DeleteTodoItem(id);
        }
    }
}
