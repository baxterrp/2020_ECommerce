namespace BaxterCommerce.CommonClasses.Users
{
    /// <summary>
    /// 
    /// </summary>
    public class UserResource : BaseResource
    {
        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IsAdmin { get; set; }
    }
}
