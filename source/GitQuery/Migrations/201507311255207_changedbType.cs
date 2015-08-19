namespace GitQuery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedbType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dbases", "dbType", c => c.String(nullable: false));
            DropColumn("dbo.Commits", "dbType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Commits", "dbType", c => c.String(nullable: false));
            DropColumn("dbo.Dbases", "dbType");
        }
    }
}
