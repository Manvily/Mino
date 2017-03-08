namespace Mino.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendNotificationModel2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notifications", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Notifications", new[] { "UserId" });
            AlterColumn("dbo.Notifications", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Notifications", "UserId");
            AddForeignKey("dbo.Notifications", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Notifications", new[] { "UserId" });
            AlterColumn("dbo.Notifications", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Notifications", "UserId");
            AddForeignKey("dbo.Notifications", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
