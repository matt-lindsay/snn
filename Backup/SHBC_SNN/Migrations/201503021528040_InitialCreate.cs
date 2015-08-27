namespace SHBC_SNN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SnnCases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CaseNo = c.String(),
                        Address = c.String(),
                        Uprn = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SnnContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        CaseId = c.Int(nullable: false),
                        SnnCase_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SnnCases", t => t.SnnCase_Id)
                .Index(t => t.SnnCase_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.SnnContacts", new[] { "SnnCase_Id" });
            DropForeignKey("dbo.SnnContacts", "SnnCase_Id", "dbo.SnnCases");
            DropTable("dbo.SnnContacts");
            DropTable("dbo.SnnCases");
        }
    }
}
