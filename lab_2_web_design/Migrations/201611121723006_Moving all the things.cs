namespace lab_2_web_design.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movingallthethings : DbMigration
    {
        public override void Up()
        {

            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 32),
                        LastName = c.String(nullable: false, maxLength: 32),
                        EmailAdress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Yarns",
                c => new
                    {
                        YarnId = c.Int(nullable: false, identity: true),
                        ColorName = c.String(nullable: false),
                        BrandName = c.String(),
                        Skeins = c.Double(nullable: false),
                        YarnType = c.String(),
                    })
                .PrimaryKey(t => t.YarnId);

            

            
            CreateTable(
                "dbo.YarnUsers",
                c => new
                    {
                        Yarn_YarnId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Yarn_YarnId, t.User_UserId })
                .ForeignKey("dbo.Yarns", t => t.Yarn_YarnId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Yarn_YarnId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YarnUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.YarnUsers", "Yarn_YarnId", "dbo.Yarns");
            DropIndex("dbo.YarnUsers", new[] { "User_UserId" });
            DropIndex("dbo.YarnUsers", new[] { "Yarn_YarnId" });
            DropTable("dbo.YarnUsers");
            DropTable("dbo.Yarns");
            DropTable("dbo.Users");
        }
    }
}
