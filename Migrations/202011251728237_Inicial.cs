namespace AUTOCAR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ciudad",
                c => new
                    {
                        CiudadID = c.Int(nullable: false, identity: true),
                        N_Municipio = c.String(),
                        DepartamentoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CiudadID)
                .ForeignKey("dbo.Departamento", t => t.DepartamentoID, cascadeDelete: true)
                .Index(t => t.DepartamentoID);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        Cedula = c.Int(nullable: false),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Sexo = c.String(),
                        Celular = c.Int(nullable: false),
                        Email = c.String(),
                        Direccion = c.String(),
                        CiudadID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteID)
                .ForeignKey("dbo.Ciudad", t => t.CiudadID, cascadeDelete: true)
                .Index(t => t.CiudadID);
            
            CreateTable(
                "dbo.Cobros",
                c => new
                    {
                        CobroID = c.Int(nullable: false, identity: true),
                        Fecha_Cobro = c.DateTime(nullable: false),
                        Total = c.String(),
                        Tipo_PagoID = c.Int(nullable: false),
                        ClienteID = c.Int(nullable: false),
                        VehiculoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CobroID)
                .ForeignKey("dbo.Cliente", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.Tipo_Pago", t => t.Tipo_PagoID, cascadeDelete: true)
                .ForeignKey("dbo.Vehiculo", t => t.VehiculoID, cascadeDelete: true)
                .Index(t => t.Tipo_PagoID)
                .Index(t => t.ClienteID)
                .Index(t => t.VehiculoID);
            
            CreateTable(
                "dbo.Tipo_Pago",
                c => new
                    {
                        Tipo_PagoID = c.Int(nullable: false, identity: true),
                        Metodo_Pago = c.String(),
                    })
                .PrimaryKey(t => t.Tipo_PagoID);
            
            CreateTable(
                "dbo.Pagos",
                c => new
                    {
                        PagoID = c.Int(nullable: false, identity: true),
                        Fecha_Pago = c.DateTime(nullable: false),
                        Valor_Compra = c.Int(nullable: false),
                        Iva = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProveedorID = c.Int(nullable: false),
                        VehiculoID = c.Int(nullable: false),
                        Tipo_PagoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PagoID)
                .ForeignKey("dbo.Proveedor", t => t.ProveedorID, cascadeDelete: true)
                .ForeignKey("dbo.Tipo_Pago", t => t.Tipo_PagoID, cascadeDelete: true)
                .ForeignKey("dbo.Vehiculo", t => t.VehiculoID, cascadeDelete: true)
                .Index(t => t.ProveedorID)
                .Index(t => t.VehiculoID)
                .Index(t => t.Tipo_PagoID);
            
            CreateTable(
                "dbo.Proveedor",
                c => new
                    {
                        ProveedorID = c.Int(nullable: false, identity: true),
                        Tipo_Proveedor = c.String(),
                        N_Identificacion = c.String(),
                        Nombre = c.String(),
                        Direccion = c.String(),
                        Telefono = c.String(),
                        CiudadID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProveedorID)
                .ForeignKey("dbo.Ciudad", t => t.CiudadID, cascadeDelete: true)
                .Index(t => t.CiudadID);
            
            CreateTable(
                "dbo.Vehiculo",
                c => new
                    {
                        VehiculoID = c.Int(nullable: false, identity: true),
                        Placa = c.String(),
                        Modelo = c.Int(nullable: false),
                        Cilindrada = c.Int(nullable: false),
                        HP = c.Int(nullable: false),
                        Precio_Nuevo = c.Int(nullable: false),
                        Precio_Mercado = c.Int(nullable: false),
                        Precio_Concesionario = c.Int(nullable: false),
                        ProveedorID = c.Int(nullable: false),
                        Tipo_VehiculoID = c.Int(nullable: false),
                        Estado_CompraID = c.Int(nullable: false),
                        EstadoID = c.Int(nullable: false),
                        MarcaID = c.Int(nullable: false),
                        CombustibleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehiculoID)
                .ForeignKey("dbo.Combustible", t => t.CombustibleID, cascadeDelete: true)
                .ForeignKey("dbo.Estado", t => t.EstadoID, cascadeDelete: true)
                .ForeignKey("dbo.Estado_Compra", t => t.Estado_CompraID, cascadeDelete: true)
                .ForeignKey("dbo.Marca", t => t.MarcaID, cascadeDelete: true)
                .ForeignKey("dbo.Proveedor", t => t.ProveedorID, cascadeDelete: false)
                .ForeignKey("dbo.Tipo_Vehiculo", t => t.Tipo_VehiculoID, cascadeDelete: true)
                .Index(t => t.ProveedorID)
                .Index(t => t.Tipo_VehiculoID)
                .Index(t => t.Estado_CompraID)
                .Index(t => t.EstadoID)
                .Index(t => t.MarcaID)
                .Index(t => t.CombustibleID);
            
            CreateTable(
                "dbo.Combustible",
                c => new
                    {
                        CombustibleID = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.CombustibleID);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        EstadoID = c.Int(nullable: false, identity: true),
                        Estado_Vehiculo = c.String(),
                    })
                .PrimaryKey(t => t.EstadoID);
            
            CreateTable(
                "dbo.Estado_Compra",
                c => new
                    {
                        Estado_CompraID = c.Int(nullable: false, identity: true),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.Estado_CompraID);
            
            CreateTable(
                "dbo.Marca",
                c => new
                    {
                        MarcaID = c.Int(nullable: false, identity: true),
                        N_Marca = c.String(),
                    })
                .PrimaryKey(t => t.MarcaID);
            
            CreateTable(
                "dbo.Tipo_Vehiculo",
                c => new
                    {
                        Tipo_VehiculoID = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.Tipo_VehiculoID);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        DepartamentoID = c.Int(nullable: false, identity: true),
                        N_Departamento = c.String(),
                    })
                .PrimaryKey(t => t.DepartamentoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ciudad", "DepartamentoID", "dbo.Departamento");
            DropForeignKey("dbo.Vehiculo", "Tipo_VehiculoID", "dbo.Tipo_Vehiculo");
            DropForeignKey("dbo.Vehiculo", "ProveedorID", "dbo.Proveedor");
            DropForeignKey("dbo.Pagos", "VehiculoID", "dbo.Vehiculo");
            DropForeignKey("dbo.Vehiculo", "MarcaID", "dbo.Marca");
            DropForeignKey("dbo.Vehiculo", "Estado_CompraID", "dbo.Estado_Compra");
            DropForeignKey("dbo.Vehiculo", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.Vehiculo", "CombustibleID", "dbo.Combustible");
            DropForeignKey("dbo.Cobros", "VehiculoID", "dbo.Vehiculo");
            DropForeignKey("dbo.Pagos", "Tipo_PagoID", "dbo.Tipo_Pago");
            DropForeignKey("dbo.Pagos", "ProveedorID", "dbo.Proveedor");
            DropForeignKey("dbo.Proveedor", "CiudadID", "dbo.Ciudad");
            DropForeignKey("dbo.Cobros", "Tipo_PagoID", "dbo.Tipo_Pago");
            DropForeignKey("dbo.Cobros", "ClienteID", "dbo.Cliente");
            DropForeignKey("dbo.Cliente", "CiudadID", "dbo.Ciudad");
            DropIndex("dbo.Vehiculo", new[] { "CombustibleID" });
            DropIndex("dbo.Vehiculo", new[] { "MarcaID" });
            DropIndex("dbo.Vehiculo", new[] { "EstadoID" });
            DropIndex("dbo.Vehiculo", new[] { "Estado_CompraID" });
            DropIndex("dbo.Vehiculo", new[] { "Tipo_VehiculoID" });
            DropIndex("dbo.Vehiculo", new[] { "ProveedorID" });
            DropIndex("dbo.Proveedor", new[] { "CiudadID" });
            DropIndex("dbo.Pagos", new[] { "Tipo_PagoID" });
            DropIndex("dbo.Pagos", new[] { "VehiculoID" });
            DropIndex("dbo.Pagos", new[] { "ProveedorID" });
            DropIndex("dbo.Cobros", new[] { "VehiculoID" });
            DropIndex("dbo.Cobros", new[] { "ClienteID" });
            DropIndex("dbo.Cobros", new[] { "Tipo_PagoID" });
            DropIndex("dbo.Cliente", new[] { "CiudadID" });
            DropIndex("dbo.Ciudad", new[] { "DepartamentoID" });
            DropTable("dbo.Departamento");
            DropTable("dbo.Tipo_Vehiculo");
            DropTable("dbo.Marca");
            DropTable("dbo.Estado_Compra");
            DropTable("dbo.Estado");
            DropTable("dbo.Combustible");
            DropTable("dbo.Vehiculo");
            DropTable("dbo.Proveedor");
            DropTable("dbo.Pagos");
            DropTable("dbo.Tipo_Pago");
            DropTable("dbo.Cobros");
            DropTable("dbo.Cliente");
            DropTable("dbo.Ciudad");
        }
    }
}
