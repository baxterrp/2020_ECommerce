using BaxterCommerce.CommonClasses.Users;
using System.Threading.Tasks;

namespace BaxterCommerce.Client
{
    /// <summary>
    /// Handles HTTP requests for user authentication
    /// </summary>
    public interface IAuthenticationClient
    {
        /// <summary>
        /// Attempts an HTTP request for logging in a user
        /// </summary>
        /// <param name="loginRequest"><see cref="LoginRequest"/></param>
        /// <returns><see cref="LoginResponse"/></returns>
        Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}