using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using LvivTransport.Client.Core.Exceptions;
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

        public async Task<T> GetAsync<T>(Uri uri, int retryCounter = 0) where T : class
        {
            HttpResponseMessage response;
            try
            {
                response = await _client.GetAsync(uri).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new TransportErrorException(ex);
            }

            // check if status code is retriable
            if (GlobalConstants.RetriableStatuses.Contains((int)response.StatusCode) && retryCounter < GlobalConstants.RetryCount)
            {
                // retry request
                return await GetAsync<T>(uri, retryCounter + 1);
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpResponseException(response, "No stop with specified id");
            }

            var contentType = response.Content.Headers.ContentType.MediaType;

            switch (contentType)
            {
                case GlobalConstants.Json:
                    var responseJson = await _client.GetStringAsync(uri).ConfigureAwait(false);
                    var responseObject = JsonConvert.DeserializeObject<T>(responseJson);
                    return responseObject;

                // this is just because of API developers which didn't implement GetAllStops method
                case GlobalConstants.Html:
                    _parser = new StopsHtmlParser();
                    responseJson = await _parser.ParseStops(await response.Content.ReadAsStringAsync());
                    responseObject = JsonConvert.DeserializeObject<T>(responseJson);
                    return responseObject;

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
