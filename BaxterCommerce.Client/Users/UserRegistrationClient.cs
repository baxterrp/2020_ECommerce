using BaxterCommerce.CommonClasses.Users;
using System.Threading.Tasks;

namespace BaxterCommerce.Client.Users
{
    /// <summary>
    /// Client for handling requests for user registration
    /// </summary>
    public class UserRegistrationClient : BaseHttpRequestClient<UserResource, UserResource>, IUserRegistrationClient
    {
        public UserRegistrationClient(ClientConfiguration clientConfiguration) : base(clientConfiguration)
        {
        }

        private static readonly string _baseUserURI = "/user";

        /// <summary>
        /// Implements <see cref="IUserRegistrationClient.FindUserById(string)"/>
        /// </summary>
        public async Task<UserResource> FindUserById(string id) =>
             await SendGetRequest($"{_baseUserURI}/{id}");

        /// <summary>
        /// Implements <see cref="IUserRegistrationClient.RegisterNewUser(UserResource)"/>
        /// </summary>
        public async Task<UserResource> RegisterNewUser(UserResource userResource) =>
            await SendPostRequest(_baseUserURI, userResource);
    }
}
