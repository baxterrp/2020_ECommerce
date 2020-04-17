using BaxterCommerce.CommonClasses.Users;
using System.Threading.Tasks;

namespace BaxterCommerce.Client
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserRegistrationClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userResource"></param>
        /// <returns></returns>
        Task<UserResource> RegisterNewUser(UserResource userResource);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserResource> FindUserById(string id);
    }
}
