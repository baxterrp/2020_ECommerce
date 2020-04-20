using BaxterCommerce.CommonClasses.Users;
using BaxterCommerce.Data.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaxterCommerce.Data.Users
{
    /// <summary>
    /// Repository for peforming actions on <see cref="UserResource"/>
    /// </summary>
    public class UserRepository : BaseDataRepository<UserResource>, IUserRepository
    {
        public UserRepository(ConnectionConfiguration connectionConfiguration, BaseTableConfiguration tableConfiguration) 
            : base(connectionConfiguration, tableConfiguration)
        {
        }
        
        /// <summary>
        /// Implements <see cref="BaseDataRepository{TResource}.Find(CommonClasses.BaseSearchParameters)"/>
        /// </summary>
        /// <param name="parameters"><see cref="UserSearchParameters"/></param>
        /// <returns><see cref="IEnumerable{T}"/> of <see cref="UserResource"/></returns>
        public async Task<IEnumerable<UserResource>> Find(UserSearchParameters parameters) => await base.Find(parameters);
    }
}
