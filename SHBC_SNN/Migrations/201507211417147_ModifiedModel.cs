namespace SHBC_SNN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SnnContacts", "ContMethod", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SnnContacts", "ContMethod");
        }
    }
}
