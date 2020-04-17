using eCommerceReplacementProject.Data.Base;

namespace eCommerceReplacementProject.Data.Users
{
    /// <summary>
    /// 
    /// </summary>
    public class UserTableConfiguration : BaseTableConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        public UserTableConfiguration() : base("Users")
        {
            Find = $"SELECT * FROM {Name} WHERE [Id] = @Id";
            Insert = $"INSERT INTO {Name} (Id, FirstName, lastName, Email, Password, CreatedAt, UpdatedAt, IsAdmin) VALUES (@Id, @FirstName, @LastName, @Email, @Password, @CreatedAt, @UpdatedAt, @IsAdmin)";
            Update = $"UPDATE {Name} SET [FirstName] = @FirstName, [LastName] = @LastName, [Email] = @Email, [Password] = @Password WHERE [Id] = @Id";
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Find { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override string Insert { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override string Update { get; set; }
    }
}
