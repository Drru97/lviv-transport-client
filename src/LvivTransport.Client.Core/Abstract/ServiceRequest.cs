using System;

namespace LvivTransport.Client.Core.Abstract
{
    public abstract class ServiceRequest
    {
        public Uri Uri { get; protected set; }
    }
}
