using System.Collections.Generic;
using PayWall.AspNetCore.Models.Abstraction;
using PayWall.AspNetCore.Models.Common.Member;

namespace PayWall.AspNetCore.Models.Common.PaymentPrivate
{
    public class Response<T> where T : IResponseResult
    {
        public T Body { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }
        public ErrorCodes ErrorCode { get; set; }
    }
    
}