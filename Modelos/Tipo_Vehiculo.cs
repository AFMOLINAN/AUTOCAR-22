using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;


namespace AUTOCAR.Modelos
{
    public class Tipo_Vehiculo : INotifyObject
    {
        public Tipo_Vehiculo()
        {
            oVehiculo = new ObservableCollection<Vehiculo>();
            
        }


        public override string ToString()
        {
            return Tipo + " " + Tipo_VehiculoID;
        }

        [Key]
        
        public int Tipo_VehiculoID { get { return tipo_vehiculoId; } set { if (tipo_vehiculoId != value) { tipo_vehiculoId = value; OnPropertyChanged(); } } }
        private int tipo_vehiculoId;

        [StringLength(20)]
        private string tipo;
        public string Tipo { get { return tipo; } set { if (tipo != value) { tipo = value; OnPropertyChanged(); } } }

        
        public virtual ObservableCollection<Vehiculo> oVehiculo { get { return ovehiculo; } set { ovehiculo = value; OnPropertyChanged(); } }
        private ObservableCollection<Vehiculo> ovehiculo;
    }
}
