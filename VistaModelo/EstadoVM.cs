using AUTOCAR.Data;
using AUTOCAR.Modelos;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
namespace AUTOCAR.VistaModelo
{
    class EstadoVM : INotifyObject
    {
        public RelayCommand cmd_Insertar { get; set; }
        public RelayCommand cmd_Consultar { get; set; }
        public RelayCommand cmd_Borrar { get; set; }
        public RelayCommand cmd_Modifica { get; set; }

        //public bool EsModifica { get; set; }

        public Estado Estado { get { return estado; } set { estado = value; OnPropertyChanged(); } }
        private Estado estado;

        public ObservableCollection<Estado> Lista { get { return lista; } set { lista = value; OnPropertyChanged(); } }
        private ObservableCollection<Estado> lista = new ObservableCollection<Estado>();

        public EstadoVM()
        {
            this.cmd_Insertar = new RelayCommand(p => this.Insertar());
            this.cmd_Consultar = new RelayCommand(p => this.Consultar());
            this.cmd_Borrar = new RelayCommand(p => this.Borrar());
            this.cmd_Modifica = new RelayCommand(p => this.Modifica());
            this.Estado = new Estado();
        }

        public void Insertar()
        {
            using (var dbc = new ConexionDbContext())
            {
                if (this.Estado.Estado_Vehiculo == null)
                {
                    MessageBox.Show("No digitó el estado del vehiculo a insertar");
                    return;
                }
                dbc.Estados.Add(this.Estado);
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
                this.Lista = new ObservableCollection<Estado>(dbc.Estados);

            }
        }

        public void Borrar()
        {
            if (this.Estado.Estado_Vehiculo == null)
            {
                MessageBox.Show("No digitó el estado del vehiculo a borrar");
                return;
            }

            using (var dbc = new ConexionDbContext())
            {
                try
                {
                    var borr = (from p in dbc.Estados
                                where p.Estado_Vehiculo == this.Estado.Estado_Vehiculo
                                select p).Single();
                    dbc.Estados.Remove(borr);
                    dbc.SaveChanges();
                    this.Lista = new ObservableCollection<Estado>(dbc.Estados);
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
            if (this.Estado.Estado_Vehiculo == null)
            {
                MessageBox.Show("No digitó el estado de vehiculo a modificar");
                return;
            }
            using (var dbc = new ConexionDbContext())
            {
                var Estado = dbc.Estados.Find(this.Estado.EstadoID);
                //dbc.Razas.Attach(raza);
                estado.Estado_Vehiculo = this.Estado.Estado_Vehiculo;

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
