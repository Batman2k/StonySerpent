namespace StonySerpent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCustomerInformation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        SocialSecurityNumber = c.String(),
                        StreetAddress = c.String(),
                        ZipCode = c.String(),
                        City = c.String(),
                        PhoneHomeNumber = c.String(),
                        PhoneCellNumber = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerInformations", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.CustomerInformations", new[] { "UserId" });
            DropTable("dbo.CustomerInformations");
        }
    }
}
