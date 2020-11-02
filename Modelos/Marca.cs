using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AUTOCAR.Modelos
{
    public class Marca : INotifyObject
    {
        public Marca()
        {
            oVehiculo = new ObservableCollection<Vehiculo>();

        }


        public override string ToString()
        {
            return N_Marca + " " + MarcaID;
        }

        [Key]
        private int marcaId;
        public int MarcaID { get { return marcaId; } set { if (marcaId != value) { marcaId = value; OnPropertyChanged(); } } }

        [StringLength(20)]
        private string n_marca;
        public string N_Marca { get { return n_marca; } set { if (n_marca != value) { n_marca = value; OnPropertyChanged(); } } }


        public virtual ObservableCollection<Vehiculo> oVehiculo { get { return ovehiculo; } set { ovehiculo = value; OnPropertyChanged(); } }
        private ObservableCollection<Vehiculo> ovehiculo;
    
    }
}
