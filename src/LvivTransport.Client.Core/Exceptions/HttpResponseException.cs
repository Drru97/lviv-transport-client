using System;
using System.Net.Http;

namespace LvivTransport.Client.Core.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException() { }

        public HttpResponseException(HttpResponseMessage response, string message = null) : base (message)
        {
            Response = response;
        }

        public HttpResponseMessage Response { get; }
    }
}
