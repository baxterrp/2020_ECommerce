using BaxterCommerce.CommonClasses.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaxterCommerce.Data.Users
{
    /// <summary>
    /// Repository for User related operations
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Creates a new <see cref="UserResource"/>
        /// </summary>
        /// <param name="resource">The <see cref="UserResource"/> to create</param>
        Task Insert(UserResource resource);

        /// <summary>
        /// Updates a <see cref="UserResource"/>
        /// </summary>
        /// <param name="resource">The <see cref="UserResource"/> with updated properties</param>
        Task Update(UserResource resource);

        /// <summary>
        /// Finds one or many <see cref="UserResource"/> based on provided <see cref="UserSearchParameters"/>
        /// </summary>
        /// <param name="parameters">The <see cref="UserSearchParameters"/> provided for query</param>
        /// <returns><see cref="IEnumerable{T}"/> of <see cref="UserResource"/></returns>
        Task<IEnumerable<UserResource>> Find(UserSearchParameters parameters);

        /// <summary>
        /// Finds a single <see cref="UserResource"/> based on <see cref="CommonClasses.BaseResource.Id"/>
        /// </summary>
        /// <param name="id">The primary id of the <see cref="UserResource"/></param>
        /// <returns><see cref="UserResource"/></returns>
        Task<UserResource> FindById(string id);
    }
}
