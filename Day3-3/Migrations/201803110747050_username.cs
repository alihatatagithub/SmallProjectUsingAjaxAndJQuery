namespace Day3_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class username : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "UserName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "UserName");
        }
    }
}
