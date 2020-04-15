using DevOne.Security.Cryptography.BCrypt;
using System;

namespace eCommerceReplacementProject.Users.Server
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

        public bool VerifyPassword(string actualPassword)
        {
            throw new NotImplementedException();
        }
    }
}
