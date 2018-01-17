using System;
using LvivTransport.Client.Core.Abstract;

namespace LvivTransport.Client.Core.Request
{
    public class RoutesRequest : ServiceRequest
    {
        private readonly int? _requestParameter;

        public RoutesRequest(int? id = null)
        {
            _requestParameter = id;
            Uri = _requestParameter == null ? new Uri("/api/routes", UriKind.Relative) : new Uri($"/api/routes/{_requestParameter}", UriKind.Relative);
        }

        public bool HasParameter => _requestParameter != null;
    }
}
