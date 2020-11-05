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
    class VehiculoVM : INotifyObject
    {
        public RelayCommand cmd_Insertar { get; set; }

        public Vehiculo Vehiculo { get { return vehiculo; } set { vehiculo = value; OnPropertyChanged(); } }
        private Vehiculo vehiculo;

        public VehiculoVM()
        {
            this.cmd_Insertar = new RelayCommand(p => this.Insertar());
            this.Vehiculo = new Vehiculo();
           
        }
        public void Insertar()
        {
            using (var dbc = new ConexionDbContext())
            {
                if (this.Vehiculo.Placa == null)
                {
                    MessageBox.Show("No digitó el nombre del animal a insertar");
                    return;
                }
                dbc.Vehiculos.Add(this.Vehiculo);
                try
                {
                    dbc.SaveChanges();
                    
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
