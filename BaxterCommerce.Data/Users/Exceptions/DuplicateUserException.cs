using System;

namespace BaxterCommerce.Data.Users.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class DuplicateUserException : Exception
    {
        public DuplicateUserException(string message) : base(message) { }
    }
}
