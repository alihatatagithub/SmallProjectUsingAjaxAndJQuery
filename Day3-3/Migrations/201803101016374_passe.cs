namespace Day3_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Password", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "Password");
        }
    }
}
