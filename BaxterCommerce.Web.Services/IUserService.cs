using BaxterCommerce.CommonClasses.Users;
using System.Threading.Tasks;

namespace BaxterCommerce.Web.Services
{
    /// <summary>
    /// Service for handling <see cref="UserResource"/>
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Creates a new <see cref="UserResource"/>
        /// </summary>
        /// <param name="userResource"><see cref="UserResource"/></param>
        /// <returns>The created <see cref="UserResource"/></returns>
        Task<UserResource> CreateNewUser(UserResource userResource);

        /// <summary>
        /// Finds <see cref="UserResource"/> by <see cref="CommonClasses.BaseResource.Id"/>
        /// </summary>
        /// <param name="id"><see cref="CommonClasses.BaseResource.Id"/></param>
        /// <returns>A single <see cref="UserResource"/></returns>
        Task<UserResource> GetUserById(string id);

        /// <summary>
        /// Updates a <see cref="UserResource"/>
        /// </summary>
        /// <param name="userResource">The given <see cref="UserResource"/></param>
        Task UpdateUser(UserResource userResource);

        /// <summary>
        /// Attempts to login using <see cref="LoginRequest"/>
        /// </summary>
        /// <param name="loginRequest"><see cref="LoginRequest"/></param>
        /// <returns><see cref="LoginResponse"/></returns>
        Task<LoginResponse> AttemptLogin(LoginRequest loginRequest);
    }
}
