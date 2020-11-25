using System.Windows;
using AUTOCAR.Vistas;
using AUTOCAR.VistaModelo;
using AUTOCAR.Reportes;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cliente(object sender, RoutedEventArgs e)
        {

            RegistroCliente RV = new RegistroCliente();
            RV.Show();

        }

        private void ReporteVehiculo(object sender, RoutedEventArgs e)
        {
            Form1 RV = new Form1();
            RV.ShowDialog();
          

        }

    }
        
}
