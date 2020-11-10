using AUTOCAR.Data;
using AUTOCAR.Modelos;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace AUTOCAR.VistaModelo
{
    class CiudadVM : INotifyObject
    {
        public RelayCommand cmd_Insertar { get; set; }
        public RelayCommand cmd_Consultar { get; set; }
        public RelayCommand cmd_Borrar { get; set; }
        public RelayCommand cmd_Modifica { get; set; }

        //public bool EsModifica { get; set; }

        public Ciudad Ciudad { get { return ciudad; } set { ciudad = value; OnPropertyChanged(); } }
        private Ciudad ciudad;

        public ObservableCollection<Ciudad> Lista { get { return lista; } set { lista = value; OnPropertyChanged(); } }
        private ObservableCollection<Ciudad> lista = new ObservableCollection<Ciudad>();

        public ObservableCollection<Departamento> ListaD { get { return listaD; } set { listaD = value; OnPropertyChanged(); } }
        private ObservableCollection<Departamento> listaD = new ObservableCollection<Departamento>();

        public CiudadVM()
            {
                this.cmd_Insertar = new RelayCommand(p => this.Insertar());
                this.cmd_Consultar = new RelayCommand(p => this.Consultar());
                this.cmd_Borrar = new RelayCommand(p => this.Borrar());
                this.cmd_Modifica = new RelayCommand(p => this.Modifica());
                this.Ciudad = new Ciudad();
            using (var dbc = new ConexionDbContext())
            {
                this.ListaD = new ObservableCollection<Departamento>(dbc.Departamentos);
            }
        }

        public void Insertar()
            {
                using (var dbc = new ConexionDbContext())
                {
                    if (this.Ciudad.N_Municipio == null)
                    {
                        MessageBox.Show("No digitó el nombre de la ciudad");
                        return;
                    }
                    dbc.Ciudades.Add(this.Ciudad);
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
                    this.Lista = new ObservableCollection<Ciudad>(dbc.Ciudades);

                }
            }

            public void Borrar()
            {
                if (this.Ciudad.N_Municipio == null)
                {
                    MessageBox.Show("No digitó el nombre de la ciudad a borrar");
                    return;
                }

                using (var dbc = new ConexionDbContext())
                {
                    try
                    {
                        var borr = (from p in dbc.Ciudades
                                    where p.N_Municipio == this.Ciudad.N_Municipio
                                    select p).Single();
                        dbc.Ciudades.Remove(borr);
                        dbc.SaveChanges();
                        this.Lista = new ObservableCollection<Ciudad>(dbc.Ciudades);
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
                if (this.Ciudad.N_Municipio == null)
                {
                    MessageBox.Show("No digitó el nombre de la ciudad a Modificar");
                    return;
                }
                using (var dbc = new ConexionDbContext())
                {
                    var Ciudad = dbc.Ciudades.Find(this.Ciudad.CiudadID);
                    //dbc.Razas.Attach(raza);
                    ciudad.N_Municipio = this.Ciudad.N_Municipio;

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
