using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AUTOCAR.Modelos
{
    public class Estado : INotifyObject
    {
        public Estado()
        {
            oVehiculo = new ObservableCollection<Vehiculo>();

        }


        public override string ToString()
        {
            return Estado_Vehiculo + " " + EstadoID;
        }

        [Key]
        private int estadoId;
        public int EstadoID { get { return estadoId; } set { if (estadoId != value) { estadoId = value; OnPropertyChanged(); } } }

        [StringLength(20)]
        private string estado_vehiculo;
        public string Estado_Vehiculo { get { return estado_vehiculo; } set { if (estado_vehiculo != value) { estado_vehiculo = value; OnPropertyChanged(); } } }


        public virtual ObservableCollection<Vehiculo> oVehiculo { get { return ovehiculo; } set { ovehiculo = value; OnPropertyChanged(); } }
        private ObservableCollection<Vehiculo> ovehiculo;
    
    }
}
