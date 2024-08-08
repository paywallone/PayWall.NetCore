using PayWall.AspNetCore.Models.Abstraction;

namespace PayWall.AspNetCore.Models.Common.Payment
{
    public class Response<T> where T : IResponseResult
    {
        public T Body { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }
        public PaymentErrorCodes ErrorCode { get; set; }
    }
}