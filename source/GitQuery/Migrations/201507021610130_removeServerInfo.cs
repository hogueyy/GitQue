namespace GitQuery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeServerInfo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Commits", "database");
            DropColumn("dbo.Commits", "server");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Commits", "server", c => c.String(nullable: false));
            AddColumn("dbo.Commits", "database", c => c.String(nullable: false));
        }
    }
}
