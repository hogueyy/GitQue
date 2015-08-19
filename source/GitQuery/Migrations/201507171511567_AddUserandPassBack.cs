namespace GitQuery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserandPassBack : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Commits", "uid", c => c.String(nullable: false));
            AddColumn("dbo.Commits", "password", c => c.String(nullable: false));
            DropColumn("dbo.Commits", "filepath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Commits", "filepath", c => c.String());
            DropColumn("dbo.Commits", "password");
            DropColumn("dbo.Commits", "uid");
        }
    }
}
