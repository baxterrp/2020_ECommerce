using FluentMigrator;

namespace BaxterCommerce.Data.Migrations.Versions
{
    /// <summary>
    /// Adding product group table
    /// </summary>
    [Migration(042520201943)]
    public class Version042520201943 : Migration
    {
        /// <summary>
        /// Add ProductGroup table
        /// </summary>
        public override void Up()
        {
            Create.Table(SqlMetaData.ProductGroupsTable)
                .WithColumn("Id").AsString().NotNullable().PrimaryKey()
                .WithColumn("CreatedAt").AsDateTime().NotNullable()
                .WithColumn("UpdatedAt").AsDateTime().NotNullable()
                .WithColumn("Name").AsString().NotNullable();
        }

        /// <summary>
        /// Remove ProductGroup table
        /// </summary>
        public override void Down()
        {
            Delete.Table(SqlMetaData.ProductGroupsTable);
        }
    }
}
