using eCommerceReplacementProject.CommonClasses;
using eCommerceReplacementProject.CommonClasses.Users;
using eCommerceReplacementProject.Data.Base;
using System;

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
            Find = $"SELECT * FROM {Name}";
            FindById = $"SELECT * FROM {Name} WHERE [Id] = @Id";
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

        /// <summary>
        /// 
        /// </summary>
        public override string FindById { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override string BuildWhereClause(string sql, BaseSearchParameters parameters)
        {
            sql = base.BuildWhereClause(sql, parameters);

            if (!(parameters is UserSearchParameters userSearchParameters)) throw new ArgumentException("Invalid parameter search type");

            int paramCount = 0;

            if (!(string.IsNullOrWhiteSpace(userSearchParameters.Id)))
            {
                paramCount++;
            }

            if (!(string.IsNullOrWhiteSpace(userSearchParameters.Email)))
            {
                if (paramCount > 0) sql += " AND ";
               
                paramCount++;

                sql += "[Email] = @Email";
            }

            return sql;
        }
    }
}
