namespace VLO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tercera : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prestamos", "Cantidad", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prestamos", "Cantidad");
        }
    }
}
