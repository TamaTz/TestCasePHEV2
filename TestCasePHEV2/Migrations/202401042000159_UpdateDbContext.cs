namespace TestCasePHEV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDbContext : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.user", "password", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.user", "password", c => c.String(maxLength: 50));
        }
    }
}
