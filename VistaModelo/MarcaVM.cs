using AUTOCAR.Data;
using AUTOCAR.Modelos;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace AUTOCAR.VistaModelo
{
    class MarcaVM : INotifyObject
    {
        public RelayCommand cmd_Insertar { get; set; }
        public RelayCommand cmd_Consultar { get; set; }
        public RelayCommand cmd_Borrar { get; set; }
        public RelayCommand cmd_Modifica { get; set; }

        //public bool EsModifica { get; set; }

        public Marca Marca { get { return marca; } set { marca = value; OnPropertyChanged(); } }
        private Marca marca;

        public ObservableCollection<Marca> Lista { get { return lista; } set { lista = value; OnPropertyChanged(); } }
        private ObservableCollection<Marca> lista = new ObservableCollection<Marca>();

        public MarcaVM()
        {
            this.cmd_Insertar = new RelayCommand(p => this.Insertar());
            this.cmd_Consultar = new RelayCommand(p => this.Consultar());
            this.cmd_Borrar = new RelayCommand(p => this.Borrar());
            this.cmd_Modifica = new RelayCommand(p => this.Modifica());
            this.Marca = new Marca();
        }

        public void Insertar()
        {
            using (var dbc = new ConexionDbContext())
            {
                if (this.Marca.N_Marca == null)
                {
                    MessageBox.Show("No digitó el nombre de la marca");
                    return;
                }
                dbc.Marcas.Add(this.Marca);
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
                this.Lista = new ObservableCollection<Marca>(dbc.Marcas);

            }
        }

        public void Borrar()
        {
            if (this.Marca.N_Marca == null)
            {
                MessageBox.Show("No digitó el nombre de la marca a borrar");
                return;
            }

            using (var dbc = new ConexionDbContext())
            {
                try
                {
                    var borr = (from p in dbc.Marcas
                                where p.N_Marca == this.Marca.N_Marca
                                select p).Single();
                    dbc.Marcas.Remove(borr);
                    dbc.SaveChanges();
                    this.Lista = new ObservableCollection<Marca>(dbc.Marcas);
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
            if (this.Marca.N_Marca == null)
            {
                MessageBox.Show("No digitó el nombre de la marca actualizar");
                return;
            }
            using (var dbc = new ConexionDbContext())
            {
                var Marca = dbc.Marcas.Find(this.Marca.MarcaID);
                //dbc.Razas.Attach(raza);
                marca.N_Marca = this.Marca.N_Marca;

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
