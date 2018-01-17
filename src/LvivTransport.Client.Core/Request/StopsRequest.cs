using System;
using LvivTransport.Client.Core.Abstract;

namespace LvivTransport.Client.Core.Request
{
    public class StopsRequest : ServiceRequest
    {
        private readonly int? _requestParameter;

        public StopsRequest(int? id = null)
        {
            _requestParameter = id;
            Uri = Uri = _requestParameter == null ? new Uri("/stops", UriKind.Relative) : new Uri($"/api/stops/{_requestParameter}", UriKind.Relative);
        }

        public bool HasParameter => _requestParameter != null;
    }
}
