namespace snn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstDataModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        CaseID = c.Int(nullable: false, identity: true),
                        CaseStatusID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CaseID)
                .ForeignKey("dbo.CaseStatus", t => t.CaseStatusID, cascadeDelete: true)
                .Index(t => t.CaseStatusID);
            
            CreateTable(
                "dbo.CaseStatus",
                c => new
                    {
                        CaseStatusID = c.Int(nullable: false, identity: true),
                        StatusDescription = c.String(),
                    })
                .PrimaryKey(t => t.CaseStatusID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cases", "CaseStatusID", "dbo.CaseStatus");
            DropIndex("dbo.Cases", new[] { "CaseStatusID" });
            DropTable("dbo.CaseStatus");
            DropTable("dbo.Cases");
        }
    }
}
