namespace GitQuery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeCurrentDB3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "currentID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "currentID");
        }
    }
}
