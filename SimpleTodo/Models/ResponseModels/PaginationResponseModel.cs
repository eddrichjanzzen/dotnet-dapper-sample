using System;
namespace SimpleTodo.Models.ResponseModels
{
    public class PaginatedResponseModel<T> : ResponseModel
    {
        public PaginationMetaModel<T> Data { get; set; }
    }
}
