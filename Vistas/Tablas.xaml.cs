using System.Windows;

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
        private void Ciudad(object sender, RoutedEventArgs e)
        {
            Ciudad RP = new Ciudad();
            RP.Show();

        }

        private void TipoPago(object sender, RoutedEventArgs e)
        {
            Tipo_Pago RP = new Tipo_Pago();
            RP.Show();

        }

        private void Marca(object sender, RoutedEventArgs e)
        {
            Marcas RP = new Marcas();
            RP.Show();

        }
        private void Estado_Compra(object sender, RoutedEventArgs e)
        {
            Estado_Compra RP = new Estado_Compra();
            RP.Show();

        }

        private void Estado(object sender, RoutedEventArgs e)
        {
            Estado RP = new Estado();
            RP.Show();

        }

        private void Combustible(object sender, RoutedEventArgs e)
        {
            Combustible RP = new Combustible();
            RP.Show();

        }

    
        private void Salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
