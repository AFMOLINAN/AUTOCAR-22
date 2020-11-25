using AUTOCAR.Modelos;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUTOCAR.Data;
using System.Windows;

namespace AUTOCAR.VistaModelo
{
    class ProveedorVM : INotifyObject
    {
        public RelayCommand cmd_Insertar { get; set; }
        public RelayCommand cmd_Consultar { get; set; }
        public RelayCommand cmd_Modifica { get; set; }

        //public bool EsModifica { get; set; }

        public Proveedor Proveedor { get { return proveedor; } set { proveedor = value; OnPropertyChanged(); } }
        private Proveedor proveedor;

        public ObservableCollection<Proveedor> Lista { get { return lista; } set { lista = value; OnPropertyChanged(); } }
        private ObservableCollection<Proveedor> lista = new ObservableCollection<Proveedor>();

        public ObservableCollection<Ciudad> ListaD { get { return listaD; } set { listaD = value; OnPropertyChanged(); } }
        private ObservableCollection<Ciudad> listaD = new ObservableCollection<Ciudad>();



        public ProveedorVM()
        {
            this.cmd_Insertar = new RelayCommand(p => this.Insertar());
            this.cmd_Consultar = new RelayCommand(p => this.Consultar());
            this.cmd_Modifica = new RelayCommand(p => this.Modifica());
            this.Proveedor = new Proveedor();

            using (var dbc = new ConexionDbContext())
            {
                this.Lista = new ObservableCollection<Proveedor>(dbc.Proveedores);
                this.ListaD = new ObservableCollection<Ciudad>(dbc.Ciudades);
            }

        }

        public void Insertar()
        {
            using (var dbc = new ConexionDbContext())
            {
                if (this.Proveedor.Nombre == null)
                {
                    MessageBox.Show("No digitó el nombre del proveedor a insertar");
                    return;
                }
                dbc.Proveedores.Add(this.Proveedor);
                try
                {
                    dbc.SaveChanges();
                    MessageBox.Show("Se guardo correctamente ");
                    this.Proveedor.Tipo_Proveedor = "";
                    this.Proveedor.N_Identificacion = "";
                    this.Proveedor.Nombre = "";
                    this.Proveedor.Direccion = "";
                    this.Proveedor.Telefono = "";
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
                this.Lista = new ObservableCollection<Proveedor>(dbc.Proveedores);
                this.ListaD = new ObservableCollection<Ciudad>(dbc.Ciudades);
            }
        }

 
        public void Modifica()
        {
            if (this.Proveedor.Nombre == null)
            {
                MessageBox.Show("No digitó el nombre del proveedor a modificar");
                return;
            }
            using (var dbc = new ConexionDbContext())
            {
                var proveedor = dbc.Proveedores.Find(this.Proveedor.ProveedorID);
                //dbc.Razas.Attach(raza);
                proveedor.Tipo_Proveedor = this.Proveedor.Tipo_Proveedor;
                proveedor.N_Identificacion = this.Proveedor.N_Identificacion;
                proveedor.Nombre = this.Proveedor.Nombre;
                proveedor.Direccion = this.Proveedor.Direccion;
                proveedor.Telefono = this.Proveedor.Telefono;
                proveedor.CiudadID = this.Proveedor.CiudadID;
                try
                {
                    dbc.SaveChanges();
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
    }
}
