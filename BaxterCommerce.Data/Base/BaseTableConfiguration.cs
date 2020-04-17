using BaxterCommerce.CommonClasses;
using System;

namespace BaxterCommerce.Data.Base
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseTableConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public BaseTableConfiguration(string name)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        public abstract string Find { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public abstract string FindById { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public abstract string Insert { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public abstract string Update { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual string BuildWhereClause(string sql, BaseSearchParameters parameters)
        {
            sql += " WHERE ";

            if (!(string.IsNullOrWhiteSpace(parameters.Id)))
            {
                sql += "[Id] = @Id";
            }

            return sql;
        }
    }
}
