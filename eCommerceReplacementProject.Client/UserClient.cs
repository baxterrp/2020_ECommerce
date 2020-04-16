using eCommerceReplacementProject.CommonClasses;
using System.Net.Http;
using System.Threading.Tasks;

namespace eCommerceReplacementProject.Client
{
    /// <summary>
    /// 
    /// </summary>
    public class UserClient : BaseHttpRequestClient<UserResource>, IUserClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientConfiguration"></param>
        public UserClient(ClientConfiguration clientConfiguration) : base(clientConfiguration)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserResource> FindUserById(string id)
        {
            var requestUri = $"/user/{id}";
            var httpRequest = BuildGetRequest(requestUri);
            var httpResponse = await SendRequest(httpRequest);

            return await ReadHttpResponse(httpResponse);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userResource"></param>
        /// <returns></returns>
        public async Task<UserResource> RegisterNewUser(UserResource userResource)
        {
            var requestUri = "/user";
            var httpRequest = BuildPostRequest(requestUri, userResource);
            var httpResponse = await SendRequest(httpRequest);

            return await ReadHttpResponse(httpResponse);
        }
    }
}
