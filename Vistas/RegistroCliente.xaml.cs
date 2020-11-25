using AUTOCAR.Data;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;


namespace AUTOCAR.Vistas
{
    /// <summary>
    /// Lógica de interacción para Cliente.xaml
    /// </summary>
    public partial class RegistroCliente : Window
    {
        public RegistroCliente()
        {
            InitializeComponent();
        }

        private void Salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
