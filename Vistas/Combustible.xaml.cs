
using System.Windows;

namespace AUTOCAR.Vistas
{
    /// <summary>
    /// Lógica de interacción para Combustible.xaml
    /// </summary>
    public partial class Combustible : Window
    {
        public Combustible()
        {
            InitializeComponent();
        }

        private void Salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
