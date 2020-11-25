using AUTOCAR.Data;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

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

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
