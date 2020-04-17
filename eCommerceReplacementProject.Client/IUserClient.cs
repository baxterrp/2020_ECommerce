﻿using eCommerceReplacementProject.CommonClasses.Users;
using System.Threading.Tasks;

namespace eCommerceReplacementProject.Client
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserClient
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
