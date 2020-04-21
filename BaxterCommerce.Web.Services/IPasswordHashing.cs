namespace BaxterCommerce.Web.Services
{
    /// <summary>
    /// Service for handling password hashing
    /// </summary>
    public interface IPasswordHashing
    {
        /// <summary>
        /// Hashed the password provided
        /// </summary>
        /// <param name="actualPassword">The user's actual password</param>
        /// <returns>The hashed password</returns>
        string HashPassword(string actualPassword);

        /// <summary>
        /// Checks password against the stored hashed password
        /// </summary>
        /// <param name="actualPassword">The user's actual password</param>
        /// <param name="hashedPassword">The hashed password</param>
        /// <returns>true if password is valid, false if not</returns>
        bool VerifyPassword(string actualPassword, string hashedPassword);
    }
}
