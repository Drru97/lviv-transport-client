using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LvivTransport.Client.Core.Common
{
    internal class TransportHttp : IDisposable
    {
        private readonly HttpClient _client;
        private StopsHtmlParser _parser;

        public TransportHttp()
        {
            _client = new HttpClient();
        }

        public T Get<T>(Uri uri) where T : class
        {
            return GetAsync<T>(uri).GetAwaiter().GetResult();
        }

        public async Task<T> GetAsync<T>(Uri uri) where T : class
        {
            var response = await _client.GetAsync(uri).ConfigureAwait(false);
            var contentType = response.Content.Headers.ContentType.MediaType;

            switch (contentType)
            {
                case GlobalConstants.Json:
                    var json = await _client.GetStringAsync(uri).ConfigureAwait(false);
                    var stop = JsonConvert.DeserializeObject<T>(json);
                    return stop;

                // this is just because of API developers which didn't implement GetAllStops method
                case GlobalConstants.Html:
                    _parser = new StopsHtmlParser();
                    var stopsJson = await _parser.ParseStops(await response.Content.ReadAsStringAsync());
                    var stops = JsonConvert.DeserializeObject<T>(stopsJson);
                    return stops;

                default:
                    throw new ArgumentOutOfRangeException(nameof(contentType), "Unsupported content type");
            }
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
