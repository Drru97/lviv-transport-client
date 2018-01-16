using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LvivTransport.Client.Core.Common;
using LvivTransport.Client.Core.Models;

namespace LvivTransport.Client.Core
{
    public class LvivTransportService : IDisposable
    {
        private readonly TransportHttp _http;
        private readonly Uri _baseUri;

        public LvivTransportService(Uri baseUri = null)
        {
            _http = new TransportHttp();
            _baseUri = baseUri ?? new Uri(GlobalConstants.BaseUrl, UriKind.Absolute);
        }

        public RoutesResponse GetResponse(RoutesRequest request)
        {
            return GetResponseAsync(request).GetAwaiter().GetResult();
        }

        public async Task<RoutesResponse> GetResponseAsync(RoutesRequest request)
        {
            var uri = new Uri(_baseUri, request.Uri);
            var response = new RoutesResponse();

            if (request.HasParameter)
            {
                response.Routes.Add(await _http.GetAsync<Route>(uri));
                return response;
            }

            response.Routes = await _http.GetAsync<ICollection<Route>>(uri);
            return response;
        }

        public StopsResponse GetResponse(StopsRequest request)
        {
            return GetResponseAsync(request).GetAwaiter().GetResult();
        }

        public async Task<StopsResponse> GetResponseAsync(StopsRequest request)
        {
            var uri = new Uri(_baseUri, request.Uri);
            var response = new StopsResponse();

            if (request.HasParameter)
            {
                response.Stops.Add(await _http.GetAsync<Stop>(uri));
                return response;
            }

            response.Stops = await _http.GetAsync<ICollection<Stop>>(uri);
            return response;
        }

        public void Dispose()
        {
            _http?.Dispose();
        }
    }
}
