using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AUTOCAR.Modelos
{
    public class Departamento : INotifyObject
    {
        public Departamento()
        {
            oCiudad = new ObservableCollection<Ciudad>();

        }


        public override string ToString()
        {
            return N_Departamento + " " + DepartamentoID;
        }

        [Key]
        private int departamentoId;
        public int DepartamentoID { get { return departamentoId; } set { if (departamentoId != value) { departamentoId = value; OnPropertyChanged(); } } }

        [StringLength(20)]
        private string n_departamento;
        public string N_Departamento { get { return n_departamento; } set { if (n_departamento != value) { n_departamento = value; OnPropertyChanged(); } } }


        public virtual ObservableCollection<Ciudad> oCiudad { get { return ociudad; } set { ociudad = value; OnPropertyChanged(); } }
        private ObservableCollection<Ciudad> ociudad;
    
    }
}
