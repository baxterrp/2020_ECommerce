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
        public string Address { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string City { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Pho
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber { get; set; }

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
