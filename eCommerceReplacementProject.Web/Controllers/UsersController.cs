using eCommerceReplacementProject.CommonClasses;
using eCommerceReplacementProject.Users.Server;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace eCommerceReplacementProject.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    //TODO: do exception handling
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        public UsersController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/user/{id}")]
        public async Task<IActionResult> FindUserById([FromRoute] string id)
        {
            return Ok(await _userService.GetUserById(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userResource"></param>
        /// <returns></returns>
        [HttpPost("/user")]
        public async Task<IActionResult> CreateNewUser([FromBody] UserResource userResource)
        {
            return Ok(await _userService.CreateNewUser(userResource));
        }
    }
}
