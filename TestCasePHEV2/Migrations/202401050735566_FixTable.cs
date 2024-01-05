namespace TestCasePHEV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.approvel", newName: "tr_approvel");
            RenameTable(name: "dbo.Company", newName: "tb_company");
            RenameTable(name: "dbo.user", newName: "tb_user");
            RenameTable(name: "dbo.role", newName: "tb_role");
            RenameTable(name: "dbo.vendor", newName: "tb_vendor");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.tb_vendor", newName: "vendor");
            RenameTable(name: "dbo.tb_role", newName: "role");
            RenameTable(name: "dbo.tb_user", newName: "user");
            RenameTable(name: "dbo.tb_company", newName: "Company");
            RenameTable(name: "dbo.tr_approvel", newName: "approvel");
        }
    }
}
