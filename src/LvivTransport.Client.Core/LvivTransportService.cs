using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LvivTransport.Client.Core.Abstract;
using LvivTransport.Client.Core.Common;
using LvivTransport.Client.Core.Models;
using LvivTransport.Client.Core.Request;
using LvivTransport.Client.Core.Response;

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

        public ServiceResponse GetResponse(ServiceRequest request)
        {
            return GetResponseAsync(request).GetAwaiter().GetResult();
        }

        public async Task<ServiceResponse> GetResponseAsync(ServiceRequest request)
        {
            var uri = new Uri(_baseUri, request.Uri);

            switch (request)
            {
                case RoutesRequest routesRequest:
                    var routesResponse = new RoutesResponse();
                    if (routesRequest.HasParameter)
                    {
                        routesResponse.Routes.Add(await _http.GetAsync<Route>(uri));
                        return routesResponse;
                    }
                    routesResponse.Routes = await _http.GetAsync<ICollection<Route>>(uri);
                    return routesResponse;

                case StopsRequest stopsRequest:
                    var stopsResponse = new StopsResponse();
                    if (stopsRequest.HasParameter)
                    {
                        stopsResponse.Stops.Add(await _http.GetAsync<Stop>(uri));
                        return stopsResponse;
                    }
                    stopsResponse.Stops = await _http.GetAsync<ICollection<Stop>>(uri);
                    return stopsResponse;

                case StopsNearbyRequest _:
                    stopsResponse = new StopsResponse();
                    stopsResponse.Stops = await _http.GetAsync<ICollection<Stop>>(uri);
                    return stopsResponse;

                default:
                    throw new ArgumentOutOfRangeException(nameof(request), "Invalid request type");
            }
        }

        public void Dispose()
        {
            _http?.Dispose();
        }
    }
}
