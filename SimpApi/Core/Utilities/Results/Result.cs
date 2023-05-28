using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result<T> : IResult<T>
    {
        
        public Result(T data)
        {
            Data = data;

        }
        public Result(string message)
        {
            Message = message;
        }
        public Result(string message,bool success):this(message)
        {            
            Success = success;
        }

        public bool Success { get; set; } = true;

        public string Message { get; set; } = "Success";
        public T? Data { get; set; }
    }
}
