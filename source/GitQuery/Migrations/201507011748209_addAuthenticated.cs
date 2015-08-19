namespace GitQuery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAuthenticated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dbases", "authenticated", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dbases", "authenticated");
        }
    }
}
