﻿using eCommerceReplacementProject.CommonClasses;
using System;
using System.Threading.Tasks;

namespace eCommerceReplacementProject.Users.Server
{
    /// <summary>
    /// 
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashing _passwordHashing;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="passwordHashing"></param>
        public UserService(IUserRepository userRepository, IPasswordHashing passwordHashing)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _passwordHashing = passwordHashing ?? throw new ArgumentNullException(nameof(passwordHashing));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userResource"></param>
        /// <returns></returns>
        public async Task<UserResource> CreateNewUser(UserResource userResource)
        {
            userResource.Id = Guid.NewGuid().ToString();
            userResource.CreatedAt = DateTime.Now;
            userResource.UpdatedAt = DateTime.Now;

            userResource.IsAdmin = userResource.IsAdmin > 0 ? 1 : 0;

            userResource.Password = _passwordHashing.HashPassword(userResource.Password);

            await _userRepository.Insert(userResource);

            return userResource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserResource> GetUserById(string id)
        {
            var result = await _userRepository.FindById(id);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userResource"></param>
        /// <returns></returns>
        public Task UpdateUser(UserResource userResource)
        {
            throw new System.NotImplementedException();
        }
    }
}
