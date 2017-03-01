namespace Mino.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddHasNotificationColumnInTask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "HasNotification", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Tasks", "HasNotification");
        }
    }
}
