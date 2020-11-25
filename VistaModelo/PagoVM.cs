using AUTOCAR.Modelos;
using System;
using System.Collections.ObjectModel;
using AUTOCAR.Data;
using System.Windows;

namespace AUTOCAR.VistaModelo
{
    class PagoVM : INotifyObject
    {
        public RelayCommand cmd_Insertar { get; set; }
        public RelayCommand cmd_Consultar { get; set; }

        //public bool EsModifica { get; set; }

        public Pago Pago { get { return pago; } set { pago = value; OnPropertyChanged(); } }
        private Pago pago;

        public ObservableCollection<Pago> Lista { get { return lista; } set { lista = value; OnPropertyChanged(); } }
        private ObservableCollection<Pago> lista = new ObservableCollection<Pago>();

        public ObservableCollection<Proveedor> ListaP { get { return listaP; } set { listaP = value; OnPropertyChanged(); } }
        private ObservableCollection<Proveedor> listaP = new ObservableCollection<Proveedor>();

        public ObservableCollection<Vehiculo> ListaV { get { return listaV; } set { listaV = value; OnPropertyChanged(); } }
        private ObservableCollection<Vehiculo> listaV = new ObservableCollection<Vehiculo>();

        public ObservableCollection<Tipo_Pago> ListaT { get { return listaT; } set { listaT = value; OnPropertyChanged(); } }
        private ObservableCollection<Tipo_Pago> listaT = new ObservableCollection<Tipo_Pago>();

        public PagoVM()
        {
            this.cmd_Insertar = new RelayCommand(p => this.Insertar());
            this.cmd_Consultar = new RelayCommand(p => this.Consultar());
            this.Pago = new Pago();

            using (var dbc = new ConexionDbContext())
            {
                this.Lista = new ObservableCollection<Pago>(dbc.Pagos);
                this.ListaP = new ObservableCollection<Proveedor>(dbc.Proveedores);
                this.ListaV = new ObservableCollection<Vehiculo>(dbc.Vehiculos);
                this.ListaT = new ObservableCollection<Tipo_Pago>(dbc.Tipo_Pagos);
            }
            this.Pago.Fecha_Pago = DateTime.Now.Date;

        }

        public void Insertar()
        {
            using (var dbc = new ConexionDbContext())
            {
                if (this.Pago.Fecha_Pago == null)
                {
                    MessageBox.Show("No ingresó la fecha a insertar");
                    return;
                }
                dbc.Pagos.Add(this.Pago);
                try
                {
                    dbc.SaveChanges();
                    MessageBox.Show("Se guardo correctamente ");
                    this.Pago.Valor_Compra = 0;
                    this.Consultar();
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error " + er.Message);
                    if (er.InnerException != null)
                        MessageBox.Show("Error " + er.InnerException.Message);
                }
            }
        }

        public void Consultar()
        {
            using (var dbc = new ConexionDbContext())
            {
                this.Lista = new ObservableCollection<Pago>(dbc.Pagos);
                this.ListaP = new ObservableCollection<Proveedor>(dbc.Proveedores);
                this.ListaV = new ObservableCollection<Vehiculo>(dbc.Vehiculos);
                this.ListaT = new ObservableCollection<Tipo_Pago>(dbc.Tipo_Pagos);
            }
        }
    }
}
