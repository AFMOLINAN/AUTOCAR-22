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
        public RelayCommand cmd_Borrar { get; set; }
        public RelayCommand cmd_Modifica { get; set; }

        //public bool EsModifica { get; set; }

        public Proveedor Proveedor { get { return proveedor; } set { proveedor = value; OnPropertyChanged(); } }
        private Proveedor proveedor;

        public ObservableCollection<Proveedor> Lista { get { return lista; } set { lista = value; OnPropertyChanged(); } }
        private ObservableCollection<Proveedor> lista = new ObservableCollection<Proveedor>();

        public ProveedorVM()
        {
            this.cmd_Insertar = new RelayCommand(p => this.Insertar());
            this.cmd_Consultar = new RelayCommand(p => this.Consultar());
            this.cmd_Borrar = new RelayCommand(p => this.Borrar());
            this.cmd_Modifica = new RelayCommand(p => this.Modifica());
            this.Proveedor = new Proveedor();
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
            }
        }

        public void Borrar()
        {
            if (this.Proveedor.Nombre == null)
            {
                MessageBox.Show("No digitó el proveedor a borrar");
                return;
            }

            using (var dbc = new ConexionDbContext())
            {
                try
                {
                    var borr = (from p in dbc.Proveedores
                                where p.Nombre == this.Proveedor.Nombre
                                select p).Single();
                    dbc.Proveedores.Remove(borr);
                    dbc.SaveChanges();
                    this.Lista = new ObservableCollection<Proveedor>(dbc.Proveedores);
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
            if (this.Proveedor.Nombre == null)
            {
                MessageBox.Show("No digitó el nombre del proveedor a modificar");
                return;
            }
            using (var dbc = new ConexionDbContext())
            {
                var proveedor = dbc.Proveedores.Find(this.Proveedor.ProvedorID);
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
