using BaxterCommerce.CommonClasses.Users;
using System;
using System.Threading.Tasks;

namespace BaxterCommerce.Client
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticationClient : BaseHttpRequestClient<LoginRequest, UserResource>, IAuthenticationClient
    {
        public AuthenticationClient(ClientConfiguration clientConfiguration) : base(clientConfiguration)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        public async Task<UserResource> Login(LoginRequest loginRequest)
        {
            var requestUri = $"/user/login";
            var httpRequest = BuildPostRequest(requestUri, loginRequest);
            var httpResponse = await SendRequest(httpRequest);

            if (httpResponse.IsSuccessStatusCode)
            {
                return await ReadHttpResponse(httpResponse);
            }

            throw new InvalidOperationException("Attempt made to login with invalid credentials");
        }
    }
}
