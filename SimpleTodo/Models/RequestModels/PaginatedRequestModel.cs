using System;
namespace SimpleTodo.Models.RequestModels
{
    public class PaginatedRequestModel
    {
        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
