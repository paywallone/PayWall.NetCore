using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Common.Payment
{
    public class Response<T> where T : IResponseResult
    {
        public T Body { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }
        public ErrorCodes ErrorCode { get; set; }
    }
}