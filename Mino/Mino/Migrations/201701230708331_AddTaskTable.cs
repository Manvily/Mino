namespace Mino.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTaskTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        DateTime = c.DateTime(),
                        TagId = c.Int(),
                        ProjectId = c.Int(),
                        UserId = c.String(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserTasks");
        }
    }
}
