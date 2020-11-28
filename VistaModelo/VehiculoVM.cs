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
        public RelayCommand cmd_Modifica { get; set; }
        public RelayCommand cmd_Consultar { get; set; }

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

        public ObservableCollection<Vehiculo> Lista { get { return lista; } set { lista = value; OnPropertyChanged(); } }
        private ObservableCollection<Vehiculo> lista = new ObservableCollection<Vehiculo>();

        public VehiculoVM()
        {
            this.cmd_Insertar = new RelayCommand(p => this.Insertar());
            this.cmd_Modifica = new RelayCommand(p => this.Modifica());
            this.cmd_Consultar = new RelayCommand(p => this.Consultar());
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
                this.Lista = new ObservableCollection<Vehiculo>(dbc.Vehiculos);

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
                    MessageBox.Show("Se guardo correctamente ");
                    this.Vehiculo.Placa = "";
                    this.Vehiculo.Cilindrada = 0;
                    this.Vehiculo.HP = 0;
                    this.Vehiculo.Precio_Nuevo = 0;
                    this.Vehiculo.Precio_Mercado = 0;
                    this.Vehiculo.Precio_Concesionario = 0;
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

        public void Modifica()
        {
            if (this.Vehiculo.Placa == null)
            {
                MessageBox.Show("Por favor seleccione un vehiculo ");
                return;
            }
            using (var dbc = new ConexionDbContext())
            {
                var vehiculo = dbc.Vehiculos.Find(this.Vehiculo.VehiculoID);
                vehiculo.VehiculoID = this.Vehiculo.VehiculoID;
                vehiculo.Placa = this.Vehiculo.Placa;
                vehiculo.Modelo = this.Vehiculo.Modelo;
                vehiculo.Cilindrada = this.Vehiculo.Cilindrada;
                vehiculo.HP = this.Vehiculo.HP;
                vehiculo.EstadoID = this.Vehiculo.EstadoID;
                vehiculo.Precio_Nuevo = this.Vehiculo.Precio_Nuevo;
                vehiculo.Precio_Mercado = this.Vehiculo.Precio_Mercado;
                vehiculo.Precio_Concesionario = this.Vehiculo.Precio_Concesionario;

                try
                {
                    dbc.SaveChanges();
                    MessageBox.Show("Se actualizo los registros ");
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
                this.Lista = new ObservableCollection<Vehiculo>(dbc.Vehiculos);
                

            }
        }
    }
}
