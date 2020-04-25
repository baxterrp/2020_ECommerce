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
            _logger.Debug("Received request to find User by Id : {userId}", id);

            var user = await _userService.GetUserById(id);

            _logger.Debug("Found user {email} with id {id}", user.Email, user.Id);

            return Ok(user);
        }

        /// <summary>
        /// Creates a new <see cref="UserResource"/>
        /// </summary>
        /// <param name="userResource">The <see cref="UserResource"/> to create</param>
        /// <returns>The added <see cref="UserResource"/></returns>
        [HttpPost("/user")]
        public async Task<IActionResult> CreateNewUser([FromBody] UserResource userResource)
        {
            _logger.Debug("Creating {user}", userResource);

            var user = await _userService.CreateNewUser(userResource);

            _logger.Debug("Created user with id {userId}", user.Id);

            return Ok(user);
        }

        /// <summary>
        /// Attempts to login using a <see cref="LoginRequest"/>
        /// </summary>
        /// <param name="loginRequest"><see cref="LoginRequest"/></param>
        /// <returns><see cref="LoginRequest"/></returns>
        [HttpPost("/user/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            _logger.Debug("Attempting to login user with email {email}", loginRequest.Email);

            var response = await _userService.AttemptLogin(loginRequest);

            if (response.Success)
            {
                _logger.Debug("Successfully logged in user {user}", response.User);
            }
            else
            {
                _logger.Debug("Login attempted failed with email {email}, invalid credentials", loginRequest.Email);
            }

            return Ok(response);
        }
    }
}
