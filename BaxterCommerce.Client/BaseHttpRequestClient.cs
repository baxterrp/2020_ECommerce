using BaxterCommerce.CommonClasses;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BaxterCommerce.Client
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseHttpRequestClient<TResource, TResponseObject>
    {
        private readonly ClientConfiguration _clientConfiguration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientConfiguration"></param>
        public BaseHttpRequestClient(ClientConfiguration clientConfiguration)
        {
            _clientConfiguration = clientConfiguration ?? throw new ArgumentNullException(nameof(clientConfiguration));
        }

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
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        protected HttpRequestMessage BuildGetRequest(string uri) => new HttpRequestMessage(HttpMethod.Get, _clientConfiguration.BaseAddress + uri);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        protected HttpRequestMessage BuildPostRequest(string uri, TResource resource)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _clientConfiguration.BaseAddress + uri);
            request.Content = new StringContent(JsonConvert.SerializeObject(resource), Encoding.UTF8, _clientConfiguration.MediaType);

            return request;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpResponse"></param>
        /// <returns></returns>
        protected async Task<TResponseObject> ReadHttpResponse(HttpResponseMessage httpResponse)
        {
            var stringifiedResult = await httpResponse.Content.ReadAsStringAsync();
            var deserializedResult = JsonConvert.DeserializeObject<TResponseObject>(stringifiedResult);

            return deserializedResult;
        }
    }
}
