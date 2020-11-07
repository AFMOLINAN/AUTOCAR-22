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
    /// Lógica de interacción para Tablas.xaml
    /// </summary>
    public partial class Tablas : Window
    {
        public Tablas()
        {
            InitializeComponent();
        }

        private void Departamento(object sender, RoutedEventArgs e)
        {
            Departamento RP = new Departamento();
            RP.Show();

        }

        private void TipoVehiculo(object sender, RoutedEventArgs e)
        {
            Tipo_Vehiculo RP = new Tipo_Vehiculo();
            RP.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
