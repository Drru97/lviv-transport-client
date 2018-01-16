using System;

namespace LvivTransport.Client.Core
{
    public class RoutesRequest : BaseRequest
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
