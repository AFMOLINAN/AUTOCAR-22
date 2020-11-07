using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AUTOCAR.Modelos;

namespace AUTOCAR.Data
{
    public class ConexionDbContext : DbContext
    {
        public ConexionDbContext()
            : base("name=ConexionDbContext")
        { 
        }

        public virtual DbSet<Ciudad> Ciudades { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cobro> Cobros { get; set; }
        public virtual DbSet<Combustible> Combustibles { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Estado_Compra> Estado_Compras { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }
        public virtual DbSet<Tipo_Pago> Tipo_Pagos { get; set; }
        public virtual DbSet<Tipo_Vehiculo> Tipo_Vehiculos { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Aquí haremos nuestras configuraciones con Fluent API.

            // Especificar el nombre de una tabla.
            modelBuilder.Entity<Ciudad>().Map(m => m.ToTable("Ciudad"));
            modelBuilder.Entity<Cliente>().Map(m => m.ToTable("Cliente"));
            modelBuilder.Entity<Cobro>().Map(m => m.ToTable("Cobros"));
            modelBuilder.Entity<Combustible>().Map(m => m.ToTable("Combustible"));
            modelBuilder.Entity<Departamento>().Map(m => m.ToTable("Departamento"));
            modelBuilder.Entity<Estado>().Map(m => m.ToTable("Estado"));
            modelBuilder.Entity<Estado_Compra>().Map(m => m.ToTable("Estado_Compra"));
            modelBuilder.Entity<Marca>().Map(m => m.ToTable("Marca"));
            modelBuilder.Entity<Pago>().Map(m => m.ToTable("Pagos"));
            modelBuilder.Entity<Proveedor>().Map(m => m.ToTable("Proveedor"));
            modelBuilder.Entity<Tipo_Pago>().Map(m => m.ToTable("Tipo_Pago"));
            modelBuilder.Entity<Tipo_Vehiculo>().Map(m => m.ToTable("Tipo_Vehiculo"));
            modelBuilder.Entity<Vehiculo>().Map(m => m.ToTable("Vehiculo"));


            /*
            // establecer una primary key.
            modelBuilder.Entity<Producto>().HasKey(c => c.Codigo);

            // Definir un campo como requerida.
            modelBuilder.Entity<Producto>().Property(c => c.Nombre).IsRequired();

            // Definir el nombre de un campo.
            modelBuilder.Entity<Producto>().Property(c => c.Nombre).HasColumnName("Nombre");

            // Definir el tipo de un campo.
            modelBuilder.Entity<Producto>().Property(c => c.Nombre).HasColumnType("varchar");

            // Definir el orden de un campo.
            modelBuilder.Entity<Producto>().Property(c => c.Nombre).HasColumnOrder(2);

            // Definir el máximo de caracteres permitidos para un campo.
            modelBuilder.Entity<Producto>().Property(c => c.Descripcion).HasMaxLength(100);

            // indicar que no se debe mapear una pripiedad a la base de datos.
            modelBuilder.Entity<Producto>().Ignore(c => c.CodigoIso);   */

            base.OnModelCreating(modelBuilder);
        }
    }
}
