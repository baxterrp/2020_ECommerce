namespace BaxterCommerce.Client
{
    /// <summary>
    /// Configuration class for handling HTTP requests
    /// </summary>
    public class ClientConfiguration
    {
        /// <summary>
        /// Base address request URL
        /// </summary>
        public string BaseAddress { get; set; }

        /// <summary>
        /// Media type of request to include in request header
        /// </summary>
        public string MediaType { get; set; }
    }
}
