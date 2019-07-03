namespace MVC1_BookWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDbSetInIdentityModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        CustomerID = c.Byte(nullable: false),
                        BookID = c.Byte(nullable: false),
                        Book_ID = c.Int(),
                        Customer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Books", t => t.Book_ID)
                .ForeignKey("dbo.Customers", t => t.Customer_ID)
                .Index(t => t.Book_ID)
                .Index(t => t.Customer_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Customer_ID", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "Book_ID", "dbo.Books");
            DropIndex("dbo.Rentals", new[] { "Customer_ID" });
            DropIndex("dbo.Rentals", new[] { "Book_ID" });
            DropTable("dbo.Rentals");
        }
    }
}
