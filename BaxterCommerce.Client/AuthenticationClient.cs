using BaxterCommerce.CommonClasses.Users;
using Newtonsoft.Json;
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
            var httpRequest = BuildPostRequest(requestUri, loginRequest);
            var httpResponse = await SendRequest(httpRequest);

            if (httpResponse.IsSuccessStatusCode)
            {
                var successResponse = await ReadHttpResponse(httpResponse);
                var message = successResponse.Success ? "Login Successful" : "Invalid Credentials";
                successResponse.Messages.Add(message);

                return successResponse;
            }
            else
            {
                var exceptionResponse = JsonConvert.DeserializeObject(await httpRequest.Content.ReadAsStringAsync());
                var errorResponse = new LoginResponse { Success = false };
                errorResponse.Messages.Add((string)exceptionResponse);

                return errorResponse;
            }
        }
    }
}
