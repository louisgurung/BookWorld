namespace MVC1_BookWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedgenredateaddednumberinstock : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Books");
            AddColumn("dbo.Books", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "NumberInStock", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "ID", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Books", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "ID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Books", "NumberInStock");
            DropColumn("dbo.Books", "DateAdded");
            AddPrimaryKey("dbo.Books", "ID");
        }
    }
}
