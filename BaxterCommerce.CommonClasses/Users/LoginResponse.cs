using System.Collections.Generic;

namespace BaxterCommerce.CommonClasses.Users
{
    /// <summary>
    /// Contract for response to login attempt  
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Signifies if the login attempt was successful or not
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Messages built througout the login attempt
        /// </summary>
        /// <example>Successful Login</example>
        public IList<string> Messages { get; set; } = new List<string>();

        /// <summary>
        /// The <see cref="UserResource"/> of the successful login
        /// </summary>
        public UserResource User { get; set; }
    }
}
