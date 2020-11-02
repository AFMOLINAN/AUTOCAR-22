using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AUTOCAR.Modelos
{
    public class Ciudad : INotifyObject
    {
        public Ciudad()
        {
            oCliente = new ObservableCollection<Cliente>();
            oProveedor = new ObservableCollection<Proveedor>();
        }

        public override string ToString()
        {
            return N_Municipio + " " + CiudadID;
        }

        [Key]
        private int ciudadId;
        public int CiudadID { get { return ciudadId; } set { if (ciudadId != value) { ciudadId = value; OnPropertyChanged(); } } }

        [StringLength(60)]
        private string n_municipio;
        public string N_Municipio { get { return n_municipio; } set { if (n_municipio != value) { n_municipio = value; OnPropertyChanged(); } } }

        //[ForeignKey("oDepartamento")]
        public int DepartamentoID { get { return departamentoId; } set { if (departamentoId != value) { departamentoId = value; OnPropertyChanged(); } } }
        private int departamentoId;
        public virtual Departamento oDepartamento { get; set; }

        public virtual ObservableCollection<Cliente> oCliente { get { return ocliente; } set { ocliente = value; OnPropertyChanged(); } }
        private ObservableCollection<Cliente> ocliente;

        public virtual ObservableCollection<Proveedor> oProveedor { get { return oproveedor; } set { oproveedor = value; OnPropertyChanged(); } }
        private ObservableCollection<Proveedor> oproveedor;
    }
}
