namespace MVC1_BookWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seeding_CanManageBooks_Admin_CanManageCustomers_AdminAndStaff : DbMigration
    {
        public override void Up()
        {
            Sql(@"

                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'680794ef-94e2-4125-9554-64e11b26089d', N'admin@gmail.com', 0, N'AASWn9oKOxx/MT5G+HX1yR/Uif57BO6RUr5cwTW+sRvrmbeMAqTcv6cd+NW2cfIe5A==', N'e3ebc68f-b7b3-4065-9971-7bcaaa6f858c', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e6ebeb69-053b-4634-82c2-1a6045bfe65b', N'staff@gmail.com', 0, N'AN6cTqntEFWOfxJ8D2lS6XmNpKVOulB477SOUHXsqOcljFn6RAsVD8Qsey5U83w9BQ==', N'd0a148d1-139d-4fd1-9c8a-017fe4588b1b', NULL, 0, 0, NULL, 1, 0, N'staff@gmail.com')


                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ebb3a390-21c7-418b-8255-9e0a3a35e573', N'CanManageCustomers')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e6ebeb69-053b-4634-82c2-1a6045bfe65b', N'ebb3a390-21c7-418b-8255-9e0a3a35e573')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'680794ef-94e2-4125-9554-64e11b26089d', N'ebb3a390-21c7-418b-8255-9e0a3a35e573')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'00e9be83-87d7-4b8f-b959-d88bdcab6d2e', N'CanManageBooks')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'680794ef-94e2-4125-9554-64e11b26089d', N'00e9be83-87d7-4b8f-b959-d88bdcab6d2e')




        ");
        }
        
        public override void Down()
        {
        }
    }
}
