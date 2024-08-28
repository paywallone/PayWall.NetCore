using System.Collections.Generic;
using PayWall.AspNetCore.Models.Abstraction;

namespace PayWall.AspNetCore.Models.Common.Member;

public class Response<T> where T : IResponseResult
{
    public T Body { get; set; }
    public bool Result { get; set; }
    public string Message { get; set; }
    public ErrorCodes ErrorCode { get; set; }
}

public class ResponseList<T> where T : IResponseResult
{
    public List<T> Body { get; set; }
    public bool Result { get; set; }
    public string Message { get; set; }
    public ErrorCodes ErrorCode { get; set; }
}


