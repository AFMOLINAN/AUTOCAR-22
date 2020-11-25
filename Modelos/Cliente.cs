
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;


namespace AUTOCAR.Modelos
{
    public class Cliente : INotifyObject
    {
        public Cliente()
        {
            oCobro = new ObservableCollection<Cobro>();

        }
        public override string ToString()
        {
            return Nombre + " " + ClienteID;
        }

        [Key]
        public int ClienteID { get { return clienteId; } set { if (clienteId != value) { clienteId = value; OnPropertyChanged(); } } }
        private int clienteId;

     
        private int cedula;
        public int Cedula { get { return cedula; } set { if (cedula != value) { cedula = value; OnPropertyChanged(); } } }

        [StringLength(45)]
        private string nombre;
        public string Nombre { get { return nombre; } set { if (nombre != value) { nombre = value; OnPropertyChanged(); } } }

        [StringLength(45)]
        private string apellido;
        public string Apellido { get { return apellido; } set { if (apellido != value) { apellido = value; OnPropertyChanged(); } } }

        [StringLength(10)]
        private string sexo;
        public string Sexo { get { return sexo; } set { if (sexo != value) { sexo = value; OnPropertyChanged(); } } }

        [StringLength(11)]
        private int celular;
        public int Celular { get { return celular; } set { if (celular != value) { celular = value; OnPropertyChanged(); } } }

        [StringLength(50)]
        private string email;
        public string Email { get { return email; } set { if (email != value) { email = value; OnPropertyChanged(); } } }


        [StringLength(50)]
        private string direccion;
        public string Direccion { get { return direccion; } set { if (direccion != value) { direccion = value; OnPropertyChanged(); } } }

        //[ForeignKey("oCiudad")]
        public int CiudadID { get { return ciudadId; } set { if (ciudadId != value) { ciudadId = value; OnPropertyChanged(); } } }
        private int ciudadId;
        public virtual Ciudad oCiudad { get; set; }


        public virtual ObservableCollection<Cobro> oCobro { get { return ocobro; } set { ocobro = value; OnPropertyChanged(); } }
        private ObservableCollection<Cobro> ocobro;

    }
}
