using BaxterCommerce.CommonClasses.Users;
using System.Threading.Tasks;

namespace BaxterCommerce.Client
{
    /// <summary>
    /// Client for handling requests for user registration
    /// </summary>
    public class UserRegistrationClient : BaseHttpRequestClient<UserResource, UserResource>, IUserRegistrationClient
    {
        public UserRegistrationClient(ClientConfiguration clientConfiguration) : base(clientConfiguration)
        {
        }

        /// <summary>
        /// Implements <see cref="IUserRegistrationClient.FindUserById(string)"/>
        /// </summary>
        public async Task<UserResource> FindUserById(string id)
        {
            var requestUri = $"/user/{id}";
            var httpRequest = BuildGetRequest(requestUri);
            var httpResponse = await SendRequest(httpRequest);

            return await ReadHttpResponse(httpResponse);
        }

        /// <summary>
        /// Implements <see cref="IUserRegistrationClient.RegisterNewUser(UserResource)"/>
        /// </summary>
        public async Task<UserResource> RegisterNewUser(UserResource userResource)
        {
            var requestUri = "/user";
            var httpRequest = BuildPostRequest(requestUri, userResource);
            var httpResponse = await SendRequest(httpRequest);

            return await ReadHttpResponse(httpResponse);
        }
    }
}
