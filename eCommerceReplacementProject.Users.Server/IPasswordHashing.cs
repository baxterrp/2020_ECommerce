namespace eCommerceReplacementProject.Web.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPasswordHashing
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actualPassword"></param>
        /// <returns></returns>
        string HashPassword(string actualPassword);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actualPassword"></param>
        /// <returns></returns>
        bool VerifyPassword(string actualPassword);
    }
}
