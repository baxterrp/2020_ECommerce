using BaxterCommerce.CommonClasses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                return await client.SendAsync(httpRequestMessage);
            }
        }

        /// <summary>
        /// Constructs and sends the <see cref="HttpRequestMessage"/> using provided URI
        /// </summary>
        /// <param name="uri">the URI of the request</param>
        /// <returns><see cref="TResponseObject"/></returns>
        protected async Task<TResponseObject> SendGetRequest(string uri)
        {
            var getRequest = new HttpRequestMessage(HttpMethod.Get, _clientConfiguration.BaseAddress + uri);
            var httpResponse = await SendRequest(getRequest);
            var responseObject = await ReadHttpResponse(httpResponse);

            return responseObject;
        }

        /// <summary>
        /// Constructs and sends the <see cref="HttpRequestMessage"/>
        /// </summary>
        /// <param name="uri">the URI of the request</param>
        /// <param name="resource">The <see cref="TResource"/> to add to the request</param>
        /// <returns><see cref="TResponseObject"/></returns>
        protected async Task<TResponseObject> SendPostRequest(string uri, TResource resource)
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, _clientConfiguration.BaseAddress + uri);
            postRequest.Content = new StringContent(JsonConvert.SerializeObject(resource), Encoding.UTF8, _clientConfiguration.MediaType);
            var httpResponse = await SendRequest(postRequest);
            var responseObject = await ReadHttpResponse(httpResponse);

            return responseObject;
        }
        
        private async Task<TResponseObject> ReadHttpResponse(HttpResponseMessage httpResponse)
        {
            if (httpResponse.IsSuccessStatusCode)
            {
                var stringifiedResult = await httpResponse.Content.ReadAsStringAsync();
                var deserializedResult = JsonConvert.DeserializeObject<TResponseObject>(stringifiedResult);

                return deserializedResult;
            }

            throw await ReadApiException(httpResponse);
        }

        private async Task<ApiException> ReadApiException(HttpResponseMessage httpResponse)
        {
            var exception = JsonConvert.DeserializeObject<ApiException>(await httpResponse.Content.ReadAsStringAsync());

            return exception;
        }
    }
}
