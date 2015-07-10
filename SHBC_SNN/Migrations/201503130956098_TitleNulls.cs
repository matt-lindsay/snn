namespace SHBC_SNN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TitleNulls : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("SnnContacts", "Title", c => c.String(nullable: true, maxLength: 4));
        }
        
        public override void Down()
        {
        }
    }
}
