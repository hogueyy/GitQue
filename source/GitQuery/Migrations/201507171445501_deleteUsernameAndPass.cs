namespace GitQuery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteUsernameAndPass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Commits", "uid");
            DropColumn("dbo.Commits", "password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Commits", "password", c => c.String(nullable: false));
            AddColumn("dbo.Commits", "uid", c => c.String(nullable: false));
        }
    }
}
