using DevOne.Security.Cryptography.BCrypt;

namespace BaxterCommerce.Web.Services.Users
{
    /// <summary>
    /// Service for handling password and hashing
    /// </summary>
    public class PasswordHashing : IPasswordHashing
    {
        /// <summary>
        /// Implements <see cref="IPasswordHashing.HashPassword(string)"/>
        /// </summary>
        public string HashPassword(string actualPassword)
        {
            var salt = BCryptHelper.GenerateSalt();
            var hash = BCryptHelper.HashPassword(actualPassword, salt);

            return hash;
        }

        /// <summary>
        /// Implements <see cref="IPasswordHashing.VerifyPassword(string, string)"/>
        /// </summary>
        public bool VerifyPassword(string actualPassword, string hashedPassword)
        {
            var isValid = BCryptHelper.CheckPassword(actualPassword, hashedPassword);

            return isValid;
        }
    }
}
