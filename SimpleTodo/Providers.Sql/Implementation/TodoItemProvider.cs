using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SimpleTodo.Models.TodoItem;
using SimpleTodo.Models.ResponseModels;
using SimpleTodo.Providers.Sql.Interface;
using Microsoft.Extensions.Configuration;

namespace SimpleTodo.Providers.Sql.Implementation
{
    public class TodoItemProvider : ITodoItemProvider
    {
        private readonly IConfiguration _configuration;

        public TodoItemProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public async Task<PaginationMetaModel<TodoItem>> GetAllTodoItemsAsync(GetAllTodoItemRequestModel request)
        {
            using (var conn = Connection)
            {

                var result = new Dictionary<int, TodoItem>();
                using (var reader = await conn.QueryMultipleAsync(
                    "TodoItem_GetAll", new
                    {
                        @page = request.Page,
                        @pageSize = request.PageSize,
                        @filter = request.Filter
                    }, commandType: CommandType.StoredProcedure))
                {

                    //read the first query (total)
                    var total = reader.Read<int>().FirstOrDefault();

                    //read the second query (todoItems)
                    var todoItems = reader.Read<TodoItem>().ToList();

                    var todoItemMeta = new PaginationMetaModel<TodoItem>()
                    {
                        Total = total,
                        Items = todoItems
                    };

                    return todoItemMeta;

                }
            }       
        }

        public async Task<int> CreateTodoItemAsync(CreateOrUpdateTodoItemRequestModel request)
        {
            using (var conn = Connection)
            {
                return (await conn.QueryAsync<int>("TodoItem_Create",
                    new
                    {
                        @Title= request.Title,
                        @Completed= request.Completed,
                        @Description= request.Description
                    }, commandType: CommandType.StoredProcedure)
                ).FirstOrDefault();
            }

        }

        public async Task<bool> DeleteTodoItemAysnc(int TodoItemId)
        {
            using (var conn = Connection)
            {

                var affected = await conn.ExecuteAsync("TodoItem_Delete",
                    new
                    {
                        @Id = TodoItemId
                    }, commandType: CommandType.StoredProcedure
                );

                var success = affected > 0;

                return success;
            }
        }

        public async Task<TodoItem> GetTodoItemAsync(int TodoItemId)
        {
            using (var conn = Connection)
            {
                return (await conn.QueryAsync<TodoItem>("TodoItem_GetById",
                    new
                    {
                        @Id=TodoItemId
                    }, commandType: CommandType.StoredProcedure)
                ).FirstOrDefault();
            }

        }

        public async Task<bool> UpdateTodoItemAysnc(int TodoItemId, CreateOrUpdateTodoItemRequestModel request)
        {
            using (var conn = Connection)
            {
                var affected = await conn.ExecuteAsync("TodoItem_Update",
                    new
                    {
                        @Id = TodoItemId,
                        @Title = request.Title,
                        @Completed = request.Completed,
                        @Description = request.Description
                    }, commandType: CommandType.StoredProcedure
                );

                var success = affected > 0;

                return success;
            }
        }
    }
}
