using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AUTOCAR.Modelos
{
    public class Tipo_Pago : INotifyObject
    {

        public Tipo_Pago()
        {
            oCobro = new ObservableCollection<Cobro>();
            oPago = new ObservableCollection<Pago>();

        }

        public override string ToString()
        {
            return Metodo_Pago + " " + Tipo_PagoID;
        }
        [Key]
        public int Tipo_PagoID { get { return tipo_pagoId; } set { if (tipo_pagoId != value) { tipo_pagoId = value; OnPropertyChanged(); } } }
        private int tipo_pagoId;

        [StringLength(30)]
        private string metodo_pago;
        public string Metodo_Pago { get { return metodo_pago; } set { if (metodo_pago != value) { metodo_pago = value; OnPropertyChanged(); } } }

        public virtual ObservableCollection<Cobro> oCobro { get { return ocobro; } set { ocobro = value; OnPropertyChanged(); } }
        private ObservableCollection<Cobro> ocobro;

        public virtual ObservableCollection<Pago> oPago { get { return opago; } set { opago = value; OnPropertyChanged(); } }
        private ObservableCollection<Pago> opago;
    }
}
