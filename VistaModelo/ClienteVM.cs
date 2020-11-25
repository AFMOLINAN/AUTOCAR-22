using AUTOCAR.Data;
using AUTOCAR.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AUTOCAR.VistaModelo
{
    class ClienteVM : INotifyObject
    {
        public RelayCommand cmd_Insertar { get; set; }
        public RelayCommand cmd_Consultar { get; set; }
        public RelayCommand cmd_Borrar { get; set; }
        public RelayCommand cmd_Modifica { get; set; }

        public Cliente Cliente { get { return cliente;  } set { cliente = value; OnPropertyChanged(); } }
        private Cliente cliente;

        public ObservableCollection<Cliente> Lista { get { return lista; } set { lista = value; OnPropertyChanged(); } }
        private ObservableCollection<Cliente> lista = new ObservableCollection<Cliente>();

        public ObservableCollection<Ciudad> ListaC { get { return listaC; } set { listaC = value; OnPropertyChanged(); } }
        private ObservableCollection<Ciudad> listaC = new ObservableCollection<Ciudad>();


        public ClienteVM()
        {
            this.cmd_Insertar = new RelayCommand(p => this.Insertar());
            this.cmd_Consultar = new RelayCommand(p => this.Consultar());
            this.cmd_Borrar = new RelayCommand(p => this.Borrar());
            this.cmd_Modifica = new RelayCommand(p => this.Modifica());
            this.Cliente = new Cliente();

            using (var dbc = new ConexionDbContext())
            {
                this.Lista = new ObservableCollection<Cliente>(dbc.Clientes);
                this.ListaC = new ObservableCollection<Ciudad>(dbc.Ciudades);

            }

           
        }


        public void Insertar()
        {
            using (var dbc = new ConexionDbContext())
            {

                if (this.Cliente.Nombre == null )
                {
                    MessageBox.Show("No digitó el nombre del Cliente a insertar");
                    return;
                }
                dbc.Clientes.Add(this.Cliente);
                try
                {
                    dbc.SaveChanges();
                    MessageBox.Show("Se agrego nuevo cliente");
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
                this.Lista = new ObservableCollection<Cliente>(dbc.Clientes);
                this.ListaC = new ObservableCollection<Ciudad>(dbc.Ciudades);
            }
        }



        public void Borrar()
        {
            if (this.Cliente.Nombre == null)
            {
                MessageBox.Show("No digitó el Cliente a borrar");
                return;
            }

            using (var dbc = new ConexionDbContext())
            {
                try
                {
                    var borr = (from p in dbc.Clientes
                                where p.Nombre == this.Cliente.Nombre
                                select p).Single();
                    dbc.Clientes.Remove(borr);
                    dbc.SaveChanges();
                    this.Lista = new ObservableCollection<Cliente>(dbc.Clientes);
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
            if (this.Cliente.Nombre == null)
            {
                MessageBox.Show("No digitó el nombre del Cliente a modificar");
                return;
            }
            using (var dbc = new ConexionDbContext())
            {
                var cliente = dbc.Clientes.Find(this.Cliente.ClienteID);
                
                cliente.ClienteID = this.Cliente.ClienteID;
                cliente.Nombre = this.Cliente.Nombre;
                cliente.Apellido = this.Cliente.Apellido;
                cliente.Sexo = this.Cliente.Sexo;
                cliente.Celular = this.Cliente.Celular;
                cliente.Email = this.Cliente.Email;
                cliente.Direccion = this.Cliente.Direccion;
                cliente.CiudadID = this.Cliente.CiudadID;
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
