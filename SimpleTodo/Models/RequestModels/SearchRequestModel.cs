using System;
namespace SimpleTodo.Models.RequestModels
{
    public class SearchRequestModel : PaginatedRequestModel
    {
        public string Filter { get; set; }
    }
}
