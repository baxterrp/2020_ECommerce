using BaxterCommerce.CommonClasses;
using BaxterCommerce.CommonClasses.Users;
using BaxterCommerce.Data.Base;
using System;
using System.Text;

namespace BaxterCommerce.Data.Users
{
    /// <summary>
    /// Table configuration data on "Users" table
    /// </summary>
    public class UserTableConfiguration : BaseTableConfiguration
    {
        public UserTableConfiguration() : base("Users")
        {
            Find = $"SELECT * FROM {Name}";
            
            Insert = $"INSERT INTO {Name} (Id, FirstName, lastName, Email, Password, CreatedAt, UpdatedAt, IsAdmin, Address, City, State, ZipCode, PhoneNumber)" +
                " VALUES (@Id, @FirstName, @LastName, @Email, @Password, @CreatedAt, @UpdatedAt, @IsAdmin, @Address, @City, @State, @ZipCode, @PhoneNumber)";
        }

        /// <summary>
        /// override of <see cref="BaseTableConfiguration.Find"/>
        /// </summary>
        public override string Find { get; set; }

        /// <summary>
        /// override of <see cref="BaseTableConfiguration.Insert"/>
        /// </summary>
        public override string Insert { get; set; }

        /// <summary>
        /// override of <see cref="BaseTableConfiguration.Update"/>
        /// </summary>
        public override string Update { get; set; }

        /// <summary>
        /// override of <see cref="BaseTableConfiguration.BuildWhereClause(string, BaseSearchParameters)"/>
        /// </summary>
        /// <remarks>calls base method to get WHERE and optionally add <see cref="BaseResource.Id"/> as parameter
        /// also adds optional <see cref="UserResource.Email"/></remarks>
        public override string BuildWhereClause(string sql, BaseSearchParameters parameters)
        {
            if (!(parameters is UserSearchParameters userSearchParameters)) throw new ArgumentException("Invalid parameter search type");

            StringBuilder sb = new StringBuilder(sql);

            sb.Append(" WHERE ");

            if (!(string.IsNullOrWhiteSpace(userSearchParameters.Email)))
                sb.Append("[Email] = @Email");

            return sb.ToString();
        }
    }
}
