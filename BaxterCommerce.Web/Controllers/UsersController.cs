using BaxterCommerce.CommonClasses.Users;
using BaxterCommerce.Web.Services;
using Microsoft.AspNetCore.Mvc;
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

        public UsersController(IUserService userService)
        {
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
            return Ok(await _userService.GetUserById(id));
        }

        /// <summary>
        /// Creates a new <see cref="UserResource"/>
        /// </summary>
        /// <param name="userResource">The <see cref="UserResource"/> to create</param>
        /// <returns>The added <see cref="UserResource"/></returns>
        [HttpPost("/user")]
        public async Task<IActionResult> CreateNewUser([FromBody] UserResource userResource)
        {
            return Ok(await _userService.CreateNewUser(userResource));
        }

        /// <summary>
        /// Attempts to login using a <see cref="LoginRequest"/>
        /// </summary>
        /// <param name="loginRequest"><see cref="LoginRequest"/></param>
        /// <returns><see cref="LoginRequest"/></returns>
        [HttpPost("/user/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var response = await _userService.AttemptLogin(loginRequest);

            return Ok(response);
        }
    }
}
