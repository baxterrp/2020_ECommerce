using BaxterCommerce.CommonClasses;
using System;
using System.Text;

namespace BaxterCommerce.Data.Base
{
    /// <summary>
    /// SQL Table information for a given resource
    /// </summary>
    public abstract class BaseTableConfiguration
    {
        public BaseTableConfiguration(string name)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        /// <summary>
        /// The name of the table
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Search query with optional WHERE clause
        /// </summary>
        public abstract string Find { get; set; }

        /// <summary>
        /// Search query based on primary identifier
        /// </summary>
        public abstract string FindById { get; set; }

        /// <summary>
        /// Insert statement 
        /// </summary>
        public abstract string Insert { get; set; }

        /// <summary>
        /// Update statement
        /// </summary>
        public abstract string Update { get; set; }

        /// <summary>
        /// Constructs WHERE clause in given sql statement based on provided <see cref="BaseSearchParameters"/>
        /// </summary>
        /// <param name="sql">The sql statement before appending WHERE clause</param>
        /// <param name="parameters"><see cref="BaseSearchParameters"/> to append to WHERE clause</param>
        /// <returns>Updated sql query with additional WHERE clause</returns>
        public virtual string BuildWhereClause(string sql, BaseSearchParameters parameters)
        {
            StringBuilder sb = new StringBuilder(sql);
            sb.Append(" WHERE ");

            if (!(string.IsNullOrWhiteSpace(parameters.Id)))
            {
               sb.Append("[Id] = @Id");
            }

            return sb.ToString();
        }
    }
}
