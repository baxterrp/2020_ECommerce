namespace BaxterCommerce.CommonClasses.Users
{
    /// <summary>
    /// Inherets <see cref="BaseResource"/> represents a single user
    /// </summary>
    public class UserResource : BaseResource
    {
        /// <summary>
        /// The user's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The user's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The user's home address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The user's home city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The user's home state
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The user's home zip code
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// The user's phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The user's email login
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The user's login password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Signifies if the user has administrative privilege 
        /// </summary>
        public int IsAdmin { get; set; }
    }
}
