namespace snn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdiModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressChangeIntelligences",
                c => new
                    {
                        AddressChangeIntelligenceID = c.Int(nullable: false, identity: true),
                        AddressChangeIntelligenceDescription = c.String(),
                    })
                .PrimaryKey(t => t.AddressChangeIntelligenceID);
            
            AddColumn("dbo.Cases", "AddressChangeIntelligenceID", c => c.Int());
            CreateIndex("dbo.Cases", "AddressChangeIntelligenceID");
            AddForeignKey("dbo.Cases", "AddressChangeIntelligenceID", "dbo.AddressChangeIntelligences", "AddressChangeIntelligenceID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cases", "AddressChangeIntelligenceID", "dbo.AddressChangeIntelligences");
            DropIndex("dbo.Cases", new[] { "AddressChangeIntelligenceID" });
            DropColumn("dbo.Cases", "AddressChangeIntelligenceID");
            DropTable("dbo.AddressChangeIntelligences");
        }
    }
}
