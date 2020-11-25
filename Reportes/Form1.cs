using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AUTOCAR.Reportes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet2.Vehiculo' Puede moverla o quitarla según sea necesario.
            this.VehiculoTableAdapter.Fill(this.DataSet2.Vehiculo);

            this.reportViewer1.RefreshReport();
        }
    }
}
