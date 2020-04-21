namespace BaxterCommerce.CommonClasses.Users
{
    /// <summary>
    /// Contract for attempting a login
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// The user's given email
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// The user's given password
        /// </summary>
        public string Password { get; set; }
    }
}
