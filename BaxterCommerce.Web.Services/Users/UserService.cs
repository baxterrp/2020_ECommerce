using BaxterCommerce.CommonClasses.Users;
using BaxterCommerce.Data.Logging;
using BaxterCommerce.Data.Users;
using BaxterCommerce.Data.Users.Exceptions;
using Serilog;
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
        private readonly ILogger _logger;
        
        public UserService(IUserRepository userRepository, IPasswordHashing passwordHashing)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _passwordHashing = passwordHashing ?? throw new ArgumentNullException(nameof(passwordHashing));
            _logger = LoggerFactory.CreateLogger();
        }

        /// <summary>
        /// Implements <see cref="IUserService.AttemptLogin(LoginRequest)"/> 
        /// </summary>
        public async Task<LoginResponse> AttemptLogin(LoginRequest loginRequest)
        {
            ValidateLoginRequest(loginRequest);

            _logger.Debug("Attempted to find user with email {email", loginRequest.Email);
            
            var userFromEmail = (await _userRepository.Find(new UserSearchParameters { Email = loginRequest.Email })).Single();

            _logger.Debug("Found user {user}", userFromEmail);

            _logger.Debug("Verifying user password for {email}", userFromEmail.Email);
            var isValidPassword = _passwordHashing.VerifyPassword(loginRequest.Password, userFromEmail.Password);

            var loginResponse = new LoginResponse();

            if (isValidPassword)
            {
                _logger.Debug("Successfully logged in user with email {email}", userFromEmail.Email);
                loginResponse.Success = true;
                loginResponse.User = userFromEmail;
            }
            else
            {
                _logger.Debug("Login attempt failed for user {email}", userFromEmail.Email);
                loginResponse.Success = false;
            }

            return loginResponse;
        }

        /// <summary>
        /// Implements <see cref="IUserService.CreateNewUser(UserResource)"/>
        /// </summary>
        public async Task<UserResource> CreateNewUser(UserResource userResource)
        {
            ValidateUserResource(userResource);

            _logger.Debug("Creating user {user}", userResource);
            userResource.Id = Guid.NewGuid().ToString();
            userResource.CreatedAt = DateTime.Now;
            userResource.UpdatedAt = DateTime.Now;

            _logger.Debug("Generated id {userId} at {createdAt} for user {user}", userResource.Id, userResource.CreatedAt, userResource);

            userResource.IsAdmin = userResource.IsAdmin > 0 ? 1 : 0;

            _logger.Debug("Hashing password for user {email}", userResource.Email);
            userResource.Password = _passwordHashing.HashPassword(userResource.Password);

            await ValidateUserDoesNotExist(userResource);
            await _userRepository.Insert(userResource);

            return userResource;
        }

        /// <summary>
        /// Implements <see cref="IUserService.GetUserById(string)"/>
        /// </summary>
        public async Task<UserResource> GetUserById(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

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

        private async Task ValidateUserDoesNotExist(UserResource userResource)
        {
            _logger.Debug("Looking up email {email} to validate it does not exist", userResource.Email);
            var potentionalUsers = await _userRepository.Find(new UserSearchParameters { Email = userResource.Email });

            if (potentionalUsers.Any())
            {
                _logger.Debug("Cannot create new user with email {email}, a user with that email already exists", userResource.Email);
                throw new DuplicateUserException($"User with email {userResource.Email} already exists");
            }
        }

        private void ValidateUserResource(UserResource userResource)
        {
            if (userResource is null) throw new ArgumentNullException(nameof(userResource));
            if (string.IsNullOrWhiteSpace(userResource.Email)) throw new ArgumentNullException(nameof(userResource.Email));
            if (string.IsNullOrWhiteSpace(userResource.FirstName)) throw new ArgumentNullException(nameof(userResource.FirstName));
            if (string.IsNullOrWhiteSpace(userResource.LastName)) throw new ArgumentNullException(nameof(userResource.LastName));
            if (string.IsNullOrWhiteSpace(userResource.Password)) throw new ArgumentNullException(nameof(userResource.Password));
            if (string.IsNullOrWhiteSpace(userResource.Address)) throw new ArgumentNullException(nameof(userResource.Address));
            if (string.IsNullOrWhiteSpace(userResource.City)) throw new ArgumentNullException(nameof(userResource.City));
            if (string.IsNullOrWhiteSpace(userResource.State)) throw new ArgumentNullException(nameof(userResource.State));
            if (string.IsNullOrWhiteSpace(userResource.ZipCode)) throw new ArgumentNullException(nameof(userResource.ZipCode));
            if (string.IsNullOrWhiteSpace(userResource.PhoneNumber)) throw new ArgumentNullException(nameof(userResource.PhoneNumber));
        }

        private void ValidateLoginRequest(LoginRequest loginRequest)
        {
            if (loginRequest is null) throw new ArgumentNullException(nameof(loginRequest));
            if (string.IsNullOrWhiteSpace(loginRequest.Email)) throw new ArgumentNullException(nameof(loginRequest.Equals));
            if (string.IsNullOrWhiteSpace(loginRequest.Password)) throw new ArgumentNullException(nameof(loginRequest.Password));
        }
    }
}
