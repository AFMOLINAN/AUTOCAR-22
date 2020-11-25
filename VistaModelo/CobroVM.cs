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
    class CobroVM : INotifyObject
    {
        public RelayCommand cmd_Insertar { get; set; }
        public RelayCommand cmd_Consultar { get; set; }
        public RelayCommand cmd_Borrar { get; set; }
        public RelayCommand cmd_Modifica { get; set; }

        public Cobro Cobro { get { return cobro; } set { Cobro = value; OnPropertyChanged(); } }
        private Cobro cobro;


        public ObservableCollection<Cobro> Lista { get { return lista; } set { lista = value; OnPropertyChanged(); } }
        private ObservableCollection<Cobro> lista = new ObservableCollection<Cobro>();

        public ObservableCollection<Cliente> ListaR { get { return listaR; } set { listaR = value; OnPropertyChanged(); } }
        private ObservableCollection<Cliente> listaR = new ObservableCollection<Cliente>();

        public ObservableCollection<Vehiculo> ListaC { get { return listaC; } set { listaC = value; OnPropertyChanged(); } }
        private ObservableCollection<Vehiculo> listaC = new ObservableCollection<Vehiculo>();



        public CobroVM()
        {
            this.cmd_Insertar = new RelayCommand(p => this.Insertar());
            this.cmd_Consultar = new RelayCommand(p => this.Consultar());
            this.cmd_Borrar = new RelayCommand(p => this.Borrar());
            this.cmd_Modifica = new RelayCommand(p => this.Modifica());
            this.Cobro = new Cobro();


            using (var dbc = new ConexionDbContext())
            {
                this.Lista = new ObservableCollection<Cobro>(dbc.Cobros);
                this.ListaR = new ObservableCollection<Cliente>(dbc.Clientes);
                this.ListaC = new ObservableCollection<Vehiculo>(dbc.Vehiculos);
            }

        }




            public void Insertar()
            {
                using (var dbc = new ConexionDbContext())
                {

                    if (this.Cobro.CobroID == 0)
                    {
                        MessageBox.Show("No digitó numero de Factura a insertar");
                        return;
                    }
                    dbc.Cobros.Add(this.Cobro);
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
                    this.Lista = new ObservableCollection<Cobro>(dbc.Cobros);
                }
            }





        public void Borrar()
        {
            if (this.Cobro.CobroID == 0)
            {
                MessageBox.Show("No digitó un numero de Factura correcto a borrar");
                return;
            }

            using (var dbc = new ConexionDbContext())
            {
                try
                {
                    var borr = (from p in dbc.Cobros
                                where p.CobroID == this.Cobro.CobroID
                                select p).Single();
                    dbc.Cobros.Remove(borr);
                    dbc.SaveChanges();
                    this.Lista = new ObservableCollection<Cobro>(dbc.Cobros);
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
            if (this.Cobro.CobroID == 0)
            {
                MessageBox.Show("No digitó un numero de Factura correcto a modificar");
                return;
            }
            using (var dbc = new ConexionDbContext())
            {
                var cobro = dbc.Cobros.Find(this.Cobro.CobroID);

                cobro.CobroID = this.Cobro.CobroID;
                cobro.ClienteID = this.cobro.ClienteID;
                cobro.VehiculoID = this.cobro.VehiculoID;
                cobro.Tipo_PagoID = this.cobro.Tipo_PagoID;
                cobro.Fecha_Cobro = this.cobro.Fecha_Cobro;
                cobro.Total = this.cobro.Total;
                
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
