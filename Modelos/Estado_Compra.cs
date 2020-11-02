using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AUTOCAR.Modelos
{
    public class Estado_Compra : INotifyObject
    {
        public Estado_Compra()
        {
            oVehiculo = new ObservableCollection<Vehiculo>();

        }


        public override string ToString()
        {
            return Estado + " " + Estado_CompraID;
        }

        [Key]
        private int estado_compraId;
        public int Estado_CompraID { get { return estado_compraId; } set { if (estado_compraId != value) { estado_compraId = value; OnPropertyChanged(); } } }

        [StringLength(20)]
        private string estado;
        public string Estado { get { return estado; } set { if (estado != value) { estado = value; OnPropertyChanged(); } } }


        public virtual ObservableCollection<Vehiculo> oVehiculo { get { return ovehiculo; } set { ovehiculo = value; OnPropertyChanged(); } }
        private ObservableCollection<Vehiculo> ovehiculo;
    
    }
}
