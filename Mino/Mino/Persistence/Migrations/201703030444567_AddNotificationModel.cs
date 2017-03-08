namespace Mino.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotificationModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Task_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.Task_Id, cascadeDelete: true)
                .Index(t => t.Task_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "Task_Id", "dbo.Tasks");
            DropIndex("dbo.Notifications", new[] { "Task_Id" });
            DropTable("dbo.Notifications");
        }
    }
}
