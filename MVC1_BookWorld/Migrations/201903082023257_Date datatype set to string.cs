namespace MVC1_BookWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datedatatypesettostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "DateAdded", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "DateAdded", c => c.DateTime(nullable: false));
        }
    }
}
