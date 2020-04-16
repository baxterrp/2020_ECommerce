using eCommerceReplacementProject.CommonClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceReplacementProject.Client
{
    /// <summary>
    /// 
    /// </summary>
    public class UserClient : IUserClient
    {
        private readonly ClientConfiguration _clientConfiguration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientConfiguration"></param>
        public UserClient(ClientConfiguration clientConfiguration)
        {
            _clientConfiguration = clientConfiguration ?? throw new ArgumentNullException(nameof(clientConfiguration));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserResource> FindUserById(string id)
        {
            using (var client = new HttpClient())
            {
                var requestAddress = $"{_clientConfiguration.BaseAddress}/user/{id}";
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, requestAddress);

                var httpResponse = await client.SendAsync(httpRequest);

                return await ReadHttpResponse(httpResponse);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userResource"></param>
        /// <returns></returns>
        public async Task<UserResource> RegisterNewUser(UserResource userResource)
        {
            using (var client = new HttpClient())
            {
                var requestAddress = $"{_clientConfiguration.BaseAddress}/user";
                var request = new HttpRequestMessage(HttpMethod.Post, requestAddress);
                request.Content = new StringContent(JsonConvert.SerializeObject(userResource), UTF8Encoding.UTF8, _clientConfiguration.MediaType);

                var httpResponse = await client.SendAsync(request);

                return await ReadHttpResponse(httpResponse);
            }
        }

        private async Task<UserResource> ReadHttpResponse(HttpResponseMessage httpResponse)
        {
            var stringifiedResult = await httpResponse.Content.ReadAsStringAsync();
            var deserializedResult = JsonConvert.DeserializeObject<UserResource>(stringifiedResult);

            return deserializedResult;
        }
    }
}
