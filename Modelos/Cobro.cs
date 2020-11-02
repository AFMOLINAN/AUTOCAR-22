using System;
using System.ComponentModel.DataAnnotations;

namespace AUTOCAR.Modelos
{
    public class Cobro : INotifyObject
    {

        [Key]
        private int cobroId;
        public int CobroID { get { return cobroId; } set { if (cobroId != value) { cobroId = value; OnPropertyChanged(); } } }

        [StringLength(30)]
        private DateTime fecha_cobro;
        public DateTime Fecha_Cobro { get { return fecha_cobro; } set { if (fecha_cobro != value) { fecha_cobro = value; OnPropertyChanged(); } } }

        [StringLength(20)]
        private string total;
        public string Total { get { return total; } set { if (total != value) { total = value; OnPropertyChanged(); } } }


        //[ForeignKey("oTipo_Pago")]
        public int Tipo_PagoID { get { return tipo_pagoId; } set { if (tipo_pagoId != value) { tipo_pagoId = value; OnPropertyChanged(); } } }
        private int tipo_pagoId;
        public virtual Tipo_Pago oTipo_Pago { get; set; }

        //[ForeignKey("oCliente")]
        public int ClienteID { get { return clienteId; } set { if (clienteId != value) { clienteId = value; OnPropertyChanged(); } } }
        private int clienteId;
        public virtual Cliente oCliente { get; set; }

        //[ForeignKey("oVehiculo")]
        public int VehiculoID { get { return vehiculoId; } set { if (vehiculoId != value) { vehiculoId = value; OnPropertyChanged(); } } }
        private int vehiculoId;
        public virtual Vehiculo oVehiculo { get; set; }
    }
}
