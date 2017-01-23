namespace Mino.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Color = c.String(nullable: false),
                        UserId = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UserTasks", "ProjectId");
            AddForeignKey("dbo.UserTasks", "ProjectId", "dbo.Projects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTasks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.UserTasks", new[] { "ProjectId" });
            DropTable("dbo.Projects");
        }
    }
}
