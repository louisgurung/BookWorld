namespace MVC1_BookWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDrivingLicenseToApplicationUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "DrivingLicense");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DrivingLicense", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
