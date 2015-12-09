namespace snn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CaseDetailsFieldAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "Details", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cases", "Details");
        }
    }
}
