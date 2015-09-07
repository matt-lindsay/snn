namespace snn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableCaseType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cases", "CaseTypeID", "dbo.CaseTypes");
            DropIndex("dbo.Cases", new[] { "CaseTypeID" });
            AlterColumn("dbo.Cases", "CaseTypeID", c => c.Int());
            CreateIndex("dbo.Cases", "CaseTypeID");
            AddForeignKey("dbo.Cases", "CaseTypeID", "dbo.CaseTypes", "CaseTypeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cases", "CaseTypeID", "dbo.CaseTypes");
            DropIndex("dbo.Cases", new[] { "CaseTypeID" });
            AlterColumn("dbo.Cases", "CaseTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Cases", "CaseTypeID");
            AddForeignKey("dbo.Cases", "CaseTypeID", "dbo.CaseTypes", "CaseTypeID", cascadeDelete: true);
        }
    }
}
