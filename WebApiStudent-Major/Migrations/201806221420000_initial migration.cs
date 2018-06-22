namespace WebApiStudent_Major.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Majors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        MinSat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SAT = c.Int(nullable: false),
                        MajorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Majors", t => t.MajorId, cascadeDelete: true)
                .Index(t => t.MajorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "MajorId", "dbo.Majors");
            DropIndex("dbo.Students", new[] { "MajorId" });
            DropTable("dbo.Students");
            DropTable("dbo.Majors");
        }
    }
}
