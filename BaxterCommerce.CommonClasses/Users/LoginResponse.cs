using System.Collections.Generic;

namespace BaxterCommerce.CommonClasses.Users
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<string> Messages { get; set; } = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        public UserResource User { get; set; }
    }
}
