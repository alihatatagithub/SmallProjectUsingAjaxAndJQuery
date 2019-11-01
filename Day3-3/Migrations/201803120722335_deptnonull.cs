namespace Day3_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deptnonull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Student", "DeptNo", "dbo.Department");
            DropIndex("dbo.Student", new[] { "DeptNo" });
            AlterColumn("dbo.Student", "DeptNo", c => c.Int());
            CreateIndex("dbo.Student", "DeptNo");
            AddForeignKey("dbo.Student", "DeptNo", "dbo.Department", "DeptNo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "DeptNo", "dbo.Department");
            DropIndex("dbo.Student", new[] { "DeptNo" });
            AlterColumn("dbo.Student", "DeptNo", c => c.Int(nullable: false));
            CreateIndex("dbo.Student", "DeptNo");
            AddForeignKey("dbo.Student", "DeptNo", "dbo.Department", "DeptNo", cascadeDelete: true);
        }
    }
}
