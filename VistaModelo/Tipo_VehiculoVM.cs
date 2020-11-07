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
    class Tipo_VehiculoVM : INotifyObject
    {
        public RelayCommand cmd_Insertar { get; set; }
        public RelayCommand cmd_Consultar { get; set; }
        public RelayCommand cmd_Borrar { get; set; }
        public RelayCommand cmd_Modifica { get; set; }

        //public bool EsModifica { get; set; }

        public Tipo_Vehiculo Tipo_Vehiculo { get { return tipo_vehiculo; } set { tipo_vehiculo = value; OnPropertyChanged(); } }
        private Tipo_Vehiculo tipo_vehiculo;

        public ObservableCollection<Tipo_Vehiculo> Lista { get { return lista; } set { lista = value; OnPropertyChanged(); } }
        private ObservableCollection<Tipo_Vehiculo> lista = new ObservableCollection<Tipo_Vehiculo>();

        public Tipo_VehiculoVM()
        {
            this.cmd_Insertar = new RelayCommand(p => this.Insertar());
            this.cmd_Consultar = new RelayCommand(p => this.Consultar());
            this.cmd_Borrar = new RelayCommand(p => this.Borrar());
            this.cmd_Modifica = new RelayCommand(p => this.Modifica());
            this.Tipo_Vehiculo = new Tipo_Vehiculo();
        }

        public void Insertar()
        {
            using (var dbc = new ConexionDbContext())
            {
                if (this.Tipo_Vehiculo.Tipo == null)
                {
                    MessageBox.Show("No digitó el tipo de vehiculo");
                    return;
                }
                dbc.Tipo_Vehiculos.Add(this.Tipo_Vehiculo);
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
                this.Lista = new ObservableCollection<Tipo_Vehiculo>(dbc.Tipo_Vehiculos);
            }
        }

        public void Borrar()
        {
            if (this.Tipo_Vehiculo.Tipo == null)
            {
                MessageBox.Show("No digitó el tipo de vehiculo a borrar");
                return;
            }

            using (var dbc = new ConexionDbContext())
            {
                try
                {
                    var borr = (from p in dbc.Tipo_Vehiculos
                                where p.Tipo == this.Tipo_Vehiculo.Tipo
                                select p).Single();
                    dbc.Tipo_Vehiculos.Remove(borr);
                    dbc.SaveChanges();
                    this.Lista = new ObservableCollection<Tipo_Vehiculo>(dbc.Tipo_Vehiculos);
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
            if (this.Tipo_Vehiculo.Tipo == null)
            {
                MessageBox.Show("No digitó el tipo de vehiculo a modificar");
                return;
            }
            using (var dbc = new ConexionDbContext())
            {
                var tipo_Vehiculo = dbc.Tipo_Vehiculos.Find(this.Tipo_Vehiculo.Tipo_VehiculoID);
                //dbc.Razas.Attach(raza);
                tipo_vehiculo.Tipo = this.Tipo_Vehiculo.Tipo;
              
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
