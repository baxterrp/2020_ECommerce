using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BaxterCommerce.Client
{
    /// <summary>
    /// Base client for sending and handling HTTP requests
    /// </summary>
    public abstract class BaseHttpRequestClient<TResource, TResponseObject>
    {
        private readonly ClientConfiguration _clientConfiguration;

        public BaseHttpRequestClient(ClientConfiguration clientConfiguration)
        {
            _clientConfiguration = clientConfiguration ?? throw new ArgumentNullException(nameof(clientConfiguration));
        }

        /// <summary>
        /// Sends an HTTP request using the specified <see cref="HttpRequestMessage"/>
        /// </summary>
        /// <param name="httpRequestMessage"><see cref="HttpRequestMessage"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        protected async Task<HttpResponseMessage> SendRequest(HttpRequestMessage httpRequestMessage)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var result = await client.SendAsync(httpRequestMessage);

                    return result;
                }
                catch
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Constructs the <see cref="HttpRequestMessage"/> using provided <see cref="ClientConfiguration"/> and URI
        /// </summary>
        /// <param name="uri">the URI of the request</param>
        /// <returns><see cref="HttpRequestMessage"/></returns>
        protected HttpRequestMessage BuildGetRequest(string uri) => new HttpRequestMessage(HttpMethod.Get, _clientConfiguration.BaseAddress + uri);

        /// <summary>
        /// Constructs the <see cref="HttpRequestMessage"/>
        /// </summary>
        /// <param name="uri">the URI of the request</param>
        /// <param name="resource">The <see cref="TResource"/> to add to the request</param>
        /// <returns><see cref="HttpRequestMessage"/></returns>
        protected HttpRequestMessage BuildPostRequest(string uri, TResource resource)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _clientConfiguration.BaseAddress + uri);
            request.Content = new StringContent(JsonConvert.SerializeObject(resource), Encoding.UTF8, _clientConfiguration.MediaType);

            return request;
        }

        /// <summary>
        /// Reads the <see cref="HttpResponseMessage"/> from the request and converts to <see cref="TResponseObject"/>
        /// </summary>
        /// <param name="httpResponse"><see cref="HttpResponseMessage"/></param>
        /// <returns><see cref="TResponseObject"/></returns>
        protected async Task<TResponseObject> ReadHttpResponse(HttpResponseMessage httpResponse)
        {
            var stringifiedResult = await httpResponse.Content.ReadAsStringAsync();
            var deserializedResult = JsonConvert.DeserializeObject<TResponseObject>(stringifiedResult);

            return deserializedResult;
        }
    }
}
