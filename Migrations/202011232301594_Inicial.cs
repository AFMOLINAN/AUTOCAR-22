namespace AUTOCAR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehiculo", "CiudadID", "dbo.Ciudad");
            DropIndex("dbo.Vehiculo", new[] { "CiudadID" });
            DropColumn("dbo.Vehiculo", "CiudadID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehiculo", "CiudadID", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehiculo", "CiudadID");
            AddForeignKey("dbo.Vehiculo", "CiudadID", "dbo.Ciudad", "CiudadID", cascadeDelete: true);
        }
    }
}
