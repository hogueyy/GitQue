namespace GitQuery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDbType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Commits", "dbType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Commits", "dbType");
        }
    }
}
