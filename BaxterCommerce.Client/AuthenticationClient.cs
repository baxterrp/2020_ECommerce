using BaxterCommerce.CommonClasses.Users;
using System.Threading.Tasks;

namespace BaxterCommerce.Client
{
    /// <summary>
    /// Client for handling user authentication
    /// </summary>
    public class AuthenticationClient : BaseHttpRequestClient<LoginRequest, LoginResponse>, IAuthenticationClient
    {
        public AuthenticationClient(ClientConfiguration clientConfiguration) : base(clientConfiguration)
        {
        }

        /// <summary>
        /// Implements <see cref="IAuthenticationClient.Login(LoginRequest)"/>
        /// </summary>
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var requestUri = $"/user/login";
            var response = await SendPostRequest(requestUri, loginRequest);
            var message = response.Success ? "Login Successful" : "Invalid Credentials";
            response.Messages.Add(message);

            return response;
        }
    }
}
