namespace Mino.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTagTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        UserId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UserTasks", "TagId");
            AddForeignKey("dbo.UserTasks", "TagId", "dbo.Tags", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTasks", "TagId", "dbo.Tags");
            DropIndex("dbo.UserTasks", new[] { "TagId" });
            DropTable("dbo.Tags");
        }
    }
}
