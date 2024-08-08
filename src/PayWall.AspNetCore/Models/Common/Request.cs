using System;
using PayWall.AspNetCore.Models.Abstraction;

namespace PayWall.AspNetCore.Models.Common
{
    internal class Request<T> where T : IRequestParams, new()
    {
        public Request()
        {
            Params = new T();
        }

        public Request(T parameters)
        {
            Params = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }

        public T Params { get; set; }
    }
}