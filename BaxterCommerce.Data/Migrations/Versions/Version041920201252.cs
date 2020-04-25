using FluentMigrator;

namespace BaxterCommerce.Data.Migrations.Versions
{
    /// <summary>
    /// Construct Users table
    /// </summary>
    [Migration(041920201252)]
    public class Version041920201252 : Migration
    {
        /// <summary>
        /// Creates Users table
        /// </summary>
        public override void Up()
        {
            Create.Table(SqlMetaData.UsersTable)
                .WithColumn("Id").AsString().NotNullable().PrimaryKey()
                .WithColumn("Password").AsString().NotNullable()
                .WithColumn("CreatedAt").AsDateTime().NotNullable()
                .WithColumn("UpdatedAt").AsDateTime().NotNullable()
                .WithColumn("FirstName").AsString().NotNullable()
                .WithColumn("LastName").AsString().NotNullable()
                .WithColumn("Address").AsString().NotNullable()
                .WithColumn("City").AsString().NotNullable()
                .WithColumn("State").AsFixedLengthString(2).NotNullable()
                .WithColumn("ZipCode").AsFixedLengthString(5).NotNullable()
                .WithColumn("PhoneNumber").AsString().NotNullable()
                .WithColumn("Email").AsString().NotNullable()
                .WithColumn("IsAdmin").AsBoolean().NotNullable();
        }

        /// <summary>
        /// Deletes Users table
        /// </summary>
        public override void Down()
        {
            Delete.Table(SqlMetaData.UsersTable);
        }
    }
}
