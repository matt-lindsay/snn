namespace snn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CaseTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CaseTypes",
                c => new
                    {
                        CaseTypeID = c.Int(nullable: false, identity: true),
                        TypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.CaseTypeID);
            
            AddColumn("dbo.Cases", "CaseTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Cases", "CaseTypeID");
            AddForeignKey("dbo.Cases", "CaseTypeID", "dbo.CaseTypes", "CaseTypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cases", "CaseTypeID", "dbo.CaseTypes");
            DropIndex("dbo.Cases", new[] { "CaseTypeID" });
            DropColumn("dbo.Cases", "CaseTypeID");
            DropTable("dbo.CaseTypes");
        }
    }
}
