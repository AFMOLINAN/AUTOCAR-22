using AUTOCAR.Data;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace AUTOCAR.Vistas
{
        public partial class RegistroVehiculo : Window
    {
        
        public RegistroVehiculo()
        {
            InitializeComponent();
        }

       

        private void Salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
