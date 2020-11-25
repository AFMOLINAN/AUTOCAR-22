namespace AUTOCAR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehiculo", "Foto", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehiculo", "Foto", c => c.Int(nullable: false));
        }
    }
}
