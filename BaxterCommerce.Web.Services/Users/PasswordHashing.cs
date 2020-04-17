using DevOne.Security.Cryptography.BCrypt;

namespace BaxterCommerce.Web.Services.Users
{
    /// <summary>
    /// 
    /// </summary>
    public class PasswordHashing : IPasswordHashing
    {
        public string HashPassword(string actualPassword)
        {
            var salt = BCryptHelper.GenerateSalt();
            var hash = BCryptHelper.HashPassword(actualPassword, salt);

            return hash;
        }

        public bool VerifyPassword(string actualPassword, string hashedPassword)
        {
            var isValid = BCryptHelper.CheckPassword(actualPassword, hashedPassword);

            return isValid;
        }
    }
}
