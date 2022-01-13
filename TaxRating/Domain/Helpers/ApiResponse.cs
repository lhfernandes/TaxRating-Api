using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public class ApiResponse<T>
    {

        public ApiResponse()
        {
            Notifications = new List<Notification>();
        }

        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<Notification> Notifications { get; set; }

        public static ApiResponse<T> Fail(string errorMessage)
        {
            return new ApiResponse<T> { Succeeded = false, Message = errorMessage };
        }

        public static ApiResponse<T> FailNotFound(int id)
        {
            return new ApiResponse<T> { Succeeded = false, Message = $"The resource with id {id} was not found." };
        }

        public static ApiResponse<T> FailNotFound(string symbol)
        {
            return new ApiResponse<T> { Succeeded = false, Message = $"The rate with symbol {symbol} was not found." };
        }

        public static ApiResponse<T> FailEmpty()
        {
            return new ApiResponse<T> { Succeeded = false, Message = "The list is empty." };
        }

        public static ApiResponse<T> FailValidation(List<Notification> notifications)
        {
            return new ApiResponse<T> { Succeeded = false, Message = "An error occured when validate your model.", Notifications = notifications };
        }
        public static ApiResponse<T> Success(T data)
        {
            return new ApiResponse<T> { Succeeded = true, Data = data, Message = "Operation Completed" };
        }
    }
}
