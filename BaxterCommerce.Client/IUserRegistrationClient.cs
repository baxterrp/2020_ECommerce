using BaxterCommerce.CommonClasses.Users;
using System.Threading.Tasks;

namespace BaxterCommerce.Client
{
    /// <summary>
    /// Client for handling HTTP requests for registering users
    /// </summary>
    public interface IUserRegistrationClient
    {
        /// <summary>
        /// Creates a new <see cref="UserResource"/>
        /// </summary>
        /// <param name="userResource">The <see cref="UserResource"/> to create</param>
        /// <returns>The added <see cref="UserResource"/></returns>
        Task<UserResource> RegisterNewUser(UserResource userResource);

        /// <summary>
        /// Finds a specific <see cref="UserResource"/> by <see cref="CommonClasses.BaseResource.Id"/>
        /// </summary>
        /// <param name="id"><see cref="CommonClasses.BaseResource.Id"/></param>
        /// <returns><see cref="UserResource"/></returns>
        Task<UserResource> FindUserById(string id);
    }
}
