using eCommerceReplacementProject.CommonClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerceReplacementProject.Users.Server
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        Task Insert(UserResource resource);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        Task Update(UserResource resource);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<IEnumerable<UserResource>> Find(UserSearchParameters parameters);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserResource> FindById(string id);
    }
}
