using AUTOCAR.Data;
using AUTOCAR.Modelos;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace AUTOCAR.VistaModelo
{
    class Tipo_PagoVM : INotifyObject
    {
        public RelayCommand cmd_Insertar { get; set; }
        public RelayCommand cmd_Consultar { get; set; }
        public RelayCommand cmd_Borrar { get; set; }
        public RelayCommand cmd_Modifica { get; set; }

        //public bool EsModifica { get; set; }

        public Tipo_Pago Tipo_Pago { get { return tipo_pago; } set { tipo_pago = value; OnPropertyChanged(); } }
        private Tipo_Pago tipo_pago;

        public ObservableCollection<Tipo_Pago> Lista { get { return lista; } set { lista = value; OnPropertyChanged(); } }
        private ObservableCollection<Tipo_Pago> lista = new ObservableCollection<Tipo_Pago>();

        public Tipo_PagoVM()
        {
            this.cmd_Insertar = new RelayCommand(p => this.Insertar());
            this.cmd_Consultar = new RelayCommand(p => this.Consultar());
            this.cmd_Borrar = new RelayCommand(p => this.Borrar());
            this.cmd_Modifica = new RelayCommand(p => this.Modifica());
            this.Tipo_Pago = new Tipo_Pago();
        }

        public void Insertar()
        {
            using (var dbc = new ConexionDbContext())
            {
                if (this.Tipo_Pago.Metodo_Pago == null)
                {
                    MessageBox.Show("No digitó el nombre del metodo de pago");
                    return;
                }
                dbc.Tipo_Pagos.Add(this.Tipo_Pago);
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
                this.Lista = new ObservableCollection<Tipo_Pago>(dbc.Tipo_Pagos);

            }
        }

        public void Borrar()
        {
            if (this.Tipo_Pago.Metodo_Pago == null)
            {
                MessageBox.Show("No digitó el nombre del metodo de pago a borrar");
                return;
            }

            using (var dbc = new ConexionDbContext())
            {
                try
                {
                    var borr = (from p in dbc.Tipo_Pagos
                                where p.Metodo_Pago == this.Tipo_Pago.Metodo_Pago
                                select p).Single();
                    dbc.Tipo_Pagos.Remove(borr);
                    dbc.SaveChanges();
                    this.Lista = new ObservableCollection<Tipo_Pago>(dbc.Tipo_Pagos);
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
            if (this.Tipo_Pago.Metodo_Pago == null)
            {
                MessageBox.Show("No digitó el nombre del metodo de pago a modificar");
                return;
            }
            using (var dbc = new ConexionDbContext())
            {
                var Departamento = dbc.Departamentos.Find(this.Tipo_Pago.Tipo_PagoID);
                tipo_pago.Metodo_Pago = this.Tipo_Pago.Metodo_Pago;

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
