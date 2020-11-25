namespace AUTOCAR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pagos", "Iva");
            DropColumn("dbo.Pagos", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pagos", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Pagos", "Iva", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
