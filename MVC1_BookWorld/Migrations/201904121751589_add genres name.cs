namespace MVC1_BookWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addgenresname : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id,Name) VALUES(1,'Romance')");
            Sql("INSERT INTO Genres(Id,Name) VALUES(2,'Fantasy')");
            Sql("INSERT INTO Genres(Id,Name) VALUES(3,'Science Fiction')");
            Sql("INSERT INTO Genres(Id,Name) VALUES(4,'Mystery')");
            Sql("INSERT INTO Genres(Id,Name) VALUES(5,'Thriller')");
        }
        
        public override void Down()
        {
        }
    }
}
