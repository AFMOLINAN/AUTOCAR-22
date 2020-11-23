using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace AUTOCAR.Modelos
{
    public class Vehiculo : INotifyObject
    {
        public Vehiculo()
        {
            oPago = new ObservableCollection<Pago>();
            oCobro = new ObservableCollection<Cobro>();
        }


        public override string ToString()
        {
            return Placa + " " + VehiculoID;
        }

        [Key]
        private int vehiculoId;
        public int VehiculoID { get { return vehiculoId; } set { if (vehiculoId != value) { vehiculoId = value; OnPropertyChanged(); } } }

        [StringLength(7)]
        private string placa;
        public string Placa { get { return placa; } set { if (placa != value) { placa = value; OnPropertyChanged(); } } }

        [StringLength(4)]
        private int modelo;
        public int Modelo { get { return modelo; } set { if (modelo != value) { modelo = value; OnPropertyChanged(); } } }

        [StringLength(5)]
        private int cilindrada;
        public int Cilindrada { get { return cilindrada; } set { if (cilindrada != value) { cilindrada = value; OnPropertyChanged(); } } }

        [StringLength(10)]
        private int hp;
        public int HP { get { return hp; } set { if (hp != value) { hp = value; OnPropertyChanged(); } } }

        [StringLength(60)]
        private int precio_nuevo;
        public int Precio_Nuevo { get { return precio_nuevo; } set { if (precio_nuevo != value) { precio_nuevo = value; OnPropertyChanged(); } } }

        [StringLength(60)]
        private int precio_mercado;
        public int Precio_Mercado { get { return precio_mercado; } set { if (precio_mercado != value) { precio_mercado = value; OnPropertyChanged(); } } }

        [StringLength(60)]
        private int precio_concesionario;
        public int Precio_Concesionario { get { return precio_concesionario; } set { if (precio_concesionario != value) { precio_concesionario = value; OnPropertyChanged(); } } }

        [StringLength(100)]
        private string foto;
        public string Foto { get { return foto; } set { if (foto != value) { foto = value; OnPropertyChanged(); } } }


        //[ForeignKey("oProveedor")]
        public int ProveedorID { get { return proveedorId; } set { if (proveedorId != value) { proveedorId = value; OnPropertyChanged(); } } }
        private int proveedorId;
        public virtual Proveedor oProveedor { get; set; }

        //[ForeignKey("oTipo_Vehiculo")]
        public int Tipo_VehiculoID { get { return tipo_vehiculoId; } set { if (tipo_vehiculoId != value) { tipo_vehiculoId = value; OnPropertyChanged(); } } }
        private int tipo_vehiculoId;
        public virtual Tipo_Vehiculo oTipo_Vehiculo { get; set; }

        //[ForeignKey("oEstado_Compra")]
        public int Estado_CompraID { get { return estado_compraId; } set { if (estado_compraId != value) { estado_compraId = value; OnPropertyChanged(); } } }
        private int estado_compraId;
        public virtual Estado_Compra oEstado_Compra { get; set; }

        //[ForeignKey("oEstado")]
        public int EstadoID { get { return estadoId; } set { if (estadoId != value) { estadoId = value; OnPropertyChanged(); } } }
        private int estadoId;
        public virtual Estado oEstado { get; set; }

        //[ForeignKey("oMarca")]
        public int MarcaID { get { return marcaId; } set { if (marcaId != value) { marcaId = value; OnPropertyChanged(); } } }
        private int marcaId;
        public virtual Marca oMarca { get; set; }

        //[ForeignKey("oCombustible")]
        public int CombustibleID { get { return combustibleId; } set { if (combustibleId != value) { combustibleId = value; OnPropertyChanged(); } } }
        private int combustibleId;
        public virtual Combustible oCombustible { get; set; }


        public virtual ObservableCollection<Pago> oPago { get { return opago; } set { opago = value; OnPropertyChanged(); } }
        private ObservableCollection<Pago> opago;

        public virtual ObservableCollection<Cobro> oCobro { get { return ocobro; } set { ocobro = value; OnPropertyChanged(); } }
        private ObservableCollection<Cobro> ocobro;

    }
}
