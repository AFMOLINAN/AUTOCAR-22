using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AUTOCAR.Vistas
{
    /// <summary>
    /// Lógica de interacción para Tipo_Vehiculo.xaml
    /// </summary>
    public partial class Tipo_Vehiculo : Window
    {
        public Tipo_Vehiculo()
        {
            InitializeComponent();
        }

        private void salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
