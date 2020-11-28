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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet3.DataTable2' Puede moverla o quitarla según sea necesario.
            this.DataTable2TableAdapter.Fill(this.DataSet3.DataTable2);

            this.reportViewer1.RefreshReport();
        }
    }
}
