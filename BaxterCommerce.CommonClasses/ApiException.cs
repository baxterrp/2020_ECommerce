using System;

namespace BaxterCommerce.CommonClasses
{
    /// <summary>
    /// Exception to contain message regarding error in API
    /// </summary>
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message) { }
    }
}
