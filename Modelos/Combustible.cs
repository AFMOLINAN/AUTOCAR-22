using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AUTOCAR.Modelos
{
    public class Combustible : INotifyObject
    {
        public Combustible()
        {
            oVehiculo = new ObservableCollection<Vehiculo>();

        }
        public override string ToString()
        {
            return Tipo + " " + CombustibleID;
        }

        [Key]
        
        public int CombustibleID { get { return combustibleId; } set { if (combustibleId != value) { combustibleId = value; OnPropertyChanged(); } } }
        private int combustibleId;

        [StringLength(20)]
        private string tipo;
        public string Tipo { get { return tipo; } set { if (tipo != value) { tipo = value; OnPropertyChanged(); } } }


        public virtual ObservableCollection<Vehiculo> oVehiculo { get { return ovehiculo; } set { ovehiculo = value; OnPropertyChanged(); } }
        private ObservableCollection<Vehiculo> ovehiculo;
    
    }
}
