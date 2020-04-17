using BaxterCommerce.CommonClasses.Users;
using System.Threading.Tasks;

namespace BaxterCommerce.Client
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAuthenticationClient
    {
        /// <summary>
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        Task<UserResource> Login(LoginRequest loginRequest);
    }
}