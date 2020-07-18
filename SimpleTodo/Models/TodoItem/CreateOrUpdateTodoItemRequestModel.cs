using System;
namespace SimpleTodo.Models.TodoItem
{
    public class CreateOrUpdateTodoItemRequestModel
    {
        public string Title { get; set; }
        public bool Completed { get; set; }
        public string Description { get; set; }
    }
}
