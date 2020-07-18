using System;
namespace SimpleTodo.Models.ResponseModels
{
    public enum ResponseCodes
    {
        Success = 200,

        ValidationError = 500,
        ProcessError = 501
    }
}
