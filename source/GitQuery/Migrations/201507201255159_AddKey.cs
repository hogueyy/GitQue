namespace GitQuery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Commits", "key", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Commits", "key");
        }
    }
}
