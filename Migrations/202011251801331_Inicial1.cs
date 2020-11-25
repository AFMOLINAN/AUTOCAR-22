namespace AUTOCAR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehiculo", "Foto", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehiculo", "Foto");
        }
    }
}
