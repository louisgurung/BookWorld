namespace MVC1_BookWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNumberAvailable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "NumberAvailable", c => c.Byte(nullable: false));

            Sql("UPDATE Books SET NumberAvailable = NumberInStock");  //initializes number
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "NumberAvailable");
        }
    }
}
