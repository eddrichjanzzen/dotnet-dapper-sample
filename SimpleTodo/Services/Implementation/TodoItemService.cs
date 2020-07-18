using System;
using System.Threading.Tasks;
using SimpleTodo.Models.TodoItem;
using SimpleTodo.Models.ResponseModels;
using SimpleTodo.Services.Interface;
using SimpleTodo.Providers.Sql.Interface;
using Microsoft.Extensions.Logging;

namespace SimpleTodo.Services.Implementation
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ITodoItemProvider _todoItemProvider;
        private readonly ILogger<TodoItemService> _logger;

        public TodoItemService(
            ITodoItemProvider todoItemProvider,
            ILogger<TodoItemService> logger)
        {
            _todoItemProvider = todoItemProvider;
            _logger = logger;
        }

        public async Task<SingleResponseModel<int>> CreateTodoItem(CreateOrUpdateTodoItemRequestModel request)
        {
            var response = new SingleResponseModel<int>();

            try
            {
                if (request == null)
                {
                    response.Status = ResponseCodes.ValidationError;
                    response.Message = "No request received.";

                    return response;
                }


                if (string.IsNullOrEmpty(request.Title))
                {
                    response.Status = ResponseCodes.ValidationError;
                    response.Message = "A todo item title is required";

                    return response;
                }

                response.Data = await _todoItemProvider.CreateTodoItemAsync(request);
                response.Status = ResponseCodes.Success;
                response.Message = "Success";

                return response;
            }
            catch (Exception e)
            {
                response.Status = ResponseCodes.ProcessError;
                var logMessage = response.Message = "Failed to add a todo item.";

                _logger.LogError(e, logMessage + " | Request: {@0}", request);

                return response;
            }
        }

        public async Task<SingleResponseModel<bool>> DeleteTodoItem(int TodoItemId)
        {
            var response = new SingleResponseModel<bool>();

            try
            {
                if (TodoItemId <= 0)
                {
                    response.Status = ResponseCodes.ValidationError;
                    response.Message = "TodoItemId must be greater than or equal to 0";

                    return response;
                }

                response.Data = await _todoItemProvider.DeleteTodoItemAysnc(TodoItemId);
                response.Status = ResponseCodes.Success;
                response.Message = "Success";

                return response;
            }
            catch (Exception e)
            {
                response.Status = ResponseCodes.ProcessError;
                var logMessage = response.Message = "Failed to delete a todo item.";

                _logger.LogError(e, logMessage + " | Request: {@0}", TodoItemId);

                return response;
            }
        }

        public async Task<PaginatedResponseModel<TodoItem>> GetAllTodoItems(GetAllTodoItemRequestModel request)
        {
            var response = new PaginatedResponseModel<TodoItem>();

            try
            {

                if (request.Page <= 0)
                {
                    response.Status = ResponseCodes.ValidationError;
                    response.Message = "Page must be a number greater than 0";

                    return response;
                }

                if (request.PageSize <= 0)
                {
                    response.Status = ResponseCodes.ValidationError;
                    response.Message = "Page size must be a number greater than 0";

                    return response;
                }

                response.Data = await _todoItemProvider.GetAllTodoItemsAsync(request);
                response.Status = ResponseCodes.Success;
                response.Message = "Success";

                return response;
            }
            catch (Exception e)
            {
                response.Status = ResponseCodes.ProcessError;
                var logMessage = response.Message = "Failed to get todo items.";

                _logger.LogError(e, logMessage + " | Request: {@0}", request);

                return response;
            }
        }

        public async Task<SingleResponseModel<TodoItem>> GetTodoItem(int TodoItemId)
        {
            var response = new SingleResponseModel<TodoItem>();

            try
            {
                if (TodoItemId <= 0)
                {
                    response.Status = ResponseCodes.ValidationError;
                    response.Message = "TodoItemId must be greater than or equal to 0";

                    return response;
                }

                response.Data = await _todoItemProvider.GetTodoItemAsync(TodoItemId);
                response.Status = ResponseCodes.Success;
                response.Message = "Success";

                return response;
            }
            catch (Exception e)
            {
                response.Status = ResponseCodes.ProcessError;
                var logMessage = response.Message = "Failed to get todo item.";

                _logger.LogError(e, logMessage + " | Request: {@0}", TodoItemId);

                return response;
            }
        }

        public async Task<SingleResponseModel<bool>> UpdateTodoItem(int TodoItemId, CreateOrUpdateTodoItemRequestModel request)
        {
            var response = new SingleResponseModel<bool>();

            try
            {
                if (request == null)
                {
                    response.Status = ResponseCodes.ValidationError;
                    response.Message = "No request received.";

                    return response;
                }

                if (TodoItemId <= 0)
                {
                    response.Status = ResponseCodes.ValidationError;
                    response.Message = "TodoItemId must be greater than or equal to 0";

                    return response;
                }


                if (string.IsNullOrEmpty(request.Title))
                {
                    response.Status = ResponseCodes.ValidationError;
                    response.Message = "A todo item title is required";

                    return response;
                }

                response.Data = await _todoItemProvider.UpdateTodoItemAysnc(TodoItemId, request);
                response.Status = ResponseCodes.Success;
                response.Message = "Success";

                return response;
            }
            catch (Exception e)
            {
                response.Status = ResponseCodes.ProcessError;
                var logMessage = response.Message = "Failed to update todo item.";

                _logger.LogError(e, logMessage + " | Request: {@0}", request);

                return response;
            }
        }

    }
}
