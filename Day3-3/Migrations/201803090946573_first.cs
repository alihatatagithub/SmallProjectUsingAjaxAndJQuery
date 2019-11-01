namespace Day3_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DeptNo = c.Int(nullable: false),
                        DeptName = c.String(),
                        MaxCapacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeptNo);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        DeptNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DeptNo, cascadeDelete: true)
                .Index(t => t.DeptNo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "DeptNo", "dbo.Department");
            DropIndex("dbo.Student", new[] { "DeptNo" });
            DropTable("dbo.Student");
            DropTable("dbo.Department");
        }
    }
}
