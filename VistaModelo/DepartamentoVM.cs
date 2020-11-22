using AUTOCAR.Data;
using AUTOCAR.Modelos;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace AUTOCAR.VistaModelo
{
    class DepartamentoVM : INotifyObject
    {
        public RelayCommand cmd_Insertar { get; set; }
        public RelayCommand cmd_Consultar { get; set; }
        public RelayCommand cmd_Borrar { get; set; }
        public RelayCommand cmd_Modifica { get; set; }

        //public bool EsModifica { get; set; }

        public Departamento Departamento { get { return departamento; } set { departamento = value; OnPropertyChanged(); } }
        private Departamento departamento;

        public ObservableCollection<Departamento> Lista { get { return lista; } set { lista = value; OnPropertyChanged(); } }
        private ObservableCollection<Departamento> lista = new ObservableCollection<Departamento>();

        public DepartamentoVM()
        {
            this.cmd_Insertar = new RelayCommand(p => this.Insertar());
            this.cmd_Consultar = new RelayCommand(p => this.Consultar());
            this.cmd_Borrar = new RelayCommand(p => this.Borrar());
            this.cmd_Modifica = new RelayCommand(p => this.Modifica());
            this.Departamento = new Departamento();
        }

        public void Insertar()
        {
            using (var dbc = new ConexionDbContext())
            {
                if (this.Departamento.N_Departamento == null)
                {
                    MessageBox.Show("No digitó el nombre del departamento");
                    return;
                }
                dbc.Departamentos.Add(this.Departamento);
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
                this.Lista = new ObservableCollection<Departamento>(dbc.Departamentos);

            }
        }

        public void Borrar()
        {
            if (this.Departamento.N_Departamento == null)
            {
                MessageBox.Show("No digitó el departamento a borrar");
                return;
            }

            using (var dbc = new ConexionDbContext())
            {
                try
                {
                    var borr = (from p in dbc.Departamentos
                                where p.N_Departamento == this.Departamento.N_Departamento
                                select p).Single();
                    dbc.Departamentos.Remove(borr);
                    dbc.SaveChanges();
                    this.Lista = new ObservableCollection<Departamento>(dbc.Departamentos);
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
            if (this.Departamento.N_Departamento == null)
            {
                MessageBox.Show("No digitó el nombre de departamento a modificar");
                return;
            }
            using (var dbc = new ConexionDbContext())
            {
                var Departamento = dbc.Departamentos.Find(this.Departamento.DepartamentoID);
                //dbc.Razas.Attach(raza);
                departamento.N_Departamento = this.Departamento.N_Departamento;

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
