using BaxterCommerce.CommonClasses.Users;
using BaxterCommerce.Data.Logging;
using BaxterCommerce.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace BaxterCommerce.Web.Controllers
{
    /// <summary>
    /// Constroller for handling User related HTTP requests
    /// </summary>
    //TODO: do exception handling
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public UsersController(IUserService userService)
        {
            _logger = LoggerFactory.CreateLogger();
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        /// <summary>
        /// Finds a <see cref="UserResource"/> by <see cref="CommonClasses.BaseResource.Id"/>
        /// </summary>
        /// <param name="id"><see cref="CommonClasses.BaseResource.Id"/></param>
        /// <returns><see cref="UserResource"/></returns>
        [HttpGet("/user/{id}")]
        public async Task<IActionResult> FindUserById([FromRoute] string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            try
            {
                _logger.Debug("Received request to find User by Id : {userId}", id);

                var user = await _userService.GetUserById(id);

                _logger.Debug("Found user {email} with id {id}", user.Email, user.Id);

                return Ok(user);
            }
            catch(Exception exception)
            {
                _logger.Debug(exception.ToString());
                throw;
            }
        }

        /// <summary>
        /// Creates a new <see cref="UserResource"/>
        /// </summary>
        /// <param name="userResource">The <see cref="UserResource"/> to create</param>
        /// <returns>The added <see cref="UserResource"/></returns>
        [HttpPost("/user")]
        public async Task<IActionResult> CreateNewUser([FromBody] UserResource userResource)
        {
            ValidateUserResource(userResource);

            try
            {
                _logger.Debug("Creating {user}", userResource);

                var user = await _userService.CreateNewUser(userResource);

                _logger.Debug("Created user with id {userId}", user.Id);

                return Ok(user);
            }
            catch(Exception exception)
            {
                _logger.Debug(exception.ToString());
                throw;
            }
        }

        /// <summary>
        /// Attempts to login using a <see cref="LoginRequest"/>
        /// </summary>
        /// <param name="loginRequest"><see cref="LoginRequest"/></param>
        /// <returns><see cref="LoginRequest"/></returns>
        [HttpPost("/user/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest is null) throw new ArgumentNullException(nameof(loginRequest));
            if (string.IsNullOrWhiteSpace(loginRequest.Email)) throw new ArgumentNullException(nameof(loginRequest.Equals));
            if (string.IsNullOrWhiteSpace(loginRequest.Password)) throw new ArgumentNullException(nameof(loginRequest.Password));

            try
            {
                _logger.Debug("Attempting to login user with email {email}", loginRequest.Email);

                var response = await _userService.AttemptLogin(loginRequest);

                if (response.Success)
                {
                    _logger.Debug("Successfully logged in user {user}", response.User);
                }
                else
                {
                    _logger.Debug("Login attempt failed with email {email}, invalid credentials", loginRequest.Email);
                }

                return Ok(response);
            }
            catch(Exception exception)
            {
                _logger.Debug(exception.ToString());
                throw;
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
    }
}
