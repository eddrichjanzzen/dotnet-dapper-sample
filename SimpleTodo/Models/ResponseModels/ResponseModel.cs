using System;
namespace SimpleTodo.Models.ResponseModels
{
    public class ResponseModel
    {
        public ResponseCodes Status { get; set; }
        public string Message { get; set; }

        public ResponseModel()
        {
            Status = ResponseCodes.Success;
        }
    }
}
