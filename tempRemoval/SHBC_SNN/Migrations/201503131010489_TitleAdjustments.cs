namespace SHBC_SNN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TitleAdjustments : DbMigration
    {
        public override void Up()
        {
            AlterColumn("SnnContacts", "Title", c => c.Int(nullable: true, identity: false));
        }
        
        public override void Down()
        {
        }
    }
}
