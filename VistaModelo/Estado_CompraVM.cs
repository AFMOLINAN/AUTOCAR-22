using AUTOCAR.Data;
using AUTOCAR.Modelos;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace AUTOCAR.VistaModelo
{
    class Estado_CompraVM : INotifyObject
    {
        public RelayCommand cmd_Insertar { get; set; }
        public RelayCommand cmd_Consultar { get; set; }
        public RelayCommand cmd_Borrar { get; set; }
        public RelayCommand cmd_Modifica { get; set; }

        //public bool EsModifica { get; set; }

        public Estado_Compra Estado_Compra { get { return estado_compra; } set { estado_compra = value; OnPropertyChanged(); } }
        private Estado_Compra estado_compra;

        public ObservableCollection<Estado_Compra> Lista { get { return lista; } set { lista = value; OnPropertyChanged(); } }
        private ObservableCollection<Estado_Compra> lista = new ObservableCollection<Estado_Compra>();

        public Estado_CompraVM()
        {
            this.cmd_Insertar = new RelayCommand(p => this.Insertar());
            this.cmd_Consultar = new RelayCommand(p => this.Consultar());
            this.cmd_Borrar = new RelayCommand(p => this.Borrar());
            this.cmd_Modifica = new RelayCommand(p => this.Modifica());
            this.Estado_Compra = new Estado_Compra();
        }

        public void Insertar()
        {
            using (var dbc = new ConexionDbContext())
            {
                if (this.Estado_Compra.Estado == null)
                {
                    MessageBox.Show("No digitó el estado de comprar a insertar");
                    return;
                }
                dbc.Estado_Compras.Add(this.Estado_Compra);
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
                this.Lista = new ObservableCollection<Estado_Compra>(dbc.Estado_Compras);

            }
        }

        public void Borrar()
        {
            if (this.Estado_Compra.Estado == null)
            {
                MessageBox.Show("No digitó el estado de comprar a borrar");
                return;
            }

            using (var dbc = new ConexionDbContext())
            {
                try
                {
                    var borr = (from p in dbc.Estado_Compras
                                where p.Estado == this.Estado_Compra.Estado
                                select p).Single();
                    dbc.Estado_Compras.Remove(borr);
                    dbc.SaveChanges();
                    this.Lista = new ObservableCollection<Estado_Compra>(dbc.Estado_Compras);
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
            if (this.Estado_Compra.Estado == null)
            {
                MessageBox.Show("No digitó el estado de compra a modificar");
                return;
            }
            using (var dbc = new ConexionDbContext())
            {
                var Estado_Compra = dbc.Estado_Compras.Find(this.Estado_Compra.Estado_CompraID);
                //dbc.Razas.Attach(raza);
                estado_compra.Estado = this.Estado_Compra.Estado;

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
