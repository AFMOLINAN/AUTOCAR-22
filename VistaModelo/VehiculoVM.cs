using AUTOCAR.Data;
using AUTOCAR.Modelos;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace AUTOCAR.VistaModelo
{
    class VehiculoVM : INotifyObject
    {
        public RelayCommand cmd_Insertar { get; set; }

        public Vehiculo Vehiculo { get { return vehiculo; } set { vehiculo = value; OnPropertyChanged(); } }
        private Vehiculo vehiculo;

        public ObservableCollection<Ciudad> ListaC { get { return listaC; } set { listaC = value; OnPropertyChanged(); } }
        private ObservableCollection<Ciudad> listaC = new ObservableCollection<Ciudad>();

        public ObservableCollection<Proveedor> ListaP { get { return listaP; } set { listaP = value; OnPropertyChanged(); } }
        private ObservableCollection<Proveedor> listaP = new ObservableCollection<Proveedor>();

        public ObservableCollection<Tipo_Vehiculo> ListaT { get { return listaT; } set { listaT = value; OnPropertyChanged(); } }
        private ObservableCollection<Tipo_Vehiculo> listaT = new ObservableCollection<Tipo_Vehiculo>();

        public ObservableCollection<Estado_Compra> ListaEC { get { return listaEC; } set { listaEC = value; OnPropertyChanged(); } }
        private ObservableCollection<Estado_Compra> listaEC = new ObservableCollection<Estado_Compra>();

        public ObservableCollection<Estado> ListaE { get { return listaE; } set { listaE = value; OnPropertyChanged(); } }
        private ObservableCollection<Estado> listaE = new ObservableCollection<Estado>();

        public ObservableCollection<Marca> ListaM { get { return listaM; } set { listaM = value; OnPropertyChanged(); } }
        private ObservableCollection<Marca> listaM = new ObservableCollection<Marca>();

        public ObservableCollection<Combustible> ListaCB { get { return listaCB; } set { listaCB = value; OnPropertyChanged(); } }
        private ObservableCollection<Combustible> listaCB = new ObservableCollection<Combustible>();

        public VehiculoVM()
        {
            this.cmd_Insertar = new RelayCommand(p => this.Insertar());
            this.Vehiculo = new Vehiculo();

            using (var dbc = new ConexionDbContext())
            {
                
                this.ListaC = new ObservableCollection<Ciudad>(dbc.Ciudades);
                this.ListaP = new ObservableCollection<Proveedor>(dbc.Proveedores);
                this.ListaT = new ObservableCollection<Tipo_Vehiculo>(dbc.Tipo_Vehiculos);
                this.ListaEC = new ObservableCollection<Estado_Compra>(dbc.Estado_Compras);
                this.ListaE = new ObservableCollection<Estado>(dbc.Estados);
                this.ListaM = new ObservableCollection<Marca>(dbc.Marcas);
                this.ListaCB = new ObservableCollection<Combustible>(dbc.Combustibles);

            }

        }
                
        public void Insertar()
        {
            using (var dbc = new ConexionDbContext())
            {
                if (this.Vehiculo.Placa == null)
                {
                    MessageBox.Show("No digitó la placa del vehiculo");
                    return;
                }
                dbc.Vehiculos.Add(this.Vehiculo);
                try
                {
                    dbc.SaveChanges();
                    
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error " + er.Message);
                    if (er.InnerException != null)
                        MessageBox.Show("Error " + er.InnerException.Message);
                }
            }
        }
    }
}
