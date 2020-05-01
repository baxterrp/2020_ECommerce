namespace BaxterCommerce.Data.Base
{
    /// <summary>
    /// Configuration class for connecting to database
    /// </summary>
    public class ConnectionConfiguration
    {
        /// <summary>
        /// The targeted machine name
        /// </summary>
        public string DataSource { get; set; }

        /// <summary>
        /// Name of database
        /// </summary>
        public string Catalog { get; set; }

        /// <summary>
        /// Allow integrated security
        /// </summary>
        public string IntegratedSecurity { get; set; }

        /// <summary>
        /// Username of db
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password to db
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Combines components of connection string with argument names
        /// </summary>
        public string GetConnectionString() => $"Server={DataSource};Initial Catalog={Catalog};Persist Security Info=False;User ID={UserName};Password={Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}
