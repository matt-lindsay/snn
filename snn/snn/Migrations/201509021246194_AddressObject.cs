namespace snn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressObject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        SaonNum = c.String(),
                        SaonTxt = c.String(),
                        PaonNum = c.String(),
                        PaonTxt = c.String(),
                        StreetName = c.String(),
                        Locality = c.String(),
                        PostTown = c.String(),
                        County = c.String(),
                        PostCode = c.String(),
                        Uprn = c.String(),
                    })
                .PrimaryKey(t => t.AddressID);
            
            AddColumn("dbo.Cases", "AddressID", c => c.Int(nullable: false));
            CreateIndex("dbo.Cases", "AddressID");
            AddForeignKey("dbo.Cases", "AddressID", "dbo.Addresses", "AddressID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cases", "AddressID", "dbo.Addresses");
            DropIndex("dbo.Cases", new[] { "AddressID" });
            DropColumn("dbo.Cases", "AddressID");
            DropTable("dbo.Addresses");
        }
    }
}
