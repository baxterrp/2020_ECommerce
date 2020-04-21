namespace BaxterCommerce.CommonClasses.Users
{
    /// <summary>
    /// Search parameters for querying Users
    /// </summary>
    public class UserSearchParameters : BaseSearchParameters
    {
        /// <summary>
        /// The Email column referencing <see cref="UserResource.Email"/>
        /// </summary>
        public string Email { get; set; }
    }
}
