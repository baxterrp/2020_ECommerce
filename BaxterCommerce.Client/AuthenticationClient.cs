using BaxterCommerce.CommonClasses.Users;
using System;
using System.Threading.Tasks;

namespace BaxterCommerce.Client
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticationClient : BaseHttpRequestClient<LoginRequest, LoginResponse>, IAuthenticationClient
    {
        public AuthenticationClient(ClientConfiguration clientConfiguration) : base(clientConfiguration)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var requestUri = $"/user/login";
            var httpRequest = BuildPostRequest(requestUri, loginRequest);
            var httpResponse = await SendRequest(httpRequest);

            if (httpResponse.IsSuccessStatusCode)
            {
                var successResponse = await ReadHttpResponse(httpResponse);

                var message = successResponse.Success ? "Login Successful" : "Invalid Credentials";

                successResponse.Messages.Add(message);

                return successResponse;
            }

            var errorResponse = new LoginResponse
            {
                Success = false,
            };

            errorResponse.Messages.Add("An error occured making the request");

            return errorResponse;
        }
    }
}
