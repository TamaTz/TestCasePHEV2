namespace TestCasePHEV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.approvel",
                c => new
                    {
                        guid = c.String(nullable: false, maxLength: 36),
                        company_guid = c.String(maxLength: 36),
                    })
                .PrimaryKey(t => t.guid);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        guid = c.String(nullable: false, maxLength: 36),
                        name = c.String(maxLength: 50),
                        email = c.String(maxLength: 50),
                        phone_number = c.String(maxLength: 13),
                        company_photo = c.Binary(maxLength: 8000),
                        is_approve = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.guid);
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        guid = c.String(nullable: false, maxLength: 36),
                        username = c.String(maxLength: 50),
                        password = c.String(maxLength: 50),
                        company_guid = c.String(maxLength: 36),
                        role_guid = c.String(maxLength: 36),
                    })
                .PrimaryKey(t => t.guid);
            
            CreateTable(
                "dbo.role",
                c => new
                    {
                        guid = c.String(nullable: false, maxLength: 36),
                        name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.guid);
            
            CreateTable(
                "dbo.vendor",
                c => new
                    {
                        guid = c.String(nullable: false, maxLength: 36),
                        business_field = c.String(maxLength: 50),
                        company_type = c.String(maxLength: 50),
                        company_guid = c.String(maxLength: 36),
                    })
                .PrimaryKey(t => t.guid);
            
            CreateTable(
                "dbo.CompanyApprovels",
                c => new
                    {
                        Company_Guid = c.String(nullable: false, maxLength: 36),
                        Approvel_Guid = c.String(nullable: false, maxLength: 36),
                    })
                .PrimaryKey(t => new { t.Company_Guid, t.Approvel_Guid })
                .ForeignKey("dbo.Company", t => t.Company_Guid, cascadeDelete: true)
                .ForeignKey("dbo.approvel", t => t.Approvel_Guid, cascadeDelete: true)
                .Index(t => t.Company_Guid)
                .Index(t => t.Approvel_Guid);
            
            CreateTable(
                "dbo.UserCompanies",
                c => new
                    {
                        User_Guid = c.String(nullable: false, maxLength: 36),
                        Company_Guid = c.String(nullable: false, maxLength: 36),
                    })
                .PrimaryKey(t => new { t.User_Guid, t.Company_Guid })
                .ForeignKey("dbo.user", t => t.User_Guid, cascadeDelete: true)
                .ForeignKey("dbo.Company", t => t.Company_Guid, cascadeDelete: true)
                .Index(t => t.User_Guid)
                .Index(t => t.Company_Guid);
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_Guid = c.String(nullable: false, maxLength: 36),
                        User_Guid = c.String(nullable: false, maxLength: 36),
                    })
                .PrimaryKey(t => new { t.Role_Guid, t.User_Guid })
                .ForeignKey("dbo.role", t => t.Role_Guid, cascadeDelete: true)
                .ForeignKey("dbo.user", t => t.User_Guid, cascadeDelete: true)
                .Index(t => t.Role_Guid)
                .Index(t => t.User_Guid);
            
            CreateTable(
                "dbo.CompanyVendors",
                c => new
                    {
                        Company_Guid = c.String(nullable: false, maxLength: 36),
                        Vendor_Guid = c.String(nullable: false, maxLength: 36),
                    })
                .PrimaryKey(t => new { t.Company_Guid, t.Vendor_Guid })
                .ForeignKey("dbo.Company", t => t.Company_Guid, cascadeDelete: true)
                .ForeignKey("dbo.vendor", t => t.Vendor_Guid, cascadeDelete: true)
                .Index(t => t.Company_Guid)
                .Index(t => t.Vendor_Guid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyVendors", "Vendor_Guid", "dbo.vendor");
            DropForeignKey("dbo.CompanyVendors", "Company_Guid", "dbo.Company");
            DropForeignKey("dbo.RoleUsers", "User_Guid", "dbo.user");
            DropForeignKey("dbo.RoleUsers", "Role_Guid", "dbo.role");
            DropForeignKey("dbo.UserCompanies", "Company_Guid", "dbo.Company");
            DropForeignKey("dbo.UserCompanies", "User_Guid", "dbo.user");
            DropForeignKey("dbo.CompanyApprovels", "Approvel_Guid", "dbo.approvel");
            DropForeignKey("dbo.CompanyApprovels", "Company_Guid", "dbo.Company");
            DropIndex("dbo.CompanyVendors", new[] { "Vendor_Guid" });
            DropIndex("dbo.CompanyVendors", new[] { "Company_Guid" });
            DropIndex("dbo.RoleUsers", new[] { "User_Guid" });
            DropIndex("dbo.RoleUsers", new[] { "Role_Guid" });
            DropIndex("dbo.UserCompanies", new[] { "Company_Guid" });
            DropIndex("dbo.UserCompanies", new[] { "User_Guid" });
            DropIndex("dbo.CompanyApprovels", new[] { "Approvel_Guid" });
            DropIndex("dbo.CompanyApprovels", new[] { "Company_Guid" });
            DropTable("dbo.CompanyVendors");
            DropTable("dbo.RoleUsers");
            DropTable("dbo.UserCompanies");
            DropTable("dbo.CompanyApprovels");
            DropTable("dbo.vendor");
            DropTable("dbo.role");
            DropTable("dbo.user");
            DropTable("dbo.Company");
            DropTable("dbo.approvel");
        }
    }
}
