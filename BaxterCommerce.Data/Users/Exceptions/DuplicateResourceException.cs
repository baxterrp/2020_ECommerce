using System;

namespace BaxterCommerce.Data.Users.Exceptions
{
    /// <summary>
    /// Thrown when a resource has a duplicate value stored
    /// </summary>
    public class DuplicateResourceException : Exception
    {
        public DuplicateResourceException(string message) : base(message) { }
    }
}
