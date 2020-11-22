using AUTOCAR.Data;
using AUTOCAR.Modelos;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace AUTOCAR.VistaModelo
{
    class CombustibleVM : INotifyObject
    {
        public RelayCommand cmd_Insertar { get; set; }
        public RelayCommand cmd_Consultar { get; set; }
        public RelayCommand cmd_Borrar { get; set; }
        public RelayCommand cmd_Modifica { get; set; }

        //public bool EsModifica { get; set; }

        public Combustible Combustible { get { return combustible; } set { combustible = value; OnPropertyChanged(); } }
        private Combustible combustible;

        public ObservableCollection<Combustible> Lista { get { return lista; } set { lista = value; OnPropertyChanged(); } }
        private ObservableCollection<Combustible> lista = new ObservableCollection<Combustible>();

        public CombustibleVM()
        {
            this.cmd_Insertar = new RelayCommand(p => this.Insertar());
            this.cmd_Consultar = new RelayCommand(p => this.Consultar());
            this.cmd_Borrar = new RelayCommand(p => this.Borrar());
            this.cmd_Modifica = new RelayCommand(p => this.Modifica());
            this.Combustible = new Combustible();
        }

        public void Insertar()
        {
            using (var dbc = new ConexionDbContext())
            {
                if (this.Combustible.Tipo == null)
                {
                    MessageBox.Show("No digitó el tipo de combustible");
                    return;
                }
                dbc.Combustibles.Add(this.Combustible);
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
                this.Lista = new ObservableCollection<Combustible>(dbc.Combustibles);

            }
        }

        public void Borrar()
        {
            if (this.Combustible.Tipo == null)
            {
                MessageBox.Show("No digitó el nombre tipo de combustible a borrar");
                return;
            }

            using (var dbc = new ConexionDbContext())
            {
                try
                {
                    var borr = (from p in dbc.Combustibles
                                where p.Tipo == this.Combustible.Tipo
                                select p).Single();
                    dbc.Combustibles.Remove(borr);
                    dbc.SaveChanges();
                    this.Lista = new ObservableCollection<Combustible>(dbc.Combustibles);
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
            if (this.Combustible.Tipo == null)
            {
                MessageBox.Show("No digitó el tipo de combustible a modificar");
                return;
            }
            using (var dbc = new ConexionDbContext())
            {
                var Combustible = dbc.Combustibles.Find(this.Combustible.CombustibleID);
                //dbc.Razas.Attach(raza);
                combustible.Tipo = this.Combustible.Tipo;

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
