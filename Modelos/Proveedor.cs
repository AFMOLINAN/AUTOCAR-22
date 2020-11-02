using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AUTOCAR.Modelos
{
    public class Proveedor : INotifyObject
    {
        public Proveedor()
        {
            oPago = new ObservableCollection<Pago>();

        }


        public override string ToString()
        {
            return Tipo_Proveedor + " " + ProvedorID;
        }

        [Key]
        private int proveedorId;
        public int ProvedorID { get { return proveedorId; } set { if (proveedorId != value) { proveedorId = value; OnPropertyChanged(); } } }

        [StringLength(30)]
        private string tipo_proveedor;
        public string Tipo_Proveedor { get { return tipo_proveedor; } set { if (tipo_proveedor != value) { tipo_proveedor = value; OnPropertyChanged(); } } }

        [StringLength(20)]
        private string n_identificacion;
        public string N_Identificacion { get { return n_identificacion; } set { if (n_identificacion != value) { n_identificacion = value; OnPropertyChanged(); } } }

        [StringLength(60)]
        private string nombre;
        public string Nombre { get { return nombre; } set { if (nombre != value) { nombre = value; OnPropertyChanged(); } } }

        [StringLength(60)]
        private string direccion;
        public string Direccion { get { return direccion; } set { if (direccion != value) { direccion = value; OnPropertyChanged(); } } }

        [StringLength(20)]
        private string telefono;
        public string Telefono { get { return telefono; } set { if (telefono != value) { telefono = value; OnPropertyChanged(); } } }


        //[ForeignKey("oCiudad")]
        public int CiudadID { get { return ciudadId; } set { if (ciudadId != value) { ciudadId = value; OnPropertyChanged(); } } }
        private int ciudadId;
        public virtual Ciudad oCiudad { get; set; }

        public virtual ObservableCollection<Pago> oPago { get { return opago; } set { opago = value; OnPropertyChanged(); } }
        private ObservableCollection<Pago> opago;
    }
}
