using BaxterCommerce.CommonClasses;
using BaxterCommerce.Data.Base;

namespace BaxterCommerce.Data.Products
{
    /// <summary>
    /// Table configuration for <see cref="ProductGroup"/>
    /// </summary>
    public class ProductGroupTableConfiguration : BaseTableConfiguration
    {
        public ProductGroupTableConfiguration() : base("ProductGroups")
        {
            Find = $"SELECT * FROM {Name}";
            Insert = $"INSERT INTO {Name} (Id, CreatedAt, UpdatedAt, Name) VALUES (@Id, @CreatedAt, @UpdatedAt, @Name)";
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
        /// No search parameters are needed at the moment
        /// </summary>
        public override string BuildWhereClause(string sql, BaseSearchParameters parameters) => sql;
    }
}
