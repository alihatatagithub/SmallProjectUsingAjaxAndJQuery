namespace Day3_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "BirthDate");
        }
    }
}
