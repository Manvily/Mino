namespace Mino.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendNotificationModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Notifications", "IsRead", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Notifications", "UserId");
            AddForeignKey("dbo.Notifications", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Notifications", new[] { "UserId" });
            DropColumn("dbo.Notifications", "IsRead");
            DropColumn("dbo.Notifications", "UserId");
        }
    }
}
