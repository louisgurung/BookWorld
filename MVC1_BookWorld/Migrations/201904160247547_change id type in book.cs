namespace MVC1_BookWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeidtypeinbook : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Books", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "ID", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Books", "ID");
        }
    }
}
