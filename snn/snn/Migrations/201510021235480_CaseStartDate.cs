namespace snn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CaseStartDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "StartDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cases", "StartDate");
        }
    }
}
