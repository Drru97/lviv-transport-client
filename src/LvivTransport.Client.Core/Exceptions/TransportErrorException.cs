using System;

namespace LvivTransport.Client.Core.Exceptions
{
    public class TransportErrorException : Exception
    {
        public TransportErrorException() { }

        public TransportErrorException(Exception sourceException)
        {
            SourceException = sourceException;
        }

        public Exception SourceException { get; }
    }
}
