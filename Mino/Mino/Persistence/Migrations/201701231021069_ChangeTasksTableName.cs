namespace Mino.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTasksTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserTasks", newName: "Tasks");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Tasks", newName: "UserTasks");
        }
    }
}
