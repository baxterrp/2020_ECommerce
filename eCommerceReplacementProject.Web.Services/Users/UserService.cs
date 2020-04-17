using eCommerceReplacementProject.CommonClasses.Users;
using eCommerceReplacementProject.Data.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceReplacementProject.Web.Services.Users
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
