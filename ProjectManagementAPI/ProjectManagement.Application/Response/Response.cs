using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Response
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public string? Error { get; set; }
        public Response()
        {
        }
        public Response(T data, string message = "")
        {
            Success = true;
            Data = data;
            Message = message;
        }
      
    }
}
