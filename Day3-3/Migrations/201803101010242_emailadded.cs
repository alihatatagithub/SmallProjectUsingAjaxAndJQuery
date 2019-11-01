namespace Day3_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "Email");
        }
    }
}
