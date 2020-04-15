using eCommerceReplacementProject.CommonClasses;
using System.Threading.Tasks;

namespace eCommerceReplacementProject.Users.Server
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userResource"></param>
        /// <returns></returns>
        Task<UserResource> CreateNewUser(UserResource userResource);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserResource> GetUserById(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userResource"></param>
        /// <returns></returns>
        Task UpdateUser(UserResource userResource);
    }
}
