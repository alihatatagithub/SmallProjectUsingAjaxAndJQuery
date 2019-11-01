namespace Day3_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namelength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "Name", c => c.String(nullable: false, maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "Name", c => c.String(nullable: false));
        }
    }
}
