namespace Mino.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriorioritiesInTask : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "Priority", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "Priority", c => c.Int());
        }
    }
}
