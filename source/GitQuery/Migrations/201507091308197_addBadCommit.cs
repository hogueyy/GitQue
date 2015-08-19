namespace GitQuery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBadCommit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dbases", "badCommit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dbases", "badCommit");
        }
    }
}
