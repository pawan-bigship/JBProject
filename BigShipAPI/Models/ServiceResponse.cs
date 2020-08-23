using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JBProject.Models
{
    public class ServiceResponse<T>
    {
        // T data is the Actual data wecwant to return
        public T Data { get; set; }
        public bool Success { get; set; } = true;

        public string Message { get; set; } = null;
        public int ResponseCode { get; set; }=0;
    }
}
