using System.Windows;
using AUTOCAR.Vistas;
using AUTOCAR.VistaModelo;


namespace AUTOCAR
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Vehiculo(object sender, RoutedEventArgs e)
        {
            RegistroVehiculo RV = new RegistroVehiculo();
            RV.Show();

        }

        private void Tablas(object sender, RoutedEventArgs e)
        {
            Tablas RV = new Tablas();
            RV.Show();

        }

        private void Proveedor(object sender, RoutedEventArgs e)
        {
            RegistroProveedor RP = new RegistroProveedor();
            RP.Show();

        }


        private void Salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
