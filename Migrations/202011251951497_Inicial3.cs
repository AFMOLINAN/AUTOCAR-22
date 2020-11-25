namespace AUTOCAR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehiculo", "Foto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehiculo", "Foto", c => c.Byte(nullable: false));
        }
    }
}
