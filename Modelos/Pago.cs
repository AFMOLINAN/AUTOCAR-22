using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AUTOCAR.Modelos
{
    public class Pago : INotifyObject
    {

        public override string ToString()
        {
            return Fecha_Pago + " " + PagoID;
        }

        [Key]
        private int pagoId;
        public int PagoID { get { return pagoId; } set { if (pagoId != value) { pagoId = value; OnPropertyChanged(); } } }
        
        private DateTime fecha_pago;
        public DateTime Fecha_Pago { get { return fecha_pago; } set { if (fecha_pago != value) { fecha_pago = value; OnPropertyChanged(); } } }

        [StringLength(50)]
        private int valor_compra;
        public int Valor_Compra { get { return valor_compra; } set { if (valor_compra != value) { valor_compra = value; OnPropertyChanged(); } } }

        
        private decimal iva;
        public decimal Iva { get { return iva; } set { if (iva != value) { iva = value; OnPropertyChanged(); } } }

        
        private decimal total;
        public decimal Total { get { return total; } set { if (total != value) { total = value; OnPropertyChanged(); } } }

        //[ForeignKey("oProveedor")]
        public int ProveedorID { get { return proveedorId; } set { if (proveedorId != value) { proveedorId = value; OnPropertyChanged(); } } }
        private int proveedorId;
        public virtual Proveedor oProveedor { get; set; }

        //[ForeignKey("oVehiculo")]
        public int VehiculoID { get { return vehiculoId; } set { if (vehiculoId != value) { vehiculoId = value; OnPropertyChanged(); } } }
        private int vehiculoId;
        public virtual Vehiculo oVehiculo { get; set; }

        //[ForeignKey("oTipo_Pago")]
        public int Tipo_PagoID { get { return tipo_pagoId; } set { if (tipo_pagoId != value) { tipo_pagoId = value; OnPropertyChanged(); } } }
        private int tipo_pagoId;
        public virtual Tipo_Pago oTipo_Pago { get; set; }
    }
}
