using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.OperationResponse
{
    public class OperationResponse<T>
    {
        public OperationResponse(T data, bool success = true, string ex = null) 
        {
            Data = data;
            Success = success;
            Exception = ex;
        }
        public bool Success { get; set; }
        public string Exception { get; set; }
        public T Data { get; set; }
    }
}
