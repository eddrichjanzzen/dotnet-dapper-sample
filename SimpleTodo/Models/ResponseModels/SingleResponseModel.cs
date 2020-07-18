using System;
namespace SimpleTodo.Models.ResponseModels
{
    public class SingleResponseModel<T> : ResponseModel
    {
        public T Data { get; set; }
    }
}
