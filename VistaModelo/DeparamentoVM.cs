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
    class DeparamentoVM : INotifyObject
    {
        public RelayCommand cmd_Insertar { get; set; }
        public RelayCommand cmd_Consultar { get; set; }
        public RelayCommand cmd_Borrar { get; set; }
        public RelayCommand cmd_Modifica { get; set; }

        //public bool EsModifica { get; set; }

        public Departamento Departamento { get { return deparamento; } set { deparamento = value; OnPropertyChanged(); } }
        private Departamento deparamento;


        public DeparamentoVM()
        {
            this.cmd_Insertar = new RelayCommand(p => this.Insertar());
            this.Departamento = new Departamento();
        }

        public void Insertar()
        {
            using (var dbc = new ConexionDbContext())
            {
                if (this.Departamento.N_Departamento == null)
                {
                    MessageBox.Show("No digitó el nombre del deparamento");
                    return;
                }
                dbc.Departamentos.Add(this.Departamento);
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
