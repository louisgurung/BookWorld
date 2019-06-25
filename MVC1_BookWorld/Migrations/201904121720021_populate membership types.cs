namespace MVC1_BookWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatemembershiptypes : DbMigration
    {
        public override void Up() 
        {
            Sql("INSERT INTO MembershipTypes(Id,Name,SignUpFee,DurationInMonths,DiscountRate) VALUES(1,'Pay as you go',0,1,2)");
            Sql("INSERT INTO MembershipTypes(Id,Name,SignUpFee,DurationInMonths,DiscountRate) VALUES(2,'Weekly',3,4,5)");
            Sql("INSERT INTO MembershipTypes(Id,Name,SignUpFee,DurationInMonths,DiscountRate) VALUES(3,'Quarterly',6,7,8)");
            Sql("INSERT INTO MembershipTypes(Id,Name,SignUpFee,DurationInMonths,DiscountRate) VALUES(4,'Monthly',9,10,11)");
            Sql("INSERT INTO MembershipTypes(Id,Name,SignUpFee,DurationInMonths,DiscountRate) VALUES(5,'Yearly',12,13,14)");

        }
        
        public override void Down()
        {
        }
    }
}
