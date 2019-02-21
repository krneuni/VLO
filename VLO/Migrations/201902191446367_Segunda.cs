namespace VLO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Segunda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HExtras", "TotalSalario", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HExtras", "TotalSalario");
        }
    }
}
