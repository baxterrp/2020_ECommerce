using BaxterCommerce.CommonClasses.Users;
using BaxterCommerce.Data.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BaxterCommerce.Web.Services.Users
{
    /// <summary>
    /// Service for handling <see cref="UserResource"/>
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashing _passwordHashing;
        
        public UserService(IUserRepository userRepository, IPasswordHashing passwordHashing)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _passwordHashing = passwordHashing ?? throw new ArgumentNullException(nameof(passwordHashing));
        }

        /// <summary>
        /// Implements <see cref="IUserService.AttemptLogin(LoginRequest)"/> 
        /// </summary>
        public async Task<LoginResponse> AttemptLogin(LoginRequest loginRequest)
        {
            var userFromEmail = (await _userRepository.Find(new UserSearchParameters { Email = loginRequest.Email })).Single();
            var isValidPassword = _passwordHashing.VerifyPassword(loginRequest.Password, userFromEmail.Password);
            var loginResponse = new LoginResponse();

            if (isValidPassword)
            {
                loginResponse.Success = true;
                loginResponse.User = userFromEmail;
            }
            else
            {
                loginResponse.Success = false;
            }

            return loginResponse;
        }

        /// <summary>
        /// Implements <see cref="IUserService.CreateNewUser(UserResource)"/>
        /// </summary>
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
        /// Implements <see cref="IUserService.GetUserById(string)"/>
        /// </summary>
        public async Task<UserResource> GetUserById(string id)
        {
            var result = await _userRepository.FindById(id);

            return result;
        }

        /// <summary>
        /// Implements <see cref="IUserService.UpdateUser(UserResource)"/>
        /// </summary>
        public Task UpdateUser(UserResource userResource)
        {
            throw new System.NotImplementedException();
        }
    }
}
