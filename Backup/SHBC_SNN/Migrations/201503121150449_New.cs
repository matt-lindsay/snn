namespace SHBC_SNN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SnnContacts", "SnnContactMethodId");
            DropColumn("dbo.SnnContacts", "SnnContactTypeId");
        }
        
        public override void Down()
        {
           
        }
    }
}
