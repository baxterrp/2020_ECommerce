using BaxterCommerce.CommonClasses.Users;
using BaxterCommerce.Data.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaxterCommerce.Data.Users
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRepository : BaseDataRepository<UserResource>, IUserRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionConfiguration"></param>
        /// <param name="tableConfiguration"></param>
        public UserRepository(ConnectionConfiguration connectionConfiguration, BaseTableConfiguration tableConfiguration) 
            : base(connectionConfiguration, tableConfiguration)
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserResource>> Find(UserSearchParameters parameters) => await base.Find(parameters);
    }
}
